﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Smasher.API.Model
{
    public class PDFDetails
    {
        public string src { get; set; }

        public MemoryStream dest { get; set; }
    }
}
