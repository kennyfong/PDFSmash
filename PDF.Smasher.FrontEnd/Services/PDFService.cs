using PDF.Smasher.FrontEnd.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
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

        public async Task<byte[]> RemoveCertFromPDF(BlazorInputFile.IFileListEntry file)
        {
            try
            {
                using (HttpClient client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
                {
                    client.BaseAddress = new Uri(_config.BaseURL);

                    var ms = new MemoryStream();
                    await file.Data.CopyToAsync(ms);

                    ms.Seek(0, SeekOrigin.Begin);
                    var stream = new StreamContent(ms);

                    var response = await client.PostAsync("PDF", stream);
                    using (var outputms = new MemoryStream())
                    {
                        await response.Content.CopyToAsync(ms);
                        return ms.ToArray();
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
