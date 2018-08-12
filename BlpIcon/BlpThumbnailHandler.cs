using SereniaBLPLib;
using SharpShell.Attributes;
using SharpShell.Diagnostics;
using SharpShell.SharpIconHandler;
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

namespace BlpIcon
{
    [ComVisible(true)]
    [DisplayName("BLP Icon")]
    [COMServerAssociation(AssociationType.FileExtension, ".blp")]
    public class BlpThumbnailHandler : SharpIconHandler
    {
        public BlpThumbnailHandler()
        {
        }

        protected override Icon GetIcon(bool smallIcon, uint iconSize)
        {
            if (!File.Exists(SelectedItemPath))
                return new Icon(SystemIcons.Exclamation, new Size((int)iconSize, (int)iconSize));

            using (var stream = File.OpenRead(SelectedItemPath))
            using (var blpFile = new BlpFile(stream))
            {
                using (var bitmap = blpFile.GetBitmap(0))
                {
                    return Icon.FromHandle(bitmap.GetHicon());
                }
            }
        }
    }
}
