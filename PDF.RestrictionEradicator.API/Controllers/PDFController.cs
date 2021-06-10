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
    [ApiController]
    [Route("[controller]")]
    public class PDFController : ControllerBase
    {
        private readonly ILogger<PDFController> _logger;

        public PDFController(ILogger<PDFController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                _logger.LogInformation("Post request for PDF controller started");
                var stream = Request.Body;
                
                var outputStream = new MemoryStream();
                var writer = new PdfWriter(outputStream);
                writer.SetCloseStream(false);
                writer.SetSmartMode(false);
                PdfDocument pdfDoc = new PdfDocument(writer);
                PdfDocument srcDoc = new PdfDocument(new PdfReader(stream));
                srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdfDoc);

                srcDoc.Close();
                pdfDoc.Close();

                string mimeType = "application/pdf";
                outputStream.Position = 0;

                _logger.LogInformation("Post request for PDF controller finished");

                return new FileStreamResult(outputStream, mimeType);
            } catch(Exception ex)
            {

            }
            return StatusCode(500);
        }
    }
}
