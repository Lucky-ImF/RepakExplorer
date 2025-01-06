using System.Diagnostics;

namespace RepakExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string LoadedPakPath = "";
        string LoadedDirPath = "";

        List<string> FilesLoaded = new List<string>();
        int Depth = 0;

        private string GetSlice(string Txt, string Delimiter, int slice)
        {
            try
            {
                string[] TempArray = Txt.Split(Delimiter);
                return TempArray[slice].Trim();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private void DropSpot_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files[0].ToLower().EndsWith(".pak"))
            {
                LoadedPakPath = files[0];
                //Debug.WriteLine("LoadedPakPath: " + LoadedPakPath);
                Pak_ListFiles(LoadedPakPath);
                LoadedFilePath_Label.Text = LoadedPakPath;
            }
            else
            {
                LoadedDirPath = files[0];
                //Debug.WriteLine("LoadedDirPath: " + LoadedDirPath);
                Dir_ListFiles(LoadedDirPath);
                LoadedFilePath_Label.Text = LoadedDirPath;
            }
        }

        private void DropSpot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            DropSpot.BorderStyle = BorderStyle.Fixed3D;
        }

        private void DropSpot_DragLeave(object sender, EventArgs e)
        {
            DropSpot.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Dir_ListFiles(string DirPath)
        {
            FileExplorer_ListView.Items.Clear();
            FilesLoaded.Clear();
            Console_TB.Clear();
            Console_GB.Show();

            string[] files = Directory.GetFiles(DirPath, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string CleanPath = GetSlice(file, DirPath, 1).Remove(0, 1);
                CleanPath = CleanPath.Replace("\\", "/");
                FilesLoaded.Add(CleanPath);
                Debug.WriteLine(CleanPath);
                Console_TB.AppendText(CleanPath + "\n\r");
            }

            FileExplorer_GB.Show();
            DirActs_GB.Show();
            UpdateFilesList();
        }

        private void Pak_ListFiles(string PakPath)
        {
            // Clean up ListView
            FileExplorer_ListView.Items.Clear();
            FilesLoaded.Clear();
            Console_TB.Clear();
            Console_GB.Show();

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "repak.exe";
            p.StartInfo.Arguments = "list \"" + PakPath + "\"";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            string[] lines = output.Split("\n", StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    FilesLoaded.Add(line);
                    Console_TB.AppendText(line + "\n\r");
                }
            }
            lines = error.Split("\n", StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    Console_TB.AppendText("ERROR: " + line + "\n\r");
                }
            }
            p.Dispose();

            FileExplorer_GB.Show();
            PakActs_GB.Show();
            UpdateFilesList();
        }

        private void UpdateFilesList()
        {
            FileExplorer_ListView.Items.Clear();
            foreach (string file in FilesLoaded)
            {
                if (FileExplorer_PathLabel.Text == "Root")
                {
                    if (FileExplorer_ListView.Items.ContainsKey(GetSlice(file, "/", 0)) == false)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = GetSlice(file, "/", 0);
                        item.Name = item.Text;
                        string ext = Path.GetExtension(item.Text);
                        if (ext == ".uasset")
                        {
                            item.ImageIndex = 1;
                        }
                        else if (ext == ".uexp")
                        {
                            item.ImageIndex = 2;
                        }
                        else if (ext == ".ubulk")
                        {
                            item.ImageIndex = 3;
                        }
                        else
                        {
                            item.ImageIndex = 0;
                        }
                        FileExplorer_ListView.Items.Add(item);
                    }
                }
                else
                {
                    if (file.StartsWith(FileExplorer_PathLabel.Text))
                    {
                        if (FileExplorer_ListView.Items.ContainsKey(GetSlice(file, "/", Depth)) == false)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = GetSlice(file, "/", Depth);
                            item.Name = item.Text;
                            string ext = Path.GetExtension(item.Text);
                            if (ext == ".uasset")
                            {
                                item.ImageIndex = 1;
                            }
                            else if (ext == ".uexp")
                            {
                                item.ImageIndex = 2;
                            }
                            else if (ext == ".ubulk")
                            {
                                item.ImageIndex = 3;
                            }
                            else
                            {
                                item.ImageIndex = 0;
                            }
                            FileExplorer_ListView.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void FileExplorer_ListView_ItemActivate(object sender, EventArgs e)
        {
            if (FileExplorer_PathLabel.Text == "Root")
            {
                FileExplorer_PathLabel.Text = FileExplorer_ListView.SelectedItems[0].Text;
                Depth = 1;
            }
            else
            {
                FileExplorer_PathLabel.Text += "/" + FileExplorer_ListView.SelectedItems[0].Text;
                Depth++;
            }
            UpdateFilesList();
        }

        private void FileExplorer_GoToRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Depth = 0;
            FileExplorer_PathLabel.Text = "Root";
            UpdateFilesList();
        }

        private void FileExplorer_GoBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Depth == 1)
            {
                Depth = 0;
                FileExplorer_PathLabel.Text = "Root";
                UpdateFilesList();
            }
            else
            {
                Depth--;
                FileExplorer_PathLabel.Text = FileExplorer_PathLabel.Text.Substring(0, FileExplorer_PathLabel.Text.LastIndexOf("/"));
                UpdateFilesList();
            }
        }

        private void PakActs_Info_Click(object sender, EventArgs e)
        {
            Console_TB.Clear();
            Console_GB.Show();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "repak.exe";
            p.StartInfo.Arguments = "info \"" + LoadedPakPath + "\"";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            string[] lines = output.Split("\n", StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    Console_TB.AppendText(line + "\n\r");
                }
            }
            lines = error.Split("\n", StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    Console_TB.AppendText("ERROR: " + line + "\n\r");
                }
            }
            p.Dispose();
        }

        private void PakActs_ListHash_Click(object sender, EventArgs e)
        {
            Console_TB.Clear();
            Console_GB.Show();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "repak.exe";
            p.StartInfo.Arguments = "hash-list \"" + LoadedPakPath + "\"";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            string[] lines = output.Split("\n", StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    Console_TB.AppendText(line + "\n\r");
                }
            }
            lines = error.Split("\n", StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    Console_TB.AppendText("ERROR: " + line + "\n\r");
                }
            }
            p.Dispose();
        }

        private void PakActs_Unpack_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select a folder to unpack the pak file to.";
            folderBrowserDialog1.InitialDirectory = Path.GetDirectoryName(LoadedPakPath);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Console_TB.Clear();
                Console_GB.Show();
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.FileName = "repak.exe";
                p.StartInfo.Arguments = "unpack -v -o \"" + folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath) + "\" \"" + LoadedPakPath + "\"";
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                string[] lines = output.Split("\n", StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        Console_TB.AppendText(line + "\n\r");
                    }
                }
                lines = error.Split("\n", StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        Console_TB.AppendText("ERROR: " + line + "\n\r");
                    }
                }
                p.Dispose();

                Process.Start("explorer.exe", folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("repak.exe") == false)
            {
                MessageBox.Show("Missing repak.exe. Please download it from the Repak GitHub repository and place the .exe it in the same folder as this program.", "Repak Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Blocker.Show();
            }
        }

        private void DirActs_Unload_Click(object sender, EventArgs e)
        {
            Console_TB.Text = "Unloaded " + Path.GetFileName(LoadedDirPath) + ".";

            LoadedPakPath = "";
            LoadedDirPath = "";

            FilesLoaded.Clear();
            Depth = 0;
            FileExplorer_GB.Hide();
            PakActs_GB.Hide();
            DirActs_GB.Hide();
        }

        private void PakActs_Unload_Click(object sender, EventArgs e)
        {
            Console_TB.Text = "Unloaded " + Path.GetFileName(LoadedPakPath) + ".";

            LoadedPakPath = "";
            LoadedDirPath = "";

            FilesLoaded.Clear();
            Depth = 0;
            FileExplorer_GB.Hide();
            PakActs_GB.Hide();
            DirActs_GB.Hide();
        }

        private void DirActs_Package_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select a folder to save the .pak file to.";
            folderBrowserDialog1.InitialDirectory = Path.GetDirectoryName(LoadedDirPath);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Console_TB.Clear();
                Console_GB.Show();
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.FileName = "repak.exe";
                string FileName = Path.GetFileName(LoadedDirPath);
                if (DirActs_AppendP.Checked == true && FileName.EndsWith("_P") == false)
                {
                    FileName = FileName + "_P";
                }
                if (DirActs_Compression.Text != "None")
                {
                    p.StartInfo.Arguments = "pack -v --compression " + DirActs_Compression.Text + " \"" + LoadedDirPath + "\" \"" + folderBrowserDialog1.SelectedPath + @"\" + FileName + ".pak\"";
                }
                else
                {
                    p.StartInfo.Arguments = "pack -v \"" + LoadedDirPath + "\" \"" + folderBrowserDialog1.SelectedPath + @"\" + FileName + ".pak\"";
                }
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                string[] lines = output.Split("\n", StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        Console_TB.AppendText(line + "\n\r");
                    }
                }
                lines = error.Split("\n", StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        Console_TB.AppendText("ERROR: " + line + "\n\r");
                    }
                }
                p.Dispose();

                Process.Start("explorer.exe", folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath));
            }
        }

        private void RepakLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", RepakLink.Text);
        }
    }
}
