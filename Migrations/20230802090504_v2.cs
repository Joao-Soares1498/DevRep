using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCA_BE.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    F3G3 = table.Column<int>(type: "int", nullable: false),
                    K4K4 = table.Column<int>(type: "int", nullable: false),
                    L4L4 = table.Column<int>(type: "int", nullable: false),
                    M4M4 = table.Column<int>(type: "int", nullable: false),
                    L8L10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L11L11 = table.Column<int>(type: "int", nullable: false),
                    L12L12 = table.Column<int>(type: "int", nullable: false),
                    L13L13 = table.Column<int>(type: "int", nullable: false),
                    L14L14 = table.Column<int>(type: "int", nullable: false),
                    L15L15 = table.Column<int>(type: "int", nullable: false),
                    L16L16 = table.Column<int>(type: "int", nullable: false),
                    L17L17 = table.Column<int>(type: "int", nullable: false),
                    L18L18 = table.Column<int>(type: "int", nullable: false),
                    L19L19 = table.Column<int>(type: "int", nullable: false),
                    L20L20 = table.Column<int>(type: "int", nullable: false),
                    L21L21 = table.Column<int>(type: "int", nullable: false),
                    L22L22 = table.Column<int>(type: "int", nullable: false),
                    L23L23 = table.Column<int>(type: "int", nullable: false),
                    L24L24 = table.Column<int>(type: "int", nullable: false),
                    L25L25 = table.Column<int>(type: "int", nullable: false),
                    L26L26 = table.Column<int>(type: "int", nullable: false),
                    L27L27 = table.Column<int>(type: "int", nullable: false),
                    L28L28 = table.Column<int>(type: "int", nullable: false),
                    L29L29 = table.Column<int>(type: "int", nullable: false),
                    L30L30 = table.Column<int>(type: "int", nullable: false),
                    L31L31 = table.Column<int>(type: "int", nullable: false),
                    L32L32 = table.Column<int>(type: "int", nullable: false),
                    L33L33 = table.Column<int>(type: "int", nullable: false),
                    L34L34 = table.Column<int>(type: "int", nullable: false),
                    L35L35 = table.Column<int>(type: "int", nullable: false),
                    L36L36 = table.Column<int>(type: "int", nullable: false),
                    L37L37 = table.Column<int>(type: "int", nullable: false),
                    L38L38 = table.Column<int>(type: "int", nullable: false),
                    L39L39 = table.Column<int>(type: "int", nullable: false),
                    L40L40 = table.Column<int>(type: "int", nullable: false),
                    L41L41 = table.Column<int>(type: "int", nullable: false),
                    L42L42 = table.Column<int>(type: "int", nullable: false),
                    L43L43 = table.Column<int>(type: "int", nullable: false),
                    L44L44 = table.Column<int>(type: "int", nullable: false),
                    L45L45 = table.Column<int>(type: "int", nullable: false),
                    L47L47 = table.Column<int>(type: "int", nullable: false),
                    L48L48 = table.Column<int>(type: "int", nullable: false),
                    L49L49 = table.Column<int>(type: "int", nullable: false),
                    L50L50 = table.Column<int>(type: "int", nullable: false),
                    L51L51 = table.Column<int>(type: "int", nullable: false),
                    L52L52 = table.Column<int>(type: "int", nullable: false),
                    L53L53 = table.Column<int>(type: "int", nullable: false),
                    L54L54 = table.Column<int>(type: "int", nullable: false),
                    L55L55 = table.Column<int>(type: "int", nullable: false),
                    L56L56 = table.Column<int>(type: "int", nullable: false),
                    L57L57 = table.Column<int>(type: "int", nullable: false),
                    L58L58 = table.Column<int>(type: "int", nullable: false),
                    L59L59 = table.Column<int>(type: "int", nullable: false),
                    L60L60 = table.Column<int>(type: "int", nullable: false),
                    L64L64 = table.Column<int>(type: "int", nullable: false),
                    L65L65 = table.Column<int>(type: "int", nullable: false),
                    L66L66 = table.Column<int>(type: "int", nullable: false),
                    L67L67 = table.Column<int>(type: "int", nullable: false),
                    L68L68 = table.Column<int>(type: "int", nullable: false),
                    L69L69 = table.Column<int>(type: "int", nullable: false),
                    L70L70 = table.Column<int>(type: "int", nullable: false),
                    L71L71 = table.Column<int>(type: "int", nullable: false),
                    L72L72 = table.Column<int>(type: "int", nullable: false),
                    L73L73 = table.Column<int>(type: "int", nullable: false),
                    L74L74 = table.Column<int>(type: "int", nullable: false),
                    L75L75 = table.Column<int>(type: "int", nullable: false),
                    L76L76 = table.Column<int>(type: "int", nullable: false),
                    L77L77 = table.Column<int>(type: "int", nullable: false),
                    L78L78 = table.Column<int>(type: "int", nullable: false),
                    L79L79 = table.Column<int>(type: "int", nullable: false),
                    L80L80 = table.Column<int>(type: "int", nullable: false),
                    L81L81 = table.Column<int>(type: "int", nullable: false),
                    L82L82 = table.Column<int>(type: "int", nullable: false),
                    L83L83 = table.Column<int>(type: "int", nullable: false),
                    L84L84 = table.Column<int>(type: "int", nullable: false),
                    L85L85 = table.Column<int>(type: "int", nullable: false),
                    L86L86 = table.Column<int>(type: "int", nullable: false),
                    L87L87 = table.Column<int>(type: "int", nullable: false),
                    L88L88 = table.Column<int>(type: "int", nullable: false),
                    L89L89 = table.Column<int>(type: "int", nullable: false),
                    L90L90 = table.Column<int>(type: "int", nullable: false),
                    L91L91 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evs");
        }
    }
}
