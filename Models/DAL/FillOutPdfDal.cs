/*using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;*/

namespace IrsMonkeyApi.Models.DAL
{
    public class FillOutFormDal : IFillOutPdfDal
    {
        public bool FillOutPdf(string FormName)
        {
            /*try
            {
                var pdfFile = new MemoryStream();
                var reader = new PdfReader("/Users/gerardojaramillo/code/IrsMonkeyApi/IRSForms/f433a.pdf");
//                var pdfStamper = new PdfStamper(reader, pdfFile);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }*/
            return true;
        }
    }
}