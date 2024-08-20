namespace YT_Downloader
{
    partial class DownloadForm
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            yt_url_entry = new TextBox();
            status_label = new Label();
            download_button = new Button();
            progress_bar = new ProgressBar();
            SuspendLayout();
            // 
            // yt_url_entry
            // 
            yt_url_entry.Location = new Point(19, 11);
            yt_url_entry.Name = "yt_url_entry";
            yt_url_entry.PlaceholderText = "enter youtube video url here...";
            yt_url_entry.Size = new Size(353, 23);
            yt_url_entry.TabIndex = 0;
            yt_url_entry.TextChanged += yt_url_entry_text_changed;
            // 
            // status_label
            // 
            status_label.AutoSize = true;
            status_label.Location = new Point(19, 48);
            status_label.Name = "status_label";
            status_label.Size = new Size(162, 15);
            status_label.TabIndex = 1;
            status_label.Text = "enter yt url in the above entry";
            // 
            // download_button
            // 
            download_button.Location = new Point(19, 75);
            download_button.Name = "download_button";
            download_button.Size = new Size(73, 25);
            download_button.TabIndex = 2;
            download_button.Text = "Download";
            download_button.UseVisualStyleBackColor = true;
            download_button.Click += download_button_clicked;
            // 
            // progress_bar
            //
            progress_bar.Visible=false;
            progress_bar.Location = new Point(121, 75);
            progress_bar.Name = "progress_bar";
            progress_bar.Size = new Size(251, 25);
            progress_bar.TabIndex = 3;
            // 
            // DownloadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(399, 221);
            Controls.Add(progress_bar);
            Controls.Add(download_button);
            Controls.Add(status_label);
            Controls.Add(yt_url_entry);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DownloadForm";
            Text = "YouTube Video Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox yt_url_entry;
        private Label status_label;
        private Button download_button;
        private ProgressBar progress_bar;
    }
}
