﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class Form_FileManager : Form
    {
        FTP ftpClient;
        private string filePath = "";
        private bool isFile = false;
        private string currentPath = "";
        private string filename = "";
        MemoryStream memoryStream;

        public Form_FileManager()
        {
            InitializeComponent();
            loadFilesAndDirectories("");
        }

        public void loadFilesAndDirectories(string path)
        {
            listView_Dialog.Items.Clear();
            ftpClient = new FTP(@"ftp://172.20.110.52/", "caothi", "123456");
            ftpClient.connect();
            // List directorys and files
            List<string> listAll = ftpClient.directoryListDetailed(path);
            //List Files
            List<string> listFiles = FTP.ListFile(listAll);
            //List directorys
            List<string> listDirs = FTP.ListDirectory(listAll);
            string tempFilePath = "";
            FileAttributes fileAttr;
            try
            {
                foreach (var file in listFiles)
                {
                    if (file.IndexOf('.') != -1)
                    {
                        var fileExtension = file.Split('.')[1];
                        {
                            switch (fileExtension)
                            {
                                case "mp3":
                                case "mp2":
                                    ListViewItem item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 9;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "txt":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 10;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "ppt":
                                case "pptx":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 3;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "mp4":
                                case "avi":
                                case "mkv":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 6;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "pdf":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 2;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "doc":
                                case "docx":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 1;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "xsl":
                                case "xslx":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 4;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "zip":
                                case "rar":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 7;
                                    listView_Dialog.Items.Add(item);
                                    break;
                                case "png":
                                case "jpg":
                                case "jpeg":
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 5;
                                    listView_Dialog.Items.Add(item);
                                    break;

                                default:
                                    item = new ListViewItem();
                                    item.Tag = "File";
                                    item.Text = file;
                                    item.ImageIndex = 8;
                                    listView_Dialog.Items.Add(item);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = "File";
                        item.Text = file;
                        item.ImageIndex = 8;
                        listView_Dialog.Items.Add(item);
                    }
                }
                foreach (string dir in listDirs)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = "Dir";
                    item.Text = dir;
                    item.ImageIndex = 0;
                    listView_Dialog.Items.Add(item);
                }
                currentPath = path;
                textBox_Path.Text = path;
            }
            catch (Exception e)
            {

            }
        }

        private void listView_Dialog_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            label_FileName.Text = e.Item.Text;
        }

        public void loadButtonAction()
        {
            filePath = textBox_Path.Text;
            loadFilesAndDirectories(filePath);
            removeBackSlash();
            isFile = false;
        }

        public void removeBackSlash()
        {
            string path = textBox_Path.Text;
            if (path != null && path.Length > 0 && path.LastIndexOf("\\") == path.Length - 1)
            {
                textBox_Path.Text = path.Substring(0, path.Length - 1);
            }
        }

        public void goBack()
        {
            try
            {
                string path = textBox_Path.Text;
                if (path.EndsWith("/"))
                {
                    path = path.Remove(path.Length - 1);
                }
                int lastSlashIdx = path.LastIndexOf("/");
                if (lastSlashIdx != -1)
                {
                    path = path.Substring(0, lastSlashIdx);
                }
                else
                {
                    path = "/";
                }
                this.isFile = false;
                textBox_Path.Text = path;
                loadFilesAndDirectories(path);
            }
            catch (Exception e)
            {

            }
        }

        private void button_Go_Click(object sender, EventArgs e)
        {
            loadButtonAction();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            goBack();
            loadButtonAction();
        }

        private void listView_Dialog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_Dialog.SelectedItems.Count > 0)
            {
                // Lấy tên item đang chọn
                ListViewItem item = listView_Dialog.SelectedItems[0];
                string nameItem = item.Text;
                // mở thư mục chọn
                if (item.Tag == "Dir")
                {
                    currentPath += '/' + nameItem;
                    loadFilesAndDirectories(currentPath);
                }
            }
        }

        private void listView_Dialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Lấy item được chọn
                ListViewItem item = listView_Dialog.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    // Hiển thị menu context cho item được chọn
                    contextMenuStrip_Function1.Show(listView_Dialog, e.Location);
                }
                else
                {
                    contextMenuStrip_Function2.Show(listView_Dialog, e.Location);
                }
            }
        }

        private void toolStripMenuItem_Download_Click(object sender, EventArgs e)
        {
            // Lấy item được chọn
            ListViewItem item = listView_Dialog.SelectedItems[0];

            // Mở folder muốn lưu file
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn thư mục muốn lưu tập tin trên máy tính
                string localFolderPath = fbd.SelectedPath;
                // Lấy tên tập tin cần tải về
                string remoteFileName = item.Text;
                // Lấy đường dẫn tập tin trên máy chủ FTP
                string remoteFilePath = currentPath + remoteFileName;

                // Tải tập tin từ máy chủ FTP về máy tính
                ftpClient.downloadFile(remoteFilePath, Path.Combine(localFolderPath, remoteFileName));

                // Cập nhật danh sách tập tin và thư mục hiện tại
                loadFilesAndDirectories(currentPath);
            }
        }

        public static string ShowInputDialog(string title, string promptText, string defaultValue = "")
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 170;
            prompt.Text = title;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = promptText };
            textLabel.AutoSize = true;
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 400, Text = defaultValue };
            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "OK", Left = 350, Width = 100, Height = 30, Top = 80 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return textBox.Text;
        }

        private void toolStripMenuItem_Rename_Click(object sender, EventArgs e)
        {
            // Lấy item được chọn
            ListViewItem item = listView_Dialog.SelectedItems[0];

            // Lấy tên hiện tại của item
            string currentName = item.Text;

            // Hiển thị hộp thoại nhập tên mới cho item
            string newName = ShowInputDialog("Rename", "Enter new name for " + currentName + ":", currentName);
            if (newName != null)
            {
                // Thực hiện đổi tên item trên máy chủ FTP
                ftpClient.rename(currentPath + "/" + currentName, newName);

                // Cập nhật lại danh sách các item trong listView
                loadFilesAndDirectories(currentPath);
            }
        }

        private void toolStripMenuItem_Copy_Click(object sender, EventArgs e)
        {
            // Lấy item được chọn
            ListViewItem item = listView_Dialog.SelectedItems[0];

            // Sao chép item và lấy tên tệp tin
            (memoryStream, filename) = ftpClient.copy(currentPath + "/" + item.Text);
            loadFilesAndDirectories(currentPath);
        }

        private void toolStripMenuItem_Cut_Click(object sender, EventArgs e)
        {
            // Lấy item được chọn
            ListViewItem item = listView_Dialog.SelectedItems[0];

            // Sao chép item và lấy tên tệp tin
            (memoryStream, filename) = ftpClient.copy(currentPath + "/" + item.Text);

            bool isFolder = item.ImageIndex == 0;

            // Xóa item
            if (isFolder)
            {
                ftpClient.deleteFolder(currentPath + "/" + item.Text);
            }
            else if (!isFolder)
            {
                ftpClient.deleteFile(currentPath + "/" + item.Text);
            }
            loadFilesAndDirectories(currentPath);
        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            // Lấy item được chọn
            ListViewItem item = listView_Dialog.SelectedItems[0];

            bool isFolder = item.ImageIndex == 0;

            // Xóa item
            if (isFolder)
            {
                ftpClient.deleteFolder(currentPath + "/" + item.Text);
            }
            else if (!isFolder)
            {
                ftpClient.deleteFile(currentPath + "/" + item.Text);
            }
            loadFilesAndDirectories(currentPath);
        }

        private void toolStripMenuItem_CreateFolder_Click(object sender, EventArgs e)
        {
            string newName = ShowInputDialog("Rename", "Enter new name for: ", "");
            if (newName != null)
            {
                ftpClient.createDirectory(currentPath + "/" + newName);
                loadFilesAndDirectories(currentPath);
            }
        }


        private void toolStripMenuItem_UploadFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string localFolderPath = fbd.SelectedPath;
                string folderName = new DirectoryInfo(localFolderPath).Name;
                string remoteFolderPath = currentPath + "/" + folderName;

                // Tạo thư mục mới trên máy chủ FTP trước khi tải lên thư mục và tất cả các tệp tin và thư mục con của nó
                ftpClient.createDirectory(remoteFolderPath);

                // Tải lên thư mục và tất cả các tệp tin và thư mục con của nó lên máy chủ FTP
                ftpClient.uploadFolder(remoteFolderPath, localFolderPath);
                loadFilesAndDirectories(currentPath);
            }
        }

        private void toolStripMenuItem_UploadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = openFileDialog.FileName;
                string remoteFileName = Path.GetFileName(localFilePath);
                string remoteFilePath = currentPath + "/" + remoteFileName;

                // Tải lên tập tin lên máy chủ FTP
                ftpClient.uploadFile(remoteFilePath, localFilePath);
                loadFilesAndDirectories(currentPath);
            }
        }

        private void toolStripMenuItem_Paste_Click(object sender, EventArgs e)
        {
            // Dán file 
            ftpClient.paste(currentPath, memoryStream, filename);
            loadFilesAndDirectories(currentPath);
        }
    }
}