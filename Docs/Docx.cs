using System.CodeDom.Compiler;

namespace CCA_BE.Docs
{
    //class responsible to create anexo I
    public class Docx
    {
        //generates docx
        public static async Task GenerateAnexoI(string fileId, string fileName) {
            
            //path to the docx model
            string docxModel = "..\\..\\Files\\Models\\Modelo_Anexo-I-Relatorio-de-actividades.docx";

            //path to the new docx
            string destFilePath = "..\\..\\Files\\"
                + fileId + "\\"
                + fileName + "\\"
                + "AnexoI_RA_" + fileId + "_" + fileName + ".docx";
            
            //copy info of model to new docx
            File.Copy(docxModel, destFilePath);

        }
    }
}
