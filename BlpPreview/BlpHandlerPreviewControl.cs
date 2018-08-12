using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpShell.SharpPreviewHandler;
using SereniaBLPLib;
using System.IO;
using SharpShell.Diagnostics;
using SharpShell.Interop;

namespace BlpPreview
{
    public partial class BlpHandlerPreviewControl : PreviewHandlerControl
    {
        public BlpHandlerPreviewControl()
        {
            InitializeComponent();
        }

        protected Bitmap OriginalImage = null;

        public void DoPreview(string selectedFilePath)
        {
            //  Load the icons.
            try
            {
                Logging.Log("Displaying preview 1");
                using (var stream = File.OpenRead(selectedFilePath))
                using (var blpFile = new BlpFile(stream))
                {
                    Logging.Log("Displaying preview 2");
                    OriginalImage = blpFile.GetBitmap(0);
                    pictureBox1.Image = OriginalImage;
                    label1.Text = string.Format("Size: {0}x{1} Compression: {2}", OriginalImage.Width, OriginalImage.Height, blpFile.Compression);
                    Logging.Log("Displaying preview 3");
                }

                /*
                using (var image = Blp2.FromFile(selectedFilePath))
                {
                    Logging.Log("Displaying preview 2");
                    OriginalImage = (Bitmap)image;
                    pictureBox1.Image = OriginalImage;
                    label1.Text = string.Format("Size: {0}x{1} Compression: {2}", OriginalImage.Width, OriginalImage.Height, image.Format);
                    Logging.Log("Displaying preview 3");
                }*/
            }
            catch (Exception ex)
            {
                //  Maybe we could show something to the user in the preview
                //  window, but for now we'll just ignore any exceptions.
                label1.Text = "Error: " + ex.Message;
                Logging.Error(ex.Message);
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Logging.Log("pictureBox1_DockChanged");
            if (OriginalImage == null)
                return;

            var needScale = false;
            var widthScale = -1.0;
            var heightScale = -1.0;
            if (OriginalImage.Width > pictureBox1.Width)
            {
                needScale = true;
                widthScale = (float)pictureBox1.Width / OriginalImage.Width;
            }
            if (OriginalImage.Width > pictureBox1.Width)
            {
                needScale = true;
                heightScale = (float)pictureBox1.Height / OriginalImage.Height;
            }

            if (!needScale)
                return;

            var scale = 1.0;
            if (widthScale < 0)
                scale = heightScale;
            else if (heightScale < 0)
                scale = widthScale;
            else
                scale = Math.Min(widthScale, heightScale);

            pictureBox1.Image = new Bitmap(OriginalImage, new Size((int)(OriginalImage.Width * scale), (int)(OriginalImage.Height * scale)));
        }
    }
}
