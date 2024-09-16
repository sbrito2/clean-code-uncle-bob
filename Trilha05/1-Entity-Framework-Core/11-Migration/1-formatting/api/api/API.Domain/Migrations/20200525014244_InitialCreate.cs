using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace API.Domain.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTION_TYPE",
                columns: table => new
                {
                    ATY_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ATY_ACTIVE = table.Column<bool>(nullable: false),
                    ATY_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ATY_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ATY_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTION_TYPE", x => x.ATY_ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUS_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CUS_ACTIVE = table.Column<bool>(nullable: false),
                    CUS_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CUS_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    CUS_NAME = table.Column<string>(maxLength: 180, nullable: false),
                    CUS_EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    CUS_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROFILE",
                columns: table => new
                {
                    PRF_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRF_ACTIVE = table.Column<bool>(nullable: false),
                    PRF_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRF_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    PRF_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFILE", x => x.PRF_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROPERTY_TYPE",
                columns: table => new
                {
                    PRT_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRT_ACTIVE = table.Column<bool>(nullable: false),
                    PRT_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRT_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    PRT_TYPE = table.Column<string>(maxLength: 180, nullable: false),
                    PRT_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPERTY_TYPE", x => x.PRT_ID);
                });

            migrationBuilder.CreateTable(
                name: "RESOURCE_TYPE",
                columns: table => new
                {
                    RET_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RET_ACTIVE = table.Column<bool>(nullable: false),
                    RET_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RET_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    RET_DESCRIPTION = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCE_TYPE", x => x.RET_ID);
                });

            migrationBuilder.CreateTable(
                name: "STATE",
                columns: table => new
                {
                    STA_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    STA_ACTIVE = table.Column<bool>(nullable: false),
                    STA_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    STA_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    STA_DATE = table.Column<string>(nullable: false),
                    STA_ABREVIATION = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE", x => x.STA_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USE_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    USE_ACTIVE = table.Column<bool>(nullable: false),
                    USE_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    USE_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    USE_name = table.Column<string>(maxLength: 180, nullable: false),
                    USE_EMAIL = table.Column<string>(maxLength: 180, nullable: false),
                    USE_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: true),
                    USE_BIRTH = table.Column<DateTime>(nullable: true),
                    USE_RG = table.Column<string>(maxLength: 10, nullable: false),
                    USE_CPF = table.Column<string>(maxLength: 11, nullable: false),
                    USE_PHOTO_FRONT = table.Column<string>(maxLength: 250, nullable: true),
                    USE_PASSWORD = table.Column<string>(maxLength: 20, nullable: false),
                    PRF_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USE_ID);
                    table.ForeignKey(
                        name: "FK_USER_PROFILE_PRF_ID",
                        column: x => x.PRF_ID,
                        principalTable: "PROFILE",
                        principalColumn: "PRF_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    CIT_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CIT_ACTIVE = table.Column<bool>(nullable: false),
                    CIT_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CIT_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    CIT_DATE = table.Column<string>(maxLength: 180, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.CIT_ID);
                    table.ForeignKey(
                        name: "FK_CITY_STATE_StateId",
                        column: x => x.StateId,
                        principalTable: "STATE",
                        principalColumn: "STA_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROPERTY",
                columns: table => new
                {
                    PRO_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRO_ACTIVE = table.Column<bool>(nullable: false),
                    PRO_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRO_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    PRO_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: false),
                    PRO_AREA = table.Column<decimal>(type: "decimal(11,4)", nullable: false),
                    PRO_PHOTOS_PATH = table.Column<string>(maxLength: 250, nullable: true),
                    PRO_BASE_VALUE = table.Column<decimal>(nullable: false),
                    PRO_ADDRESS = table.Column<string>(maxLength: 250, nullable: false),
                    PRO_NUMBER = table.Column<string>(maxLength: 15, nullable: false),
                    PRO_CEP = table.Column<string>(maxLength: 10, nullable: false),
                    CIT_ID = table.Column<int>(nullable: false),
                    PRT_ID = table.Column<int>(nullable: false),
                    PRO_LATITUDE = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    PRO_LONGITUDE = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    PRO_STREET_VIEW_URL = table.Column<string>(maxLength: 300, nullable: true),
                    USE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPERTY", x => x.PRO_ID);
                    table.ForeignKey(
                        name: "FK_PROPERTY_CITY_CIT_ID",
                        column: x => x.CIT_ID,
                        principalTable: "CITY",
                        principalColumn: "CIT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROPERTY_PROPERTY_TYPE_PRT_ID",
                        column: x => x.PRT_ID,
                        principalTable: "PROPERTY_TYPE",
                        principalColumn: "PRT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROPERTY_USER_USE_ID",
                        column: x => x.USE_ID,
                        principalTable: "USER",
                        principalColumn: "USE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACTION",
                columns: table => new
                {
                    ACT_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ACT_ACTIVE = table.Column<bool>(nullable: false),
                    ACT_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ACT_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    ACT_DATE = table.Column<DateTime>(nullable: false),
                    ACT_INITIAL_BID = table.Column<decimal>(nullable: false),
                    ATY_ID = table.Column<int>(nullable: false),
                    PRO_ID = table.Column<int>(nullable: false),
                    USE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTION", x => x.ACT_ID);
                    table.ForeignKey(
                        name: "FK_ACTION_ACTION_TYPE_ATY_ID",
                        column: x => x.ATY_ID,
                        principalTable: "ACTION_TYPE",
                        principalColumn: "ATY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTION_PROPERTY_PRO_ID",
                        column: x => x.PRO_ID,
                        principalTable: "PROPERTY",
                        principalColumn: "PRO_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTION_USER_USE_ID",
                        column: x => x.USE_ID,
                        principalTable: "USER",
                        principalColumn: "USE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESOURCE",
                columns: table => new
                {
                    RES_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RES_ACTIVE = table.Column<bool>(nullable: false),
                    RES_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RES_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    RES_DESCRIPTION = table.Column<string>(maxLength: 300, nullable: false),
                    RES_VALUE = table.Column<decimal>(nullable: false),
                    RET_ID = table.Column<int>(nullable: false),
                    PRO_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCE", x => x.RES_ID);
                    table.ForeignKey(
                        name: "FK_RESOURCE_PROPERTY_PRO_ID",
                        column: x => x.PRO_ID,
                        principalTable: "PROPERTY",
                        principalColumn: "PRO_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESOURCE_RESOURCE_TYPE_RET_ID",
                        column: x => x.RET_ID,
                        principalTable: "RESOURCE_TYPE",
                        principalColumn: "RET_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BID",
                columns: table => new
                {
                    BID_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BID_ACTIVE = table.Column<bool>(nullable: false),
                    BID_CREATED_AT = table.Column<DateTime>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BID_UPDATE_AT = table.Column<DateTime>(nullable: false),
                    BID_DATE = table.Column<DateTime>(nullable: false),
                    BID_VALUE = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ACT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BID", x => x.BID_ID);
                    table.ForeignKey(
                        name: "FK_BID_ACTION_ACT_ID",
                        column: x => x.ACT_ID,
                        principalTable: "ACTION",
                        principalColumn: "ACT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_ATY_ID",
                table: "ACTION",
                column: "ATY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_PRO_ID",
                table: "ACTION",
                column: "PRO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_USE_ID",
                table: "ACTION",
                column: "USE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BID_ACT_ID",
                table: "BID",
                column: "ACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_StateId",
                table: "CITY",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTY_CIT_ID",
                table: "PROPERTY",
                column: "CIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTY_PRT_ID",
                table: "PROPERTY",
                column: "PRT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTY_USE_ID",
                table: "PROPERTY",
                column: "USE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCE_PRO_ID",
                table: "RESOURCE",
                column: "PRO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCE_RET_ID",
                table: "RESOURCE",
                column: "RET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PRF_ID",
                table: "USER",
                column: "PRF_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BID");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "RESOURCE");

            migrationBuilder.DropTable(
                name: "ACTION");

            migrationBuilder.DropTable(
                name: "RESOURCE_TYPE");

            migrationBuilder.DropTable(
                name: "ACTION_TYPE");

            migrationBuilder.DropTable(
                name: "PROPERTY");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "PROPERTY_TYPE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "STATE");

            migrationBuilder.DropTable(
                name: "PROFILE");
        }
    }
}
