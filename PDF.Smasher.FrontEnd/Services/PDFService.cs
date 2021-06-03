using PDF.Smasher.FrontEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PDF.Smasher.FrontEnd.Services
{
    public class PDFService : IPDFService
    {
        private readonly PDFServiceAPIConfiguration _config;

        public PDFService(PDFServiceAPIConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task RemoveCertFromPDF(BlazorInputFile.IFileListEntry files)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(_config.BaseURL)
            };

            //client
        }
    }
}
