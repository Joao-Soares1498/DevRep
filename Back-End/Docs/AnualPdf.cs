using CCA_BE.Excel;
using CCA_BE.Models;
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion.Options.Load;

namespace CCA_BE.Docs
{
    //class responsible for pdf creation
    public class AnualPdf
    {
        //converts excel to Pdf
        public static async Task ConvertExcelToPdf(string fileId, string fileName)
        {

            //create excelFilePath
            string filePath = "..\\..\\Files\\"
                + fileId + "\\"
                + fileName + "\\"
                + "AnexoII_GAN_" + fileId + "_" + fileName;

            string excelFilePath = filePath + ".xlsx";
            string pdfFilePath = filePath + ".pdf";


            //set options of the load
            Func<LoadOptions> loadOptions = () => new SpreadsheetLoadOptions
            {
                OnePagePerSheet = true
            };

            //converts using group docs nuget package (trial version)
            using (var converter = new GroupDocs.Conversion.Converter(excelFilePath, loadOptions))
            {
                // Convert and save the spreadsheet in PDF format
                converter.Convert(pdfFilePath, new PdfConvertOptions());
            }

        }

    }

}
