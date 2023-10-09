using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolhaPagamento.Migrations
{
    public partial class modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cpf = table.Column<string>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.funcionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    folhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valor = table.Column<float>(type: "REAL", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    mes = table.Column<int>(type: "INTEGER", nullable: false),
                    ano = table.Column<int>(type: "INTEGER", nullable: false),
                    salarioBruto = table.Column<float>(type: "REAL", nullable: false),
                    impostoIrrf = table.Column<float>(type: "REAL", nullable: false),
                    impostoInss = table.Column<float>(type: "REAL", nullable: false),
                    salarioFgts = table.Column<float>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<float>(type: "REAL", nullable: false),
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.folhaId);
                    table.ForeignKey(
                        name: "FK_Folhas_Funcionarios_funcionarioId",
                        column: x => x.funcionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "funcionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_funcionarioId",
                table: "Folhas",
                column: "funcionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
