using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.IO;
using Microsoft.JSInterop;

namespace GaHealthcareNurses.Client.Helper
{
    public class ExportPdfService
    {
        private readonly IJSRuntime js;

        public ExportPdfService(IJSRuntime js)
        {
            this.js = js;
        }
        public async ValueTask SaveAs(string filename, byte[] data)
        {
            await js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
        }
            
    }
}
