﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using RSA;

namespace Server
{
    internal class SocketServer
    {
        public TcpListener server;
        public int port;
        public IPEndPoint iPEndPoint;
        private static int sizeBuffer = 256;
        private bool checkConnect;
        private SQL_server database;
        private string ipDatabase;
        private SSH sshClinet;
        private string ipSSh;
        public SocketServer(int Port)
        {
            this.port = Port;
            this.iPEndPoint = new IPEndPoint(IPAddress.Any, Port);
            server = new TcpListener(iPEndPoint);
            database = new SQL_server();
            database.ConnectSqlServer();
            sshClinet = new SSH("192.168.126.150", "caothi", "123456");
        }
        public static byte[] receive(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeBuffer];
            stream.Read(buffer, 0,buffer.Length);
            return buffer;
        }
        public static void send(string data, NetworkStream stream)
        {
            byte[] buffer = new byte[sizeBuffer];
            buffer = Encoding.UTF8.GetBytes(data);
            stream.Write(buffer, 0, buffer.Length);
        }
        public void Listen()
        {
            server.Start();
            checkConnect = true;
            while (checkConnect)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread t = new Thread(new ThreadStart(() => acceptClient(client)));
                    t.Start();
                }
                catch { }
            }
        }
        private void acceptClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            string authentication = "";
            DateTime time = DateTime.Now;
            while (checkConnect)
            {
                try
                {
                    if ((DateTime.Now.Ticks - time.Ticks) == 1000000)
                    {
                        send("Connection to server timed out",stream);
                        return;
                    }
                    byte[] dataEncryptBytes =receive(stream);
                    stream.Flush();
                    string dataDecrypt=RSAKeys.DecryptData(dataEncryptBytes);
                    string[] data = dataDecrypt.Split(',');
                    string status = data[data.Length-1].Trim('\0');
                    switch  (status){
                        case "registry":
                            _Resgistry(data,authentication,stream);
                            break;
                        case "forget":
                            Forget(data,stream);
                            return;
                        case "login":
                            Login(data,stream);
                            return;
                        case "changePass":
                            ChangePass(data,stream);
                            return;
                        case "getEmail":
                            getEmail(data,stream);
                            return;
                        case "check":
                            authentication=checkEmailVsUser(data,stream);
                            if (authentication!= "") break;
                            else return;
                    }
                }
                catch
                {
                }
            }
            stream.Close();
            client.Close();
        }
        private void getEmail(string[] data, NetworkStream stream)
        {
            try
            {
                send(database.getEmail(data[0]), stream);
            }
            catch
            { }
        }
        private void _Resgistry(string[] data,string authenticatonCode, NetworkStream stream)
        {
            bool check = database.checkUserName(data[0]);
            if (!check && data[3]==authenticatonCode)
            {
                string res = database.AddUser(data[0], data[1], data[2]).ToString();
                sshClinet.AddUser(data[0], data[1]);
                send(res, stream);
            }
            else send("False", stream);
        }
        private void Forget(string[] data, NetworkStream stream)
        {
            string passRandom = Email.GenerateRandomPassword();
            string email=database.getEmail(data[0]);
            if (email == "") {
                send("False", stream);
                return;
            }
            Email SMTP= new Email();
            SMTP.SendPasswordResetEmail(email, data[0], passRandom);
            send(database.ChangePass(data[0], passRandom).ToString(),stream);
            sshClinet.ChangePassword(data[0],passRandom);
        }
        private void Login(string[] data, NetworkStream stream)
        {
            send(database.checkUser(data[0], data[1]).ToString(), stream);
        }
        private void ChangePass(string[] data, NetworkStream stream)
        {
            bool check = database.checkUser(data[0], data[1]);
            if ( check== true)
            {
                send(database.ChangePass(data[0], data[2]).ToString(), stream);
                sshClinet.ChangePassword(data[0], data[2]);
                return;
            }
            else send("False", stream);
        }   
        private string checkEmailVsUser(string[] data, NetworkStream stream)
        {
            bool check = database.checkEmailAndUser(data[0], data[1]);
            string authenticationCode = "";
            if (!check)
            {
                Email SMTP = new Email();
                authenticationCode=Email.GenerateRandomNumber();
                try { SMTP.SendAuthenticationCode(data[1], authenticationCode); }
                catch {
                    send("Invalid email", stream);
                    return "";
                }
                send("True", stream);
            }
            else {
                send("False", stream);
                authenticationCode = "";
            }
            return authenticationCode;
        }
        public void disconect(bool check)
        {
            server.Stop();
            checkConnect = check;
        }
    }
}
