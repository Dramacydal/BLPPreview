using SereniaBLPLib;
using SharpShell.Attributes;
using SharpShell.Diagnostics;
using SharpShell.SharpPreviewHandler;
using SharpShell.SharpThumbnailHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlpPreview
{
    /*[ComVisible(true)]
    [DisplayName("BLP Thumbnail")]
    [COMServerAssociation(AssociationType.FileExtension, ".blp")]
    public class BlpThumbnailHandler : SharpThumbnailHandler
    {
        public BlpThumbnailHandler()
        {
            Logging.Log(">>>>>>>>>>>. initialized");
        }

        protected override Bitmap GetThumbnailImage(uint width)
        {
            try
            {
                Log("Displaying thumbnail");
                Bitmap ret = null;
                using (var stream = File.OpenRead(SelectedFile))
                using (var blpFile = new BlpFile(stream))
                {
                    return blpFile.GetBitmap(0);
                    using (var bitmap = blpFile.GetBitmap(0))
                    {
                        ret = new Bitmap(bitmap, new Size((int)width, (int)width));
                    }
                }
                return ret;
            }
            catch(Exception ex)
            {
                LogError(ex.Message);
            }

            return null;
        }
    }*/
}
