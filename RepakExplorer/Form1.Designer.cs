﻿namespace RepakExplorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            FileExplorer_GB = new GroupBox();
            LoadedFilePath_Label = new Label();
            FileExplorer_GoBack = new LinkLabel();
            FileExplorer_GoToRoot = new LinkLabel();
            FileExplorer_PathLabel = new Label();
            FileExplorer_ListView = new ListView();
            imageList1 = new ImageList(components);
            DropLabel = new Label();
            DropSpot = new Panel();
            PakActs_GB = new GroupBox();
            PakActs_Unload = new Button();
            PakActs_Info = new Button();
            PakActs_ListHash = new Button();
            PakActs_Unpack = new Button();
            Console_GB = new GroupBox();
            Console_TB = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            DirActs_GB = new GroupBox();
            DirActs_Unload = new Button();
            DirActs_AppendP = new CheckBox();
            label1 = new Label();
            DirActs_Compression = new ComboBox();
            DirActs_Package = new Button();
            Blocker = new Panel();
            RepakLink = new LinkLabel();
            label2 = new Label();
            FileExplorer_GB.SuspendLayout();
            PakActs_GB.SuspendLayout();
            Console_GB.SuspendLayout();
            DirActs_GB.SuspendLayout();
            Blocker.SuspendLayout();
            SuspendLayout();
            // 
            // FileExplorer_GB
            // 
            FileExplorer_GB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FileExplorer_GB.Controls.Add(LoadedFilePath_Label);
            FileExplorer_GB.Controls.Add(FileExplorer_GoBack);
            FileExplorer_GB.Controls.Add(FileExplorer_GoToRoot);
            FileExplorer_GB.Controls.Add(FileExplorer_PathLabel);
            FileExplorer_GB.Controls.Add(FileExplorer_ListView);
            FileExplorer_GB.ForeColor = Color.Orange;
            FileExplorer_GB.Location = new Point(12, 9);
            FileExplorer_GB.Name = "FileExplorer_GB";
            FileExplorer_GB.Size = new Size(778, 304);
            FileExplorer_GB.TabIndex = 0;
            FileExplorer_GB.TabStop = false;
            FileExplorer_GB.Text = "File Explorer";
            FileExplorer_GB.Visible = false;
            // 
            // LoadedFilePath_Label
            // 
            LoadedFilePath_Label.AutoSize = true;
            LoadedFilePath_Label.ForeColor = Color.FromArgb(255, 128, 0);
            LoadedFilePath_Label.Location = new Point(89, 0);
            LoadedFilePath_Label.Name = "LoadedFilePath_Label";
            LoadedFilePath_Label.Size = new Size(16, 15);
            LoadedFilePath_Label.TabIndex = 4;
            LoadedFilePath_Label.Text = "...";
            // 
            // FileExplorer_GoBack
            // 
            FileExplorer_GoBack.AutoSize = true;
            FileExplorer_GoBack.LinkColor = Color.FromArgb(255, 128, 0);
            FileExplorer_GoBack.Location = new Point(9, 36);
            FileExplorer_GoBack.Name = "FileExplorer_GoBack";
            FileExplorer_GoBack.Size = new Size(32, 15);
            FileExplorer_GoBack.TabIndex = 3;
            FileExplorer_GoBack.TabStop = true;
            FileExplorer_GoBack.Text = "Back";
            FileExplorer_GoBack.VisitedLinkColor = Color.FromArgb(255, 128, 0);
            FileExplorer_GoBack.LinkClicked += FileExplorer_GoBack_LinkClicked;
            // 
            // FileExplorer_GoToRoot
            // 
            FileExplorer_GoToRoot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FileExplorer_GoToRoot.AutoSize = true;
            FileExplorer_GoToRoot.LinkColor = Color.FromArgb(255, 128, 0);
            FileExplorer_GoToRoot.Location = new Point(740, 36);
            FileExplorer_GoToRoot.Name = "FileExplorer_GoToRoot";
            FileExplorer_GoToRoot.Size = new Size(32, 15);
            FileExplorer_GoToRoot.TabIndex = 2;
            FileExplorer_GoToRoot.TabStop = true;
            FileExplorer_GoToRoot.Text = "Root";
            FileExplorer_GoToRoot.VisitedLinkColor = Color.FromArgb(255, 128, 0);
            FileExplorer_GoToRoot.LinkClicked += FileExplorer_GoToRoot_LinkClicked;
            // 
            // FileExplorer_PathLabel
            // 
            FileExplorer_PathLabel.AutoSize = true;
            FileExplorer_PathLabel.Location = new Point(9, 19);
            FileExplorer_PathLabel.Name = "FileExplorer_PathLabel";
            FileExplorer_PathLabel.Size = new Size(32, 15);
            FileExplorer_PathLabel.TabIndex = 1;
            FileExplorer_PathLabel.Text = "Root";
            // 
            // FileExplorer_ListView
            // 
            FileExplorer_ListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FileExplorer_ListView.BackColor = Color.FromArgb(64, 64, 64);
            FileExplorer_ListView.BorderStyle = BorderStyle.FixedSingle;
            FileExplorer_ListView.ForeColor = Color.Orange;
            FileExplorer_ListView.LargeImageList = imageList1;
            FileExplorer_ListView.Location = new Point(6, 54);
            FileExplorer_ListView.Name = "FileExplorer_ListView";
            FileExplorer_ListView.Size = new Size(766, 243);
            FileExplorer_ListView.TabIndex = 0;
            FileExplorer_ListView.TileSize = new Size(64, 64);
            FileExplorer_ListView.UseCompatibleStateImageBehavior = false;
            FileExplorer_ListView.ItemActivate += FileExplorer_ListView_ItemActivate;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Folder.png");
            imageList1.Images.SetKeyName(1, "Icon_uasset.png");
            imageList1.Images.SetKeyName(2, "Icon_uexp.png");
            imageList1.Images.SetKeyName(3, "Icon_ubulk.png");
            // 
            // DropLabel
            // 
            DropLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DropLabel.AutoSize = true;
            DropLabel.BackColor = Color.Transparent;
            DropLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DropLabel.ForeColor = Color.Orange;
            DropLabel.Location = new Point(312, 280);
            DropLabel.Name = "DropLabel";
            DropLabel.Size = new Size(176, 21);
            DropLabel.TabIndex = 2;
            DropLabel.Text = "Drop .pak or folder here";
            // 
            // DropSpot
            // 
            DropSpot.AllowDrop = true;
            DropSpot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DropSpot.BackgroundImage = Properties.Resources.DragDrop_Icon;
            DropSpot.BackgroundImageLayout = ImageLayout.Zoom;
            DropSpot.BorderStyle = BorderStyle.FixedSingle;
            DropSpot.Location = new Point(300, 77);
            DropSpot.Name = "DropSpot";
            DropSpot.Size = new Size(200, 200);
            DropSpot.TabIndex = 3;
            DropSpot.DragDrop += DropSpot_DragDrop;
            DropSpot.DragEnter += DropSpot_DragEnter;
            DropSpot.DragLeave += DropSpot_DragLeave;
            // 
            // PakActs_GB
            // 
            PakActs_GB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PakActs_GB.Controls.Add(PakActs_Unload);
            PakActs_GB.Controls.Add(PakActs_Info);
            PakActs_GB.Controls.Add(PakActs_ListHash);
            PakActs_GB.Controls.Add(PakActs_Unpack);
            PakActs_GB.ForeColor = Color.Orange;
            PakActs_GB.Location = new Point(12, 320);
            PakActs_GB.Name = "PakActs_GB";
            PakActs_GB.Size = new Size(778, 70);
            PakActs_GB.TabIndex = 4;
            PakActs_GB.TabStop = false;
            PakActs_GB.Text = "Pak Actions";
            PakActs_GB.Visible = false;
            // 
            // PakActs_Unload
            // 
            PakActs_Unload.FlatStyle = FlatStyle.Popup;
            PakActs_Unload.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PakActs_Unload.Location = new Point(545, 22);
            PakActs_Unload.Name = "PakActs_Unload";
            PakActs_Unload.Size = new Size(122, 32);
            PakActs_Unload.TabIndex = 5;
            PakActs_Unload.Text = "Unload";
            PakActs_Unload.UseVisualStyleBackColor = true;
            PakActs_Unload.Click += PakActs_Unload_Click;
            // 
            // PakActs_Info
            // 
            PakActs_Info.FlatStyle = FlatStyle.Popup;
            PakActs_Info.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PakActs_Info.Location = new Point(264, 22);
            PakActs_Info.Name = "PakActs_Info";
            PakActs_Info.Size = new Size(122, 32);
            PakActs_Info.TabIndex = 2;
            PakActs_Info.Text = "Info";
            PakActs_Info.UseVisualStyleBackColor = true;
            PakActs_Info.Click += PakActs_Info_Click;
            // 
            // PakActs_ListHash
            // 
            PakActs_ListHash.FlatStyle = FlatStyle.Popup;
            PakActs_ListHash.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PakActs_ListHash.Location = new Point(392, 22);
            PakActs_ListHash.Name = "PakActs_ListHash";
            PakActs_ListHash.Size = new Size(122, 32);
            PakActs_ListHash.TabIndex = 1;
            PakActs_ListHash.Text = "List Hash";
            PakActs_ListHash.UseVisualStyleBackColor = true;
            PakActs_ListHash.Click += PakActs_ListHash_Click;
            // 
            // PakActs_Unpack
            // 
            PakActs_Unpack.FlatStyle = FlatStyle.Popup;
            PakActs_Unpack.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PakActs_Unpack.Location = new Point(111, 22);
            PakActs_Unpack.Name = "PakActs_Unpack";
            PakActs_Unpack.Size = new Size(122, 32);
            PakActs_Unpack.TabIndex = 0;
            PakActs_Unpack.Text = "Unpack";
            PakActs_Unpack.UseVisualStyleBackColor = true;
            PakActs_Unpack.Click += PakActs_Unpack_Click;
            // 
            // Console_GB
            // 
            Console_GB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Console_GB.Controls.Add(Console_TB);
            Console_GB.ForeColor = Color.Orange;
            Console_GB.Location = new Point(12, 396);
            Console_GB.Name = "Console_GB";
            Console_GB.Size = new Size(778, 267);
            Console_GB.TabIndex = 5;
            Console_GB.TabStop = false;
            Console_GB.Text = "Console";
            // 
            // Console_TB
            // 
            Console_TB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Console_TB.BackColor = Color.FromArgb(64, 64, 64);
            Console_TB.BorderStyle = BorderStyle.None;
            Console_TB.ForeColor = Color.White;
            Console_TB.Location = new Point(6, 22);
            Console_TB.Multiline = true;
            Console_TB.Name = "Console_TB";
            Console_TB.ScrollBars = ScrollBars.Vertical;
            Console_TB.Size = new Size(767, 239);
            Console_TB.TabIndex = 0;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "Select a directory for unpacking";
            // 
            // DirActs_GB
            // 
            DirActs_GB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DirActs_GB.Controls.Add(DirActs_Unload);
            DirActs_GB.Controls.Add(DirActs_AppendP);
            DirActs_GB.Controls.Add(label1);
            DirActs_GB.Controls.Add(DirActs_Compression);
            DirActs_GB.Controls.Add(DirActs_Package);
            DirActs_GB.ForeColor = Color.Orange;
            DirActs_GB.Location = new Point(12, 320);
            DirActs_GB.Name = "DirActs_GB";
            DirActs_GB.Size = new Size(778, 70);
            DirActs_GB.TabIndex = 6;
            DirActs_GB.TabStop = false;
            DirActs_GB.Text = "Directory Actions";
            DirActs_GB.Visible = false;
            // 
            // DirActs_Unload
            // 
            DirActs_Unload.FlatStyle = FlatStyle.Popup;
            DirActs_Unload.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DirActs_Unload.Location = new Point(563, 23);
            DirActs_Unload.Name = "DirActs_Unload";
            DirActs_Unload.Size = new Size(122, 32);
            DirActs_Unload.TabIndex = 4;
            DirActs_Unload.Text = "Unload";
            DirActs_Unload.UseVisualStyleBackColor = true;
            DirActs_Unload.Click += DirActs_Unload_Click;
            // 
            // DirActs_AppendP
            // 
            DirActs_AppendP.AutoSize = true;
            DirActs_AppendP.Checked = true;
            DirActs_AppendP.CheckState = CheckState.Checked;
            DirActs_AppendP.Location = new Point(449, 31);
            DirActs_AppendP.Name = "DirActs_AppendP";
            DirActs_AppendP.Size = new Size(83, 19);
            DirActs_AppendP.TabIndex = 3;
            DirActs_AppendP.Text = "Append _P";
            DirActs_AppendP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 32);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 2;
            label1.Text = "Compression:";
            // 
            // DirActs_Compression
            // 
            DirActs_Compression.BackColor = Color.FromArgb(64, 64, 64);
            DirActs_Compression.FlatStyle = FlatStyle.Popup;
            DirActs_Compression.ForeColor = Color.Orange;
            DirActs_Compression.FormattingEnabled = true;
            DirActs_Compression.Items.AddRange(new object[] { "None", "Zlib", "Gzip", "Zstd" });
            DirActs_Compression.Location = new Point(331, 28);
            DirActs_Compression.Name = "DirActs_Compression";
            DirActs_Compression.Size = new Size(90, 23);
            DirActs_Compression.TabIndex = 1;
            DirActs_Compression.Text = "None";
            // 
            // DirActs_Package
            // 
            DirActs_Package.FlatStyle = FlatStyle.Popup;
            DirActs_Package.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DirActs_Package.Location = new Point(93, 23);
            DirActs_Package.Name = "DirActs_Package";
            DirActs_Package.Size = new Size(122, 32);
            DirActs_Package.TabIndex = 0;
            DirActs_Package.Text = "Package";
            DirActs_Package.UseVisualStyleBackColor = true;
            DirActs_Package.Click += DirActs_Package_Click;
            // 
            // Blocker
            // 
            Blocker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Blocker.Controls.Add(RepakLink);
            Blocker.Controls.Add(label2);
            Blocker.Location = new Point(2, 3);
            Blocker.Name = "Blocker";
            Blocker.Size = new Size(796, 669);
            Blocker.TabIndex = 7;
            Blocker.Visible = false;
            // 
            // RepakLink
            // 
            RepakLink.AutoSize = true;
            RepakLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RepakLink.LinkColor = Color.FromArgb(255, 128, 0);
            RepakLink.Location = new Point(53, 99);
            RepakLink.Name = "RepakLink";
            RepakLink.Size = new Size(248, 21);
            RepakLink.TabIndex = 1;
            RepakLink.TabStop = true;
            RepakLink.Text = "https://github.com/trumank/repak";
            RepakLink.VisitedLinkColor = Color.FromArgb(255, 128, 0);
            RepakLink.LinkClicked += RepakLink_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Orange;
            label2.Location = new Point(50, 55);
            label2.Name = "label2";
            label2.Size = new Size(161, 25);
            label2.TabIndex = 0;
            label2.Text = "repak.exe missing";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 674);
            Controls.Add(Blocker);
            Controls.Add(DirActs_GB);
            Controls.Add(PakActs_GB);
            Controls.Add(Console_GB);
            Controls.Add(FileExplorer_GB);
            Controls.Add(DropLabel);
            Controls.Add(DropSpot);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Repak Explorer - v.1.0";
            Load += Form1_Load;
            FileExplorer_GB.ResumeLayout(false);
            FileExplorer_GB.PerformLayout();
            PakActs_GB.ResumeLayout(false);
            Console_GB.ResumeLayout(false);
            Console_GB.PerformLayout();
            DirActs_GB.ResumeLayout(false);
            DirActs_GB.PerformLayout();
            Blocker.ResumeLayout(false);
            Blocker.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox FileExplorer_GB;
        private ListView FileExplorer_ListView;
        private ImageList imageList1;
        private Label FileExplorer_PathLabel;
        private Label DropLabel;
        private Panel DropSpot;
        private LinkLabel FileExplorer_GoBack;
        private LinkLabel FileExplorer_GoToRoot;
        private GroupBox PakActs_GB;
        private Button PakActs_Unpack;
        private GroupBox Console_GB;
        private TextBox Console_TB;
        private Button PakActs_Info;
        private Button PakActs_ListHash;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox DirActs_GB;
        private Button DirActs_Package;
        private CheckBox DirActs_AppendP;
        private Label label1;
        private ComboBox DirActs_Compression;
        private Label LoadedFilePath_Label;
        private Button DirActs_Unload;
        private Button PakActs_Unload;
        private Panel Blocker;
        private LinkLabel RepakLink;
        private Label label2;
    }
}