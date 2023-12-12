namespace convert_image_from_hackmd
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
            button_convert = new Button();
            richTextBox_console = new RichTextBox();
            label1 = new Label();
            textBox_local_folder = new TextBox();
            label2 = new Label();
            textBox_remoteURL = new TextBox();
            button_stop = new Button();
            checkBox_replace_name = new CheckBox();
            progressBar1 = new ProgressBar();
            radioButton_markdown = new RadioButton();
            radioButton_html = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button_convert
            // 
            button_convert.Location = new Point(12, 14);
            button_convert.Name = "button_convert";
            button_convert.Size = new Size(117, 36);
            button_convert.TabIndex = 0;
            button_convert.Text = "Convert";
            button_convert.UseVisualStyleBackColor = true;
            button_convert.Click += button_convert_Click;
            // 
            // richTextBox_console
            // 
            richTextBox_console.Location = new Point(12, 254);
            richTextBox_console.Name = "richTextBox_console";
            richTextBox_console.Size = new Size(548, 304);
            richTextBox_console.TabIndex = 1;
            richTextBox_console.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 53);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 2;
            label1.Text = "Local folder name";
            // 
            // textBox_local_folder
            // 
            textBox_local_folder.Location = new Point(146, 67);
            textBox_local_folder.Name = "textBox_local_folder";
            textBox_local_folder.Size = new Size(181, 23);
            textBox_local_folder.TabIndex = 3;
            textBox_local_folder.Text = "img";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 9);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "Remote URL";
            // 
            // textBox_remoteURL
            // 
            textBox_remoteURL.Location = new Point(146, 27);
            textBox_remoteURL.Name = "textBox_remoteURL";
            textBox_remoteURL.Size = new Size(414, 23);
            textBox_remoteURL.TabIndex = 5;
            textBox_remoteURL.Text = "https://i.imgur.com/";
            // 
            // button_stop
            // 
            button_stop.Location = new Point(15, 61);
            button_stop.Name = "button_stop";
            button_stop.Size = new Size(114, 33);
            button_stop.TabIndex = 6;
            button_stop.Text = "Stop";
            button_stop.UseVisualStyleBackColor = true;
            button_stop.Click += button_stop_Click;
            // 
            // checkBox_replace_name
            // 
            checkBox_replace_name.AutoSize = true;
            checkBox_replace_name.Checked = true;
            checkBox_replace_name.CheckState = CheckState.Checked;
            checkBox_replace_name.Location = new Point(337, 69);
            checkBox_replace_name.Name = "checkBox_replace_name";
            checkBox_replace_name.Size = new Size(189, 19);
            checkBox_replace_name.TabIndex = 7;
            checkBox_replace_name.Text = "Replace URL with local name";
            checkBox_replace_name.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 225);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(541, 23);
            progressBar1.TabIndex = 8;
            // 
            // radioButton_markdown
            // 
            radioButton_markdown.AutoSize = true;
            radioButton_markdown.Location = new Point(6, 22);
            radioButton_markdown.Name = "radioButton_markdown";
            radioButton_markdown.Size = new Size(87, 19);
            radioButton_markdown.TabIndex = 0;
            radioButton_markdown.Text = "MarkDown";
            radioButton_markdown.UseVisualStyleBackColor = true;
            // 
            // radioButton_html
            // 
            radioButton_html.AutoSize = true;
            radioButton_html.Checked = true;
            radioButton_html.Location = new Point(6, 47);
            radioButton_html.Name = "radioButton_html";
            radioButton_html.Size = new Size(59, 19);
            radioButton_html.TabIndex = 0;
            radioButton_html.TabStop = true;
            radioButton_html.Text = "HTML";
            radioButton_html.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton_markdown);
            groupBox1.Controls.Add(radioButton_html);
            groupBox1.Location = new Point(17, 110);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(112, 73);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Type";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 593);
            Controls.Add(groupBox1);
            Controls.Add(progressBar1);
            Controls.Add(checkBox_replace_name);
            Controls.Add(button_stop);
            Controls.Add(textBox_remoteURL);
            Controls.Add(label2);
            Controls.Add(textBox_local_folder);
            Controls.Add(label1);
            Controls.Add(richTextBox_console);
            Controls.Add(button_convert);
            Name = "Form1";
            Text = "Hackmd converter";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_convert;
        private RichTextBox richTextBox_console;
        private Label label1;
        private TextBox textBox_local_folder;
        private Label label2;
        private TextBox textBox_remoteURL;
        private Button button_stop;
        private CheckBox checkBox_replace_name;
        private ProgressBar progressBar1;
        private GroupBox Type;
        private RadioButton radioButton_html;
        private RadioButton radioButton_markdown;
        private GroupBox groupBox1;
    }
}