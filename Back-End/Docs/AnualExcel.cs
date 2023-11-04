using OfficeOpenXml;
using CCA_BE.Models;
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion.Options.Load;

namespace CCA_BE.Excel
{
    //class responsible of all functions related to excel
    public class AnualExcel
    {
        //write excel
        public static async Task WriteExcel(AnualExcelModel obj)
        {
            //license context of OfficeOpenXml
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //path to model excel model file
            var modelFile = new FileInfo(fileName: @"..\..\Files\Models\Anexo-II-Grelha-de-Avaliacao-Anual.xlsx");

            //verify if there is a folder associated to that teacher and the current evaluation
            var newPath = VerifyOrCreateFolder(obj.nameid);

            //save the new excel
            var fileToConvert = SaveExcelFile(obj, modelFile,newPath);


        }

        //verify if path already exists
        public static string VerifyOrCreateFolder(string folderName)
        {
            //path to folder
            string path = Path.Combine(@"..\..\Files", folderName);

            //if it doesnt exist create one
            if (!Directory.Exists(path))
            {
                Console.WriteLine("nao existe");
                //Directory.CreateDirectory(path);
            }
            else
            {
                Console.WriteLine("existe");
            }

            return path;
           
        }

        //saves info from front end in a excel file
        private static string SaveExcelFile(AnualExcelModel obj, FileInfo modelFile, string newPath)
        {
            
            //new file name
            string newFileName = "AnexoII_GAN_" + obj.nameid + "_" + obj.fileName + modelFile.Extension;
            //new folder path
            newPath = newPath +"\\" + obj.fileName;
            //create directory
            Directory.CreateDirectory(newPath);

            // new file path
            string newFilePath = Path.Combine(newPath , newFileName);

            //file info
            var newFile = new FileInfo(newFilePath);

            //delete the file if already exists
            DeleteIfExists(newFile);

            //copies the structure of model file to new file
            modelFile.CopyTo(newFilePath);

            using var package = new ExcelPackage(newFile);

            //set the worksheet
            var ws = package.Workbook.Worksheets["Anexo II"];

            //fills cells
            ws.Cells["F3:G3"].Value = obj.F3G3;
            ws.Cells["K4:K4"].Value = obj.K4K4;
            ws.Cells["L4:L4"].Value = obj.L4L4;
            ws.Cells["M4:M4"].Value = obj.M4M4;
            ws.Cells["L11:L11"].Value = obj.L11L11;
            ws.Cells["L12:L12"].Value = obj.L12L12;
            ws.Cells["L13:L13"].Value = obj.L13L13;
            ws.Cells["L14:L14"].Value = obj.L14L14;
            ws.Cells["L15:L15"].Value = obj.L15L15;
            ws.Cells["L16:L16"].Value = obj.L16L16;
            ws.Cells["L17:L17"].Value = obj.L17L17;
            ws.Cells["L18:L18"].Value = obj.L18L18;
            ws.Cells["L19:L19"].Value = obj.L19L19;
            ws.Cells["L20:L20"].Value = obj.L20L20;
            ws.Cells["L21:L21"].Value = obj.L21L21;
            ws.Cells["L22:L22"].Value = obj.L22L22;
            ws.Cells["L23:L23"].Value = obj.L23L23;
            ws.Cells["L24:L24"].Value = obj.L24L24;
            ws.Cells["L25:L25"].Value = obj.L25L25;
            ws.Cells["L26:L26"].Value = obj.L26L26;
            ws.Cells["L27:L27"].Value = obj.L27L27;
            ws.Cells["L28:L28"].Value = obj.L28L28;
            ws.Cells["L29:L29"].Value = obj.L29L29;
            ws.Cells["L30:L30"].Value = obj.L30L30;
            ws.Cells["L31:L31"].Value = obj.L31L31;
            ws.Cells["L32:L32"].Value = obj.L32L32;
            ws.Cells["L33:L33"].Value = obj.L33L33;
            ws.Cells["L34:L34"].Value = obj.L34L34;
            ws.Cells["L35:L35"].Value = obj.L35L35;
            ws.Cells["L36:L36"].Value = obj.L36L36;
            ws.Cells["L37:L37"].Value = obj.L37L37;
            ws.Cells["L38:L38"].Value = obj.L38L38;
            ws.Cells["L39:L39"].Value = obj.L39L39;
            ws.Cells["L40:L40"].Value = obj.L40L40;
            ws.Cells["L41:L41"].Value = obj.L41L41;
            ws.Cells["L42:L42"].Value = obj.L42L42;
            ws.Cells["L43:L43"].Value = obj.L43L43;
            ws.Cells["L44:L44"].Value = obj.L44L44;
            ws.Cells["L45:L45"].Value = obj.L45L45;
            ws.Cells["L47:L47"].Value = obj.L47L47;
            ws.Cells["L48:L48"].Value = obj.L48L48;
            ws.Cells["L49:L49"].Value = obj.L49L49;
            ws.Cells["L50:L50"].Value = obj.L50L50;
            ws.Cells["L51:L51"].Value = obj.L51L51;
            ws.Cells["L52:L52"].Value = obj.L52L52;
            ws.Cells["L53:L53"].Value = obj.L53L53;
            ws.Cells["L54:L54"].Value = obj.L54L54;
            ws.Cells["L55:L55"].Value = obj.L55L55;
            ws.Cells["L56:L56"].Value = obj.L56L56;
            ws.Cells["L57:L57"].Value = obj.L57L57;
            ws.Cells["L58:L58"].Value = obj.L58L58;
            ws.Cells["L59:L59"].Value = obj.L59L59;
            ws.Cells["L60:L60"].Value = obj.L60L60;
            ws.Cells["L64:L64"].Value = obj.L64L64;
            ws.Cells["L65:L65"].Value = obj.L65L65;
            ws.Cells["L66:L66"].Value = obj.L66L66;
            ws.Cells["L67:L67"].Value = obj.L67L67;
            ws.Cells["L68:L68"].Value = obj.L68L68;
            ws.Cells["L69:L69"].Value = obj.L69L69;
            ws.Cells["L70:L70"].Value = obj.L70L70;
            ws.Cells["L71:L71"].Value = obj.L71L71;
            ws.Cells["L72:L72"].Value = obj.L72L72;
            ws.Cells["L73:L73"].Value = obj.L73L73;
            ws.Cells["L74:L74"].Value = obj.L74L74;
            ws.Cells["L75:L75"].Value = obj.L75L75;
            ws.Cells["L76:L76"].Value = obj.L76L76;
            ws.Cells["L77:L77"].Value = obj.L77L77;
            ws.Cells["L78:L78"].Value = obj.L78L78;
            ws.Cells["L79:L79"].Value = obj.L79L79;
            ws.Cells["L80:L80"].Value = obj.L80L80;
            ws.Cells["L81:L81"].Value = obj.L81L81;
            ws.Cells["L82:L82"].Value = obj.L82L82;
            ws.Cells["L83:L83"].Value = obj.L83L83;
            ws.Cells["L84:L84"].Value = obj.L84L84;
            ws.Cells["L85:L85"].Value = obj.L85L85;
            ws.Cells["L86:L86"].Value = obj.L86L86;
            ws.Cells["L87:L87"].Value = obj.L87L87;
            ws.Cells["L88:L88"].Value = obj.L88L88;
            ws.Cells["L89:L89"].Value = obj.L89L89;
            ws.Cells["L90:L90"].Value = obj.L90L90;
            ws.Cells["L91:L91"].Value = obj.L90L90;

            //fills special cell 
            obj.L8L10 = obj.L8L10.Trim('[', ']');
            string[] floatStrings = obj.L8L10.Split(',');
            float[] floats = new float[floatStrings.Length];

            for (int i = 0; i < floatStrings.Length; i++)
            {
                floats[i] = float.Parse(floatStrings[i]);
            }

            ws.Cells["L8:L8"].Value = floats[0];
            ws.Cells["L9:L9"].Value = floats[1];
            ws.Cells["L10:L10"].Value = floats[2];

            //saves file
            package.SaveAsync();

            //returns to controller
            return newFilePath;
        }
        
        //deletes if exists
        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists) {

                file.Delete();
            }
        }


    }
}