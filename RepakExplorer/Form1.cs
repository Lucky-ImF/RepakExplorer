using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

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
            string ext = Path.GetExtension(files[0].ToLower());
            if (ext == ".pak")
            {
                LoadedPakPath = files[0];
                Pak_ListFiles(LoadedPakPath);
                LoadedFilePath_Label.Text = LoadedPakPath;
            }
            else if (ext == "")
            {
                LoadedDirPath = files[0];
                Dir_ListFiles(LoadedDirPath);
                LoadedFilePath_Label.Text = LoadedDirPath;
            }
            else
            {
                MessageBox.Show("Invalid file type. Please drop a .pak or a folder.", "Repak Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DropSpot.BorderStyle = BorderStyle.FixedSingle;
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
            FileExplorer_PathLabel.Text = "Root";

            string[] files = Directory.GetFiles(DirPath, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string CleanPath = GetSlice(file, DirPath, 1).Remove(0, 1);
                CleanPath = CleanPath.Replace("\\", "/");
                FilesLoaded.Add(CleanPath);
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
            FileExplorer_PathLabel.Text = "Root";

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "repak.exe";
            if (AESKey_TB.Text != "")
            {
                p.StartInfo.Arguments = "--aes-key " + AESKey_TB.Text + " list \"" + PakPath + "\"";
            }
            else
            {
                p.StartInfo.Arguments = "list \"" + PakPath + "\"";
            }
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            string[] lines = output.Split(new string[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                FilesLoaded.Add(line);
                Console_TB.AppendText(line + Environment.NewLine);
            }
            lines = error.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console_TB.AppendText("ERROR: " + line + Environment.NewLine);
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
                    FileExplorer_GoBack.Enabled = false;
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
                        else if (ext == "")
                        {
                            item.ImageIndex = 0;
                        }
                        else
                        {
                            item.ImageIndex = 4;
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
                            else if (ext == "")
                            {
                                item.ImageIndex = 0;
                            }
                            else
                            {
                                item.ImageIndex = 4;
                            }
                            FileExplorer_ListView.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void FileExplorer_ListView_ItemActivate(object sender, EventArgs e)
        {
            if (FileExplorer_ListView.SelectedItems[0].ImageIndex != 0 && LoadedPakPath != "")
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.FileName = "repak.exe";

                string Args = string.Empty;
                foreach (ListViewItem file in FileExplorer_ListView.SelectedItems)
                {
                    Args = FileExplorer_PathLabel.Text.Replace("/",@"\") + @"\" + FileExplorer_ListView.SelectedItems[0].Text;
                }

                p.StartInfo.Arguments = "get \"" + LoadedPakPath + "\" \"" + Args + "\"";
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();
                SelectedFile_Panel.Show();
                SelectedFile_Label.Text = FileExplorer_ListView.SelectedItems[0].Text + " | Size: " + GetFileSize(output.Length) + " (" + output.Length + " bytes)";
                Console_TB.AppendText(FileExplorer_ListView.SelectedItems[0].Text + " | Size: " + GetFileSize(output.Length) + " (" + output.Length + " bytes)" + Environment.NewLine);
                if (error != "")
                {
                    Console_TB.AppendText(error + Environment.NewLine);
                }
                return;
            }
            else if (FileExplorer_ListView.SelectedItems[0].ImageIndex != 0 && LoadedDirPath != "")
            {
                // Get size of file
                FileInfo info = new FileInfo(LoadedDirPath + @"\" + FileExplorer_PathLabel.Text.Replace("/", @"\") + @"\" + FileExplorer_ListView.SelectedItems[0].Text);
                SelectedFile_Panel.Show();
                SelectedFile_Label.Text = FileExplorer_ListView.SelectedItems[0].Text + " | Size: " + GetFileSize(info.Length) + " (" + info.Length + " bytes)";
                Console_TB.AppendText(FileExplorer_ListView.SelectedItems[0].Text + " | Size: " + GetFileSize(info.Length) + " (" + info.Length + " bytes)" + Environment.NewLine);
                return;
            }
            if (FileExplorer_PathLabel.Text == "Root")
            {
                FileExplorer_PathLabel.Text = FileExplorer_ListView.SelectedItems[0].Text;
                Depth = 1;
                FileExplorer_GoBack.Enabled = true;
            }
            else
            {
                FileExplorer_PathLabel.Text += "/" + FileExplorer_ListView.SelectedItems[0].Text;
                Depth++;
                FileExplorer_GoBack.Enabled = true;
            }
            UpdateFilesList();
        }

        private string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";

            return size;
        }

        private void FileExplorer_GoToRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Depth = 0;
            FileExplorer_PathLabel.Text = "Root";
            UpdateFilesList();
            FileExplorer_GoBack.Enabled = false;
        }

        private void FileExplorer_GoBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Depth == 1)
            {
                Depth = 0;
                FileExplorer_PathLabel.Text = "Root";
                FileExplorer_GoBack.Enabled = false;
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
            if (AESKey_TB.Text != "")
            {
                p.StartInfo.Arguments = "--aes-key " + AESKey_TB.Text + " info \"" + LoadedPakPath + "\"";
            }
            else
            {
                p.StartInfo.Arguments = "info \"" + LoadedPakPath + "\"";
            }
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            string[] lines = output.Split(new string[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console_TB.AppendText(line + Environment.NewLine);
            }
            lines = error.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console_TB.AppendText("ERROR: " + line + Environment.NewLine);
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
            if (AESKey_TB.Text != "")
            {
                p.StartInfo.Arguments = "--aes-key " + AESKey_TB.Text + " hash-list \"" + LoadedPakPath + "\"";
            }
            else
            {
                p.StartInfo.Arguments = "hash-list \"" + LoadedPakPath + "\"";
            }
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            string[] lines = output.Split(new string[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console_TB.AppendText(line + Environment.NewLine);
            }
            lines = error.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console_TB.AppendText("ERROR: " + line + Environment.NewLine);
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
                if (AESKey_TB.Text != "")
                {
                    p.StartInfo.Arguments = "--aes-key " + AESKey_TB.Text + " unpack -v -o \"" + folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath) + "\" \"" + LoadedPakPath + "\"";
                }
                else
                {
                    p.StartInfo.Arguments = "unpack -v -o \"" + folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath) + "\" \"" + LoadedPakPath + "\"";
                }
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                string[] lines = output.Split(new string[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    Console_TB.AppendText(line + Environment.NewLine);
                }
                lines = error.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    Console_TB.AppendText("ERROR: " + line + Environment.NewLine);
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
            SelectedFile_Panel.Hide();

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
            SelectedFile_Panel.Hide();

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

                string Args = string.Empty;
                string MountPoint = string.Empty;
                if (DirActs_MountPoint.Text != "../../../")
                {
                    MountPoint = "--mount-point " + DirActs_MountPoint.Text;
                    Args += MountPoint + " ";
                }
                string Compression = string.Empty;
                if (DirActs_Compression.Text != "None")
                {
                    Compression = "--compression " + DirActs_Compression.Text;
                    Args += Compression + " ";
                }
                string Version = string.Empty;
                if (DirActs_Version.Text != "V8B")
                {
                    Version = "--version " + DirActs_Version.Text;
                    Args += Version + " ";
                }

                if (Args != string.Empty)
                {
                    Console_TB.AppendText("Packing with arguments: " + Args + Environment.NewLine);
                    p.StartInfo.Arguments = "pack -v " + Args + "\"" + LoadedDirPath + "\" \"" + folderBrowserDialog1.SelectedPath + @"\" + FileName + ".pak\"";
                }
                else
                {
                    Console_TB.AppendText("Packing with default arguments." + Environment.NewLine);
                    p.StartInfo.Arguments = "pack -v \"" + LoadedDirPath + "\" \"" + folderBrowserDialog1.SelectedPath + @"\" + FileName + ".pak\"";
                }
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                string[] lines = output.Split(new string[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    Console_TB.AppendText(line + Environment.NewLine);
                }
                lines = error.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    Console_TB.AppendText("ERROR: " + line + Environment.NewLine);
                }
                p.Dispose();

                Process.Start("explorer.exe", folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath));
            }
        }

        private void RepakLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", RepakLink.Text);
        }

        private void PakActs_UnpackSelected_Click(object sender, EventArgs e)
        {
            if (FileExplorer_ListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No files/folders selected.", "Repak Explorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            folderBrowserDialog1.Description = "Select a folder to unpack the selected files to.";
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

                string Args = string.Empty;
                foreach (ListViewItem file in FileExplorer_ListView.SelectedItems)
                {
                    Args += "-i \"" + FileExplorer_PathLabel.Text + "/" + file.Text + "\" ";
                }

                p.StartInfo.Arguments = "unpack -v " + Args + "-o \"" + folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath) + "\" \"" + LoadedPakPath + "\"";
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                string[] lines = output.Split(new string[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    Console_TB.AppendText(line + Environment.NewLine);
                }
                lines = error.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    Console_TB.AppendText("ERROR: " + line + Environment.NewLine);
                }
                p.Dispose();

                Process.Start("explorer.exe", folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileNameWithoutExtension(LoadedPakPath));
            }
        }
    }
}
