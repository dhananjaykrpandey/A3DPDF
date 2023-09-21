using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3DPDF.Core.PDF.PDFWork.Merge.Models
{
    public class FilePageDetails
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int MergeSequence { get; set; }
        public bool IsRequired { get; set; } = true;
    }
}
