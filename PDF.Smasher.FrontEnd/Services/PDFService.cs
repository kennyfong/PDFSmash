using Microsoft.Extensions.Logging;
using PDF.Smasher.FrontEnd.Data;
using Serilog;
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
        private readonly ILogger<PDFService> _logger;

        public PDFService(ILogger<PDFService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<byte[]> RemoveCertFromPDF(BlazorInputFile.IFileListEntry file)
        {
            try
            {
                _logger.LogInformation("Removing Certificate from PDF");
                using (HttpClient client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
                {
                    client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("API_HOST"));

                    var ms = new MemoryStream();
                    await file.Data.CopyToAsync(ms);

                    ms.Seek(0, SeekOrigin.Begin);
                    var stream = new StreamContent(ms);

                    var response = await client.PostAsync("PDF", stream);
                    response.EnsureSuccessStatusCode();

                    using (var outputms = new MemoryStream())
                    {
                        await response.Content.CopyToAsync(outputms);
                        return outputms.ToArray();
                    }
                }
            }
            catch(HttpRequestException httpEx)
            {
                _logger.LogError(httpEx,"HTTP Exception occurred");
                throw;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Internal Exception occurred");
                throw;
            }
        }
    }
}
