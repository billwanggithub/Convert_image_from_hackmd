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
            this.button_convert = new System.Windows.Forms.Button();
            this.richTextBox_console = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_convert
            // 
            this.button_convert.Location = new System.Drawing.Point(28, 30);
            this.button_convert.Name = "button_convert";
            this.button_convert.Size = new System.Drawing.Size(75, 23);
            this.button_convert.TabIndex = 0;
            this.button_convert.Text = "Convert";
            this.button_convert.UseVisualStyleBackColor = true;
            this.button_convert.Click += new System.EventHandler(this.button_convert_Click);
            // 
            // richTextBox_console
            // 
            this.richTextBox_console.Location = new System.Drawing.Point(109, 30);
            this.richTextBox_console.Name = "richTextBox_console";
            this.richTextBox_console.Size = new System.Drawing.Size(548, 401);
            this.richTextBox_console.TabIndex = 1;
            this.richTextBox_console.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 450);
            this.Controls.Add(this.richTextBox_console);
            this.Controls.Add(this.button_convert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_convert;
        private RichTextBox richTextBox_console;
    }
}