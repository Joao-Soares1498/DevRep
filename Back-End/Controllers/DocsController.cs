using Azure.Core;
using CCA_BE.Context;
using CCA_BE.Docs;
using CCA_BE.Excel;
using CCA_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using static Azure.Core.HttpHeader;

namespace CCA_BE.Controllers
{
    //controller for all CRUD related to documents
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        //CRUD to write excel
        [HttpPost("excel")]
        public async Task<ActionResult> Excel([FromBody] AnualExcelModel obj)
        {
            //obj validation
            if (obj == null)
            {
                return BadRequest();
            }

            //write excel
            await AnualExcel.WriteExcel(obj);

            obj.state = true;

            await _context.Evs.AddAsync(obj);
            await _context.SaveChangesAsync();

            //response
            return Ok(new
            {
                Message = "O fichero excel foi criado"
            });

        }

        //CRUD for pdf
        [HttpPost("pdf")]
        public async Task<ActionResult> Pdf([FromBody] AnualExcelModel obj)
        {
            //object validation
            if (obj == null) 
            {
                return BadRequest();
            }
            //pdf convertion
            await AnualPdf.ConvertExcelToPdf(obj.nameid, obj.fileName);

            //response
            return Ok(new
            {
                Message = "O PDF da avaliação foi gerado com sucesso"
            });
        }

        //CRUD for word documents (Anexo I)
        [HttpPost("docx")]
        public async Task<ActionResult> Word([FromBody] AnualExcelModel obj)
        {
            //object validation
            if(obj == null)
            {
                return BadRequest();
            }
            //generate docx
            await Docx.GenerateAnexoI(obj.nameid,obj.fileName);

            //response
            return Ok(new
            {
                Message = "O Anexo I foi adicionado aos seus ficheiros"
            });
        }

        //Get folders and files of user
        [HttpGet("folders")]
        public ActionResult<List<Folder>> GetFolders([FromQuery] string nameid)
        {
            //nameid validation
            if(nameid == null)
            {
                return BadRequest();
            }
            //gets folders and files
            List<Folder> folders = FolderSystem.getFolders(nameid);

            //response
            return Ok(folders);
        }

        //CRUD to download the files
        [HttpGet("download")]
        public ActionResult DownloadFile(string nameid, string folderName, string fileName)
        {
            //path to the file to download
            string filePath = Path.Combine(@"..\..\Files", nameid, folderName, fileName);

            //validation of path
            if (System.IO.File.Exists(filePath))
            {
                //download
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                //response success
                return File(fileBytes, "application/octet-stream", fileName);
            }

            //response if it doesn exist
            return NotFound();
        }
        

        private readonly CCADbContext _context;
        public DocsController(CCADbContext ccaDbContext)
        {
            _context = ccaDbContext;
        }


        [HttpGet("getEvs")]
        public ActionResult<List<Folder>> GetEvs([FromQuery] string nameid)
        {
            //nameid validation
            if (nameid == null)
            {
                return BadRequest();
            }

            var evs = _context.Evs.Where(ev => ev.nameid == nameid && ev.state == false )
                .Select(ev => new { ev.fileName, ev.Id }).ToList();
            
            if(evs.Count == 0)
            {
                return NotFound("Não existem avaliações para continuar!");
            }

            //response
            return Ok(evs);
        }

        [HttpPost("saveEv")]
        public async Task<ActionResult> SaveEv([FromBody] AnualExcelModel evObject)
        {
            if (evObject == null)
            {
                return BadRequest();
            }

            if (evObject.Id == 0)
            {
                // If the Id is 0, it means it's a new record, so add it to the database.
                evObject.state = false;
                await _context.Evs.AddAsync(evObject);
            }
            else
            {
                // If the Id is not 0, it means it's an existing record, so update it in the database.
                var existingEv = await _context.Evs.FindAsync(evObject.Id);
                if (existingEv == null)
                {
                    return NotFound();
                }

                // Update the properties of the existingEv.object with the new values.
                existingEv.nameid = evObject.nameid;
                existingEv.fileName = evObject.fileName;
                existingEv.state = evObject.state;
                existingEv.F3G3 = evObject.F3G3;
                existingEv.K4K4 = evObject.K4K4;
                existingEv.L4L4 = evObject.L4L4;
                existingEv.M4M4 = evObject.M4M4;
                existingEv.L8L10 = evObject.L8L10;
                existingEv.L11L11 = evObject.L11L11;
                existingEv.L12L12 = evObject.L12L12;
                existingEv.L13L13 = evObject.L13L13;
                existingEv.L14L14 = evObject.L14L14;
                existingEv.L15L15 = evObject.L15L15;
                existingEv.L16L16 = evObject.L16L16;
                existingEv.L17L17 = evObject.L17L17;
                existingEv.L18L18 = evObject.L18L18;
                existingEv.L19L19 = evObject.L19L19;
                existingEv.L20L20 = evObject.L20L20;
                existingEv.L21L21 = evObject.L21L21;
                existingEv.L22L22 = evObject.L22L22;
                existingEv.L23L23 = evObject.L23L23;
                existingEv.L24L24 = evObject.L24L24;
                existingEv.L25L25 = evObject.L25L25;
                existingEv.L26L26 = evObject.L26L26;
                existingEv.L27L27 = evObject.L27L27;
                existingEv.L28L28 = evObject.L28L28;
                existingEv.L29L29 = evObject.L29L29;
                existingEv.L30L30 = evObject.L30L30;
                existingEv.L31L31 = evObject.L31L31;
                existingEv.L32L32 = evObject.L32L32;
                existingEv.L33L33 = evObject.L33L33;
                existingEv.L34L34 = evObject.L34L34;
                existingEv.L35L35 = evObject.L35L35;
                existingEv.L36L36 = evObject.L36L36;
                existingEv.L37L37 = evObject.L37L37;
                existingEv.L38L38 = evObject.L38L38;
                existingEv.L39L39 = evObject.L39L39;
                existingEv.L40L40 = evObject.L40L40;
                existingEv.L41L41 = evObject.L41L41;
                existingEv.L42L42 = evObject.L42L42;
                existingEv.L43L43 = evObject.L43L43;
                existingEv.L44L44 = evObject.L44L44;
                existingEv.L45L45 = evObject.L45L45;
                existingEv.L47L47 = evObject.L47L47;
                existingEv.L48L48 = evObject.L48L48;
                existingEv.L49L49 = evObject.L49L49;
                existingEv.L50L50 = evObject.L50L50;
                existingEv.L51L51 = evObject.L51L51;
                existingEv.L52L52 = evObject.L52L52;
                existingEv.L53L53 = evObject.L53L53;
                existingEv.L54L54 = evObject.L53L53;
                existingEv.L55L55 = evObject.L55L55;
                existingEv.L56L56 = evObject.L56L56;
                existingEv.L57L57 = evObject.L57L57;
                existingEv.L58L58 = evObject.L58L58;
                existingEv.L59L59 = evObject.L59L59;
                existingEv.L60L60 = evObject.L60L60;
                existingEv.L64L64 = evObject.L64L64;
                existingEv.L65L65 = evObject.L65L65;
                existingEv.L66L66 = evObject.L66L66;
                existingEv.L67L67 = evObject.L67L67;
                existingEv.L68L68 = evObject.L68L68;
                existingEv.L69L69 = evObject.L69L69;
                existingEv.L70L70 = evObject.L70L70;
                existingEv.L71L71 = evObject.L71L71;
                existingEv.L72L72 = evObject.L72L72;
                existingEv.L73L73 = evObject.L73L73;
                existingEv.L74L74 = evObject.L74L74;
                existingEv.L75L75 = evObject.L75L75;
                existingEv.L76L76 = evObject.L76L76;
                existingEv.L77L77 = evObject.L77L77;
                existingEv.L78L78 = evObject.L78L78;
                existingEv.L79L79 = evObject.L79L79;
                existingEv.L80L80 = evObject.L80L80;
                existingEv.L81L81 = evObject.L81L81;
                existingEv.L82L82 = evObject.L82L82;
                existingEv.L83L83 = evObject.L83L83;
                existingEv.L84L84 = evObject.L84L84;
                existingEv.L85L85 = evObject.L85L85;
                existingEv.L86L86 = evObject.L86L86;
                existingEv.L87L87 = evObject.L87L87;
                existingEv.L88L88 = evObject.L88L88;
                existingEv.L89L89 = evObject.L89L89;
                existingEv.L90L90 = evObject.L90L90;
                existingEv.L91L91 = evObject.L91L91;
                // Update other properties as needed.

                // Mark the entity as modified so that it gets updated in the database.
                _context.Evs.Update(existingEv);
            }

            // Save changes to the database.
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Avaliação salva"
            });
        }

        [HttpGet("getEvData")]
        public ActionResult<AnualExcelModel> GetEvData(int id)
        {
            var evaluation = _context.Evs.SingleOrDefault(ev=> ev.Id== id);

            if(evaluation == null)
            {
                return NotFound("Avaliação Não Encontrada");
            }

            var result = new AnualExcelModel
            {

                Id = evaluation.Id,
                nameid = evaluation.nameid,
                fileName = evaluation.fileName,
                state = evaluation.state,
                F3G3 = evaluation.F3G3,
                K4K4 = evaluation.K4K4,
                L4L4 = evaluation.L4L4,
                M4M4 = evaluation.M4M4,
                L8L10 = evaluation.L8L10,
                L11L11 = evaluation.L11L11,
                L12L12 = evaluation.L12L12,
                L13L13 = evaluation.L13L13,
                L14L14 = evaluation.L14L14,
                L15L15 = evaluation.L15L15,
                L16L16 = evaluation.L16L16,
                L17L17 = evaluation.L17L17,
                L18L18 = evaluation.L18L18,
                L19L19 = evaluation.L19L19,
                L20L20 = evaluation.L20L20,
                L21L21 = evaluation.L21L21,
                L22L22 = evaluation.L22L22,
                L23L23 = evaluation.L23L23,
                L24L24 = evaluation.L24L24,
                L25L25 = evaluation.L25L25,
                L26L26 = evaluation.L26L26,
                L27L27 = evaluation.L27L27,
                L28L28 = evaluation.L28L28,
                L29L29 = evaluation.L29L29,
                L30L30 = evaluation.L30L30,
                L31L31 = evaluation.L31L31,
                L32L32 = evaluation.L32L32,
                L33L33 = evaluation.L33L33,
                L34L34 = evaluation.L34L34,
                L35L35 = evaluation.L35L35,
                L36L36 = evaluation.L36L36,
                L37L37 = evaluation.L37L37,
                L38L38 = evaluation.L38L38,
                L39L39 = evaluation.L39L39,
                L40L40 = evaluation.L40L40,
                L41L41 = evaluation.L41L41,
                L42L42 = evaluation.L42L42,
                L43L43 = evaluation.L43L43,
                L44L44 = evaluation.L44L44,
                L45L45 = evaluation.L45L45,
                L47L47 = evaluation.L47L47,
                L48L48 = evaluation.L48L48,
                L49L49 = evaluation.L49L49,
                L50L50 = evaluation.L50L50,
                L51L51 = evaluation.L51L51,
                L52L52 = evaluation.L52L52,
                L53L53 = evaluation.L53L53,
                L54L54 = evaluation.L53L53,
                L55L55 = evaluation.L55L55,
                L56L56 = evaluation.L56L56,
                L57L57 = evaluation.L57L57,
                L58L58 = evaluation.L58L58,
                L59L59 = evaluation.L59L59,
                L60L60 = evaluation.L60L60,
                L64L64 = evaluation.L64L64,
                L65L65 = evaluation.L65L65,
                L66L66 = evaluation.L66L66,
                L67L67 = evaluation.L67L67,
                L68L68 = evaluation.L68L68,
                L69L69 = evaluation.L69L69,
                L70L70 = evaluation.L70L70,
                L71L71 = evaluation.L71L71,
                L72L72 = evaluation.L72L72,
                L73L73 = evaluation.L73L73,
                L74L74 = evaluation.L74L74,
                L75L75 = evaluation.L75L75,
                L76L76 = evaluation.L76L76,
                L77L77 = evaluation.L77L77,
                L78L78 = evaluation.L78L78,
                L79L79 = evaluation.L79L79,
                L80L80 = evaluation.L80L80,
                L81L81 = evaluation.L81L81,
                L82L82 = evaluation.L82L82,
                L83L83 = evaluation.L83L83,
                L84L84 = evaluation.L84L84,
                L85L85 = evaluation.L85L85,
                L86L86 = evaluation.L86L86,
                L87L87 = evaluation.L87L87,
                L88L88 = evaluation.L88L88,
                L89L89 = evaluation.L89L89,
                L90L90 = evaluation.L90L90,
                L91L91 = evaluation.L91L91
    };
            return Ok(result);
        }
    }
}
