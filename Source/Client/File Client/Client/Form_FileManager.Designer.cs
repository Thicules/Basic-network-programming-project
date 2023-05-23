﻿namespace Client
{
    partial class Form_FileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FileManager));
            button_Back = new Button();
            label1 = new Label();
            textBox_Path = new TextBox();
            listView_Dialog = new ListView();
            iconList = new ImageList(components);
            button_Go = new Button();
            button_Upload = new Button();
            label_FileName = new Label();
            contextMenuStrip_Function = new ContextMenuStrip(components);
            toolStripMenuItem_Delete = new ToolStripMenuItem();
            toolStripMenuItem_Copy = new ToolStripMenuItem();
            toolStripMenuItem_Cut = new ToolStripMenuItem();
            toolStripMenuItem_Rename = new ToolStripMenuItem();
            toolStripMenuItem_Download = new ToolStripMenuItem();
            contextMenuStrip_Function.SuspendLayout();
            SuspendLayout();
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(13, 9);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(68, 27);
            this.button_Back.TabIndex = 0;
            this.button_Back.Text = "Back";
            this.button_Back.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "FileName:";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(87, 9);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(627, 27);
            this.textBox_Path.TabIndex = 2;
            // 
            // listView_Dialog
            // 
            listView_Dialog.GroupImageList = iconList;
            listView_Dialog.LargeImageList = iconList;
            listView_Dialog.Location = new Point(13, 46);
            listView_Dialog.Name = "listView_Dialog";
            listView_Dialog.Size = new Size(775, 366);
            listView_Dialog.TabIndex = 3;
            listView_Dialog.UseCompatibleStateImageBehavior = false;
            listView_Dialog.ItemSelectionChanged += listView_Dialog_ItemSelectionChanged;
            listView_Dialog.MouseDoubleClick += listView_Dialog_MouseDoubleClick;
            listView_Dialog.MouseDown += listView_Dialog_MouseDown;
            // 
            // iconList
            // 
            this.iconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "Folder.png");
            this.iconList.Images.SetKeyName(1, "Doc");
            this.iconList.Images.SetKeyName(2, "PDF");
            this.iconList.Images.SetKeyName(3, "PPT");
            this.iconList.Images.SetKeyName(4, "XLSX");
            this.iconList.Images.SetKeyName(5, "Image.jpg");
            this.iconList.Images.SetKeyName(6, "Video");
            this.iconList.Images.SetKeyName(7, "ZIP");
            this.iconList.Images.SetKeyName(8, "Other");
            this.iconList.Images.SetKeyName(9, "MP3");
            this.iconList.Images.SetKeyName(10, "TXT");
            // 
            // button_Go
            // 
            this.button_Go.Location = new System.Drawing.Point(720, 9);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(68, 27);
            this.button_Go.TabIndex = 5;
            this.button_Go.Text = "Go";
            this.button_Go.UseVisualStyleBackColor = true;
            // 
            // button_Upload
            // 
            button_Upload.Location = new Point(720, 418);
            button_Upload.Name = "button_Upload";
            button_Upload.Size = new Size(68, 27);
            button_Upload.TabIndex = 6;
            button_Upload.Text = "Upload";
            button_Upload.UseVisualStyleBackColor = true;
            button_Upload.Click += button_Upload_Click;
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Location = new System.Drawing.Point(157, 421);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(21, 20);
            this.label_FileName.TabIndex = 7;
            this.label_FileName.Text = "--";
            // 
            // contextMenuStrip_Function
            // 
            contextMenuStrip_Function.ImageScalingSize = new Size(20, 20);
            contextMenuStrip_Function.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_Delete, toolStripMenuItem_Copy, toolStripMenuItem_Cut, toolStripMenuItem_Rename, toolStripMenuItem_Download });
            contextMenuStrip_Function.Name = "contextMenuStrip_Function";
            contextMenuStrip_Function.Size = new Size(148, 124);
            // 
            // toolStripMenuItem_Delete
            // 
            toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            toolStripMenuItem_Delete.Size = new Size(147, 24);
            toolStripMenuItem_Delete.Text = "Delete";
            toolStripMenuItem_Delete.Click += toolStripMenuItem_Delete_Click;
            // 
            // toolStripMenuItem_Copy
            // 
            toolStripMenuItem_Copy.Name = "toolStripMenuItem_Copy";
            toolStripMenuItem_Copy.Size = new Size(147, 24);
            toolStripMenuItem_Copy.Text = "Copy";
            toolStripMenuItem_Copy.Click += toolStripMenuItem_Copy_Click;
            // 
            // toolStripMenuItem_Cut
            // 
            toolStripMenuItem_Cut.Name = "toolStripMenuItem_Cut";
            toolStripMenuItem_Cut.Size = new Size(147, 24);
            toolStripMenuItem_Cut.Text = "Cut";
            toolStripMenuItem_Cut.Click += toolStripMenuItem_Cut_Click;
            // 
            // toolStripMenuItem_Rename
            // 
            toolStripMenuItem_Rename.Name = "toolStripMenuItem_Rename";
            toolStripMenuItem_Rename.Size = new Size(147, 24);
            toolStripMenuItem_Rename.Text = "Rename";
            toolStripMenuItem_Rename.Click += toolStripMenuItem_Rename_Click;
            // 
            // toolStripMenuItem_Download
            // 
            toolStripMenuItem_Download.Name = "toolStripMenuItem_Download";
            toolStripMenuItem_Download.Size = new Size(147, 24);
            toolStripMenuItem_Download.Text = "Download";
            toolStripMenuItem_Download.Click += toolStripMenuItem_Download_Click;
            // 
            // Form_FileManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_FileName);
            Controls.Add(button_Upload);
            Controls.Add(button_Go);
            Controls.Add(listView_Dialog);
            Controls.Add(textBox_Path);
            Controls.Add(label1);
            Controls.Add(button_Back);
            Name = "Form_FileManager";
            Text = "Form_FileManager";
            contextMenuStrip_Function.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Back;
        private Label label1;
        private TextBox textBox_Path;
        private ListView listView_Dialog;
        private ImageList iconList;
        private Button button_Go;
        private Button button_Upload;
        private Label label_FileName;
        private ContextMenuStrip contextMenuStrip_Function;
        private ToolStripMenuItem toolStripMenuItem_Delete;
        private ToolStripMenuItem toolStripMenuItem_Copy;
        private ToolStripMenuItem toolStripMenuItem_Cut;
        private ToolStripMenuItem toolStripMenuItem_Rename;
        private ToolStripMenuItem toolStripMenuItem_Download;
    }
}