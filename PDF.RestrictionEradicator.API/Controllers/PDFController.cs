using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iText.Forms;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PDF.Smasher.API.Model;

namespace PDF.Smasher.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PDFController : ControllerBase
    {
        private const string DEST = @"C:\Users\kfong\Downloads\12001950098_6902274.PDF";

        public const String SRC = @"C:\Users\kfong\Downloads\2001950098_6902274.PDF";

        private readonly ILogger<PDFController> _logger;

        public PDFController(ILogger<PDFController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<StatusCodeResult> Get(string src, string dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest).SetSmartMode(true));
            PdfDocument srcDoc = new PdfDocument(new PdfReader(src));
            srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdfDoc);

            srcDoc.Close();
            pdfDoc.Close();

            return Ok();
        }

        [HttpPost]
        public async Task<StatusCodeResult> Post(PDFFlattenRequest pdfObject)
        {
            foreach (var pdf in pdfObject.PDFRequest)
            {
                var workStream = new MemoryStream();

                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(workStream).SetSmartMode(true));
                PdfDocument srcDoc = new PdfDocument(new PdfReader(pdf.src));
                srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdfDoc);

                //PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC), new PdfWriter(DEST));
                //PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);

                //// If no fields have been explicitly included, then all fields are flattened.
                //// Otherwise only the included fields are flattened.
                //form.FlattenFields();
                
                workStream.Seek(0, SeekOrigin.Begin);

                pdf.dest = workStream;

                srcDoc.Close();
                pdfDoc.Close();
            }

            return Ok();
        }

    }
}
