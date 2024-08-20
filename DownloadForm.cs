using VideoLibrary;

namespace YT_Downloader
{
    public partial class DownloadForm : Form
    {
        public DownloadHandler downloadHandler;

        public DownloadForm()
        {
            InitializeComponent();
            downloadHandler = new DownloadHandler(this);
        }

        private void yt_url_entry_text_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(yt_url_entry.Text))
            {
                status_label.Text = "Enter a YouTube link in the above entry...";
            }
            else
            {
                status_label.Text = yt_url_entry.Text;
            }
        }

        private void download_button_clicked(object sender, EventArgs e)
        {
            string yt_link_final = yt_url_entry.Text.Trim();
            if (yt_link_final.StartsWith("https://www.youtube.com/watch?v="))
            {
                progress_bar.Visible = true;
                progress_bar.Value = 0;
                progress_bar.Style = ProgressBarStyle.Marquee;
                downloadHandler.DownloadVideo(yt_link_final);
            }
            else
            {
                MessageBox.Show("Error! URL is not valid");
            }
        }

        public void UpdateProgress(int progress)
        {
            if (progress_bar.InvokeRequired)
            {
                progress_bar.Invoke(new Action<int>(UpdateProgress), progress);
            }
            else
            {
                progress_bar.Value = progress;
            }
        }

        public void SetIndeterminateProgress()
        {
            if (progress_bar.InvokeRequired)
            {
                progress_bar.Invoke(new Action(SetIndeterminateProgress));
            }
            else
            {
                progress_bar.Style = ProgressBarStyle.Marquee;
            }
        }

        public void CompleteProgress()
        {
            if (progress_bar.InvokeRequired)
            {
                progress_bar.Invoke(new Action(CompleteProgress));
            }
            else
            {
                progress_bar.Style = ProgressBarStyle.Blocks;
                progress_bar.Value = 100;
                MessageBox.Show("Download completed successfully!");
                progress_bar.Visible = false;
            }
        }
    }

    public class DownloadHandler
    {
        private readonly DownloadForm _form;

        public DownloadHandler(DownloadForm form)
        {
            _form = form;
        }

        public void DownloadVideo(string yt_url)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _form.SetIndeterminateProgress();
            });

            try
            {
                var youTube = YouTube.Default;
                var video = youTube.GetVideo(yt_url);

                byte[] videoBytes = video.GetBytes();
                int totalSize = videoBytes.Length;
                int chunkSize = 1024 * 10;
                int progress = 0;

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "MP4 Files (*.mp4)|*.mp4|All Files (*.*)|*.*";
                    saveFileDialog.Title = "Save Video As";
                    saveFileDialog.FileName = video.Title + ".mp4";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            int offset = 0;
                            while (offset < totalSize)
                            {
                                int bytesToWrite = Math.Min(chunkSize, totalSize - offset);
                                fs.Write(videoBytes, offset, bytesToWrite);
                                offset += bytesToWrite;

                                progress = (int)((offset / (float)totalSize) * 100);
                                _form.UpdateProgress(progress);
                            }

                            _form.CompleteProgress();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                });
            }
        }
    }
}


