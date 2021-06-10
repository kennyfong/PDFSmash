using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Smasher.FrontEnd.Data
{
    public class PDFDetails
    {
        public Stream src { get; set; }

        public Stream dest { get; set; }
    }
}
