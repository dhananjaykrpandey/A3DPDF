namespace A3DPDF.Core.PDF.PDFWork.Merge.Models
{
    public class FileDetails
    {
        public FileDetails()
        {
            FilePageDetails = new FilePageDetails();
        }
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string MergeType { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public int PageCount { get; set; } = 0;
        public int MergeSequence { get; set; } = 0;

        public FilePageDetails FilePageDetails { get; set; }
    }
}
