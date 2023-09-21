using A3DPDF.Core.PDF.PDFWork.Merge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Telerik.Windows.Documents.FormatProviders.Pdf;
using iText.Kernel.Pdf;

namespace A3DPDF.Core.PDF.PDFWork.Merge.ViewModel
{
    public class MergePDF
    {
        private static MergePDF? mergePDF = null;


        public static MergePDF InstMergePDF
        {
            get
            {
                if (mergePDF == null)
                {
                    mergePDF = new MergePDF();
                }
                return mergePDF;
            }
        }
        public void AddFile(List<string> FileList, string MergerType)
        {
            try
            {
                List<FileDetails> _FileDetails = new();
                foreach (var FilePath in FileList)
                {
                    if (!File.Exists(FilePath))
                    {
                        PdfDocument pdfDoc = new PdfDocument(new PdfReader(FilePath));

                        int iMaxSeq = 0;
                        if (_FileDetails.Count > 0)
                        {
                            iMaxSeq = _FileDetails.Select(x => x.MergeSequence).Max();
                        }


                        FileDetails fileDetails = new()
                        {
                            Id = 0,
                            FileName = System.IO.Path.GetFileName(FilePath),
                            FilePath = FilePath,
                            FileType = "PDF",
                            PageCount = pdfDoc.GetNumberOfPages(),
                            MergeSequence = iMaxSeq + 1,
                            MergeType = MergerType
                        };
                        for (int i = 0; i < fileDetails.PageCount; i++)
                        {
                            fileDetails.FilePageDetails = new()
                            {
                                Id=0,
                                FileId = fileDetails.Id,
                                FileName=fileDetails.FileName,
                                PageNumber=i+1,
                                MergeSequence = i + 1,
                                IsRequired = true,
                            };


                        }
                        _FileDetails.Add(fileDetails);


                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
