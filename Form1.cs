//using System.Windows.Storage;
//using System.Windows.Web.Http;

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace convert_image_from_hackmd
{
    public partial class Form1 : Form
    {
        bool enable = true;
        public Form1()
        {
            InitializeComponent();
        }

        // https://stackoverflow.com/questions/26958829/how-do-i-use-the-new-httpclient-from-windows-web-http-to-download-an-image
        private async void button_convert_Click(object sender, EventArgs e)
        {
            button_convert.Enabled = false;
            await ConvertFile();
            enable = true;
            button_convert.Enabled = true;
        }

        private async Task ConvertFile()
        {
            string? sourcePath = string.Empty;
            string? sourceFolderName = string.Empty;
            Uri uri;

            // get the source file name
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                if (radioButton_markdown.Checked)
                {
                    openFileDialog.Filter = "All files (*.*)|*.*|markdown files(*.md)|*.md";
                }
                else
                {
                    openFileDialog.Filter = "All files (*.*)|*.*|HTML files(*.html)|*.html";
                }
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select source file";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (openFileDialog.FileName == null)
                    return;

                //Get the path of specified file
                sourcePath = openFileDialog.FileName;
                sourceFolderName = Path.GetDirectoryName(sourcePath);
                if (sourceFolderName == null)
                    return;
            }

            // Displays a SaveFileDialog so the user can save the Image
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = sourceFolderName;
            saveFileDialog1.FileName = Path.GetFileName(sourcePath);
            if (radioButton_markdown.Checked)
            {
                saveFileDialog1.Filter = "Markfile|*.md";
            }
            else
            {
                saveFileDialog1.Filter = "HTML|*.html";
            }

            saveFileDialog1.Title = "Save to new file";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            // parse destination filename
            string destinationFilePath = saveFileDialog1.FileName;
            string? destination_folder = Path.GetDirectoryName(destinationFilePath);
            if (destination_folder == null)
            {
                return;
            }
            string? destinationImageFolderName = Path.Combine(destination_folder, textBox_local_folder.Text);


            // Load file content
            string content = File.ReadAllText(sourcePath);
            string newContent = content;

            // Replace url and save to new md file
            if (checkBox_replace_name.Checked)
            {
                if (radioButton_markdown.Checked)
                {
                    newContent = content.Replace(textBox_remoteURL.Text, $"./{textBox_local_folder.Text}/");
                }
                else
                {
                    //  "https://i.imgur.com/fnBMmBt.png"  to "./img/j8vmImd.png./img/j8vmImd.png"
                    newContent = content.Replace(textBox_remoteURL.Text, $"./{textBox_local_folder.Text}/");
                }
            }
            AppendConsole(richTextBox_console, $"Write  {destinationFilePath}\n");
            File.WriteAllText(destinationFilePath, newContent);

            // find image file name
            string imageUrl = "";
            int index = 0;
            string header = textBox_remoteURL.Text;
            string footer = @".png";

            List<string> imageFileNameList = new List<string>();

            //https://stackoverflow.com/questions/5066517/regex-starts-with-and-ending-with
            string pattern = @"(?<=https:\/\/i\.imgur\.com\/)(.*?)(?=\.png)";
            RegexOptions options = RegexOptions.Multiline;
            foreach (Match m in Regex.Matches(content, pattern, options))
            {
                AppendConsole(richTextBox_console, $"'{m.Value}' found at index {m.Index}\n");
                imageFileNameList.Add(m.Value);
            }

            //string[] string_split = content.Split(header, StringSplitOptions.None);
            //AppendConsole(richTextBox_console, $"Convert {string_split.Count() - 1} image files\n\n");

            progressBar1.Maximum = imageFileNameList.Count - 1;

            // Download images
            foreach (string imageFileName in imageFileNameList)
            {
                if (!enable)
                    break;

                progressBar1.Value = index;

                // skip first index
                //if (index == 0)
                //{
                //    index += 1;
                //    continue;
                //}

                imageUrl = header + imageFileName + footer;

                // download url image to local folder
                uri = new Uri(imageUrl);
                AppendConsole(richTextBox_console, $"index = {index} , Save {imageUrl} to {destinationImageFolderName + imageFileName + footer}\n");
                await DownloadImageAsync(destinationImageFolderName, imageFileName, uri);
                index += 1;
            }
            AppendConsole(richTextBox_console, "Done\n");
            Process.Start("explorer.exe", destination_folder);
        }

        // https://stackoverflow.com/questions/24797485/how-to-download-image-from-url
        private async Task DownloadImageAsync(string directoryPath, string fileName, Uri uri)
        {
            using var httpClient = new HttpClient();

            // Get the file extension
            var uriWithoutQuery = uri.GetLeftPart(UriPartial.Path);
            var fileExtension = Path.GetExtension(uriWithoutQuery);

            // Create file path and ensure directory exists
            var path = Path.Combine(directoryPath, $"{fileName}{fileExtension}");
            Directory.CreateDirectory(directoryPath);

            // Download the image and write to the file
            var imageBytes = await httpClient.GetByteArrayAsync(uri);
            await File.WriteAllBytesAsync(path, imageBytes);
        }

        void AppendConsole(RichTextBox richtextbox, string message)
        {

            if (richtextbox.InvokeRequired)
            {
                richtextbox.BeginInvoke((MethodInvoker)delegate ()
                {
                    richtextbox.Text += message;
                    // set the current caret position to the end
                    richtextbox.SelectionStart = richtextbox.Text.Length;
                    // scroll it automatically
                    richtextbox.ScrollToCaret();
                    richTextBox_console.Update();
                });
            }
            else
            {
                richtextbox.Text += message;
                // set the current caret position to the end
                richtextbox.SelectionStart = richtextbox.Text.Length;
                // scroll it automatically
                richtextbox.ScrollToCaret();
                richTextBox_console.Update();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            enable = false;
        }
    }
}