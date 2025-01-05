namespace RepakExplorer
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
            ListViewItem listViewItem2 = new ListViewItem("WildLifeC", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            FileExplorer_GB = new GroupBox();
            FileExplorer_ListView = new ListView();
            imageList1 = new ImageList(components);
            FileExplorer_PathLabel = new Label();
            DropLabel = new Label();
            DropSpot = new Panel();
            FileExplorer_GB.SuspendLayout();
            SuspendLayout();
            // 
            // FileExplorer_GB
            // 
            FileExplorer_GB.Controls.Add(FileExplorer_PathLabel);
            FileExplorer_GB.Controls.Add(FileExplorer_ListView);
            FileExplorer_GB.ForeColor = Color.Orange;
            FileExplorer_GB.Location = new Point(11, 244);
            FileExplorer_GB.Name = "FileExplorer_GB";
            FileExplorer_GB.Size = new Size(778, 287);
            FileExplorer_GB.TabIndex = 0;
            FileExplorer_GB.TabStop = false;
            FileExplorer_GB.Text = "File Explorer";
            // 
            // FileExplorer_ListView
            // 
            FileExplorer_ListView.BackColor = Color.FromArgb(64, 64, 64);
            FileExplorer_ListView.BorderStyle = BorderStyle.FixedSingle;
            FileExplorer_ListView.ForeColor = Color.Orange;
            FileExplorer_ListView.Items.AddRange(new ListViewItem[] { listViewItem2 });
            FileExplorer_ListView.LabelWrap = false;
            FileExplorer_ListView.LargeImageList = imageList1;
            FileExplorer_ListView.Location = new Point(6, 37);
            FileExplorer_ListView.Name = "FileExplorer_ListView";
            FileExplorer_ListView.Size = new Size(766, 243);
            FileExplorer_ListView.TabIndex = 0;
            FileExplorer_ListView.TileSize = new Size(64, 64);
            FileExplorer_ListView.UseCompatibleStateImageBehavior = false;
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
            // FileExplorer_PathLabel
            // 
            FileExplorer_PathLabel.AutoSize = true;
            FileExplorer_PathLabel.Location = new Point(9, 19);
            FileExplorer_PathLabel.Name = "FileExplorer_PathLabel";
            FileExplorer_PathLabel.Size = new Size(58, 15);
            FileExplorer_PathLabel.TabIndex = 1;
            FileExplorer_PathLabel.Text = "WildLifeC";
            // 
            // DropLabel
            // 
            DropLabel.AutoSize = true;
            DropLabel.BackColor = Color.Transparent;
            DropLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DropLabel.ForeColor = Color.Orange;
            DropLabel.Location = new Point(312, 220);
            DropLabel.Name = "DropLabel";
            DropLabel.Size = new Size(176, 21);
            DropLabel.TabIndex = 2;
            DropLabel.Text = "Drop .pak or folder here";
            // 
            // DropSpot
            // 
            DropSpot.AllowDrop = true;
            DropSpot.BackgroundImage = Properties.Resources.DragDrop_Icon;
            DropSpot.BackgroundImageLayout = ImageLayout.Zoom;
            DropSpot.Location = new Point(300, 17);
            DropSpot.Name = "DropSpot";
            DropSpot.Size = new Size(200, 200);
            DropSpot.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 588);
            Controls.Add(DropLabel);
            Controls.Add(DropSpot);
            Controls.Add(FileExplorer_GB);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Repak Explorer";
            FileExplorer_GB.ResumeLayout(false);
            FileExplorer_GB.PerformLayout();
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
    }
}
