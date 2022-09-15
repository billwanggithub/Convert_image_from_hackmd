//using System.Windows.Storage;
//using System.Windows.Web.Http;

using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace convert_image_from_hackmd
{
    public partial class Form1 : Form
    {
        string fn = "D:\\github\\GMT_Motor_Testkit_F411\\docs\\app\\GMT_Motor_Testkit_User_Manual.md";
        public Form1()
        {
            InitializeComponent();
        }

        // https://stackoverflow.com/questions/26958829/how-do-i-use-the-new-httpclient-from-windows-web-http-to-download-an-image
        private async void button_convert_Click(object sender, EventArgs e)
        {
            button_convert.Enabled = false;
            await ConvertMarkdowmFile();
            button_convert.Enabled = true;
        }

        private async Task ConvertMarkdowmFile()
        {
            string? filePath = string.Empty;
            string? folderName = string.Empty;
            string? imageFolderName = string.Empty;
            Uri uri;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "markdown files (*.md)|*.md|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    folderName = Path.GetDirectoryName(filePath);
                    if (folderName == null)
                        return;
                    imageFolderName = Path.Combine(folderName, "img");
                    ////Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }

            // Load file to string
            string content = File.ReadAllText(filePath);
            string newContent = content;

            // search "![](" to extract image path
            string header = @"https://i.imgur.com/";
            string footer = @".png";
            string[] string_split = content.Split(header, StringSplitOptions.None);

            string fileName = "";
            string imageUrl = "";
            int index = 0;
            AppendConsole(richTextBox_console, $"Convert {string_split.Count() - 1} image files\n\n");

            foreach (string line in string_split)
            {
                // skip first index
                if (index == 0)
                {
                    index += 1;
                    continue;
                }
                int pos = line.IndexOf(footer);

                fileName = line.Substring(0, pos);
                imageUrl = header + fileName + footer;

                // reade url image
                uri = new Uri(imageUrl);
                //string savedfileName = $"image_{index}";
                string savedfileName = fileName;
                AppendConsole(richTextBox_console, $"index = {index} , Save {imageUrl} to {savedfileName}\n");
                await DownloadImageAsync(imageFolderName, savedfileName, uri);
                index += 1;
            }
            AppendConsole(richTextBox_console, "Done\n");

            string newFilePath = Path.ChangeExtension(filePath, null)+ "_new";
            string extName = Path.GetExtension(filePath);
            newContent = content.Replace(header, @"img/");
            newFilePath = newFilePath + extName;
            File.WriteAllText(newFilePath, newContent);
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
    }
}