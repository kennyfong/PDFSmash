using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Smasher.FrontEnd.Services
{
    public interface IPDFService
    {
        Task<byte[]> RemoveCertFromPDF(BlazorInputFile.IFileListEntry file);
    }
}
