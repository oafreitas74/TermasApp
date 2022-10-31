using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermasApp.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aquista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTerma = table.Column<int>(type: "int", nullable: true),
                    NIF = table.Column<long>(type: "bigint", nullable: true),
                    NSSocial = table.Column<long>(type: "bigint", nullable: true),
                    Telefone = table.Column<long>(type: "bigint", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CPostal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Concelho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SeguroSaude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FotoSrc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pass = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUserOrig = table.Column<int>(type: "int", nullable: false),
                    TipoUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: true),
                    IdAquista = table.Column<int>(type: "int", nullable: true),
                    IdTriagem = table.Column<int>(type: "int", nullable: true),
                    Hora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoConsulta = table.Column<int>(type: "int", nullable: true),
                    PrescricaoTrue = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTerma = table.Column<int>(type: "int", nullable: true),
                    NomeInterno = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NSerie = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFabrico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Jan = table.Column<bool>(type: "bit", nullable: false),
                    Fev = table.Column<bool>(type: "bit", nullable: false),
                    Mar = table.Column<bool>(type: "bit", nullable: false),
                    Abr = table.Column<bool>(type: "bit", nullable: false),
                    Mai = table.Column<bool>(type: "bit", nullable: false),
                    Jun = table.Column<bool>(type: "bit", nullable: false),
                    Jul = table.Column<bool>(type: "bit", nullable: false),
                    Ago = table.Column<bool>(type: "bit", nullable: false),
                    Set = table.Column<bool>(type: "bit", nullable: false),
                    Out = table.Column<bool>(type: "bit", nullable: false),
                    Nov = table.Column<bool>(type: "bit", nullable: false),
                    Dez = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTerma = table.Column<int>(type: "int", nullable: true),
                    Classificacao = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<long>(type: "bigint", nullable: true),
                    NIF = table.Column<long>(type: "bigint", nullable: true),
                    NSSocial = table.Column<long>(type: "bigint", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TipoFuncionario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeguroTrabalho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CPostal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Concelho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataEntrada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataSaida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Posto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Hablitacoes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FotoSrc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Pass = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosReparacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTecnico = table.Column<int>(type: "int", nullable: true),
                    IdEquipamento = table.Column<int>(type: "int", nullable: true),
                    DataPedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Avaria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: true),
                    Preventiva = table.Column<bool>(type: "bit", nullable: true),
                    DataConclusao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosReparacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Precricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAquista = table.Column<int>(type: "int", nullable: true),
                    IdTipoTratamento = table.Column<int>(type: "int", nullable: true),
                    NTratamentos = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdConsulta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precricao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoConsulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<float>(type: "real", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImagemPublicitaria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConsulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTratamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<float>(type: "real", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImagemPublicitaria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTratamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tratamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAquista = table.Column<int>(type: "int", nullable: true),
                    IdPrescricao = table.Column<int>(type: "int", nullable: true),
                    IdTerapeuta = table.Column<int>(type: "int", nullable: true),
                    IdTriagem = table.Column<int>(type: "int", nullable: true),
                    Hora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoTratamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Triagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEnfermeiro = table.Column<int>(type: "int", nullable: true),
                    IdAquista = table.Column<int>(type: "int", nullable: true),
                    Hora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aquista");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "PedidosReparacao");

            migrationBuilder.DropTable(
                name: "Precricao");

            migrationBuilder.DropTable(
                name: "TipoConsulta");

            migrationBuilder.DropTable(
                name: "TipoTratamento");

            migrationBuilder.DropTable(
                name: "Tratamento");

            migrationBuilder.DropTable(
                name: "Triagem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
