using SharpShell.Attributes;
using SharpShell.SharpPreviewHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlpPreview
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.FileExtension, ".blp")]
    [DisplayName("BLP Preview")]
    [PreviewHandler]
    public class BlpPreviewHandler : SharpPreviewHandler
    {
        protected override PreviewHandlerControl DoPreview()
        {
            var handler = new BlpHandlerPreviewControl();

            if (!string.IsNullOrEmpty(SelectedFilePath) && File.Exists(SelectedFilePath))
                handler.DoPreview(SelectedFilePath);

            return handler;
        }
    }
}
