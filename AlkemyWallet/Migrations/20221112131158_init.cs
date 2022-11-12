using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlkemyWallet.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    RolId = table.Column<int>(type: "int", nullable: false),
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
                name: "Catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productdescription = table.Column<string>(name: "Product_description", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(name: "First_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(name: "Last_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Points = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Rolid = table.Column<int>(name: "Rol_id", type: "int", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_Rol_id",
                        column: x => x.Rolid,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Money = table.Column<float>(type: "real", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    Userid = table.Column<int>(name: "User_id", type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_User_id",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixedTermDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(name: "User_id", type: "int", nullable: false),
                    Accountid = table.Column<int>(name: "Account_id", type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Creationdate = table.Column<DateTime>(name: "Creation_date", type: "datetime2", nullable: false),
                    Closingdate = table.Column<DateTime>(name: "Closing_date", type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedTermDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedTermDeposit_Account_Account_id",
                        column: x => x.Accountid,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixedTermDeposit_User_User_id",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Transactionid = table.Column<int>(name: "Transaction_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Concept = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Userid = table.Column<int>(name: "User_id", type: "int", nullable: false),
                    ToAccount = table.Column<int>(name: "To_Account", type: "int", nullable: false),
                    Accountid = table.Column<int>(name: "Account_id", type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Transactionid);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_Account_id",
                        column: x => x.Accountid,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_User_User_id",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Catalogue",
                columns: new[] { "Id", "DeletedDate", "Image", "IsDeleted", "Points", "Product_description" },
                values: new object[,]
                {
                    { 1, null, "", false, 300, "cocina" },
                    { 2, null, "", false, 500, "Lavarropas" },
                    { 3, null, "", false, 700, "Heladera" },
                    { 4, null, "", false, 400, "Lavavajillas" },
                    { 5, null, "", false, 600, "Freezer" },
                    { 6, null, "", false, 200, "Microondas" },
                    { 7, null, "", false, 400, "Horno Electrico" },
                    { 8, null, "", false, 500, "Horno Grande" },
                    { 9, null, "", false, 200, "Panificadora" },
                    { 10, null, "", false, 100, "Cepillo Electrico" },
                    { 11, null, "", false, 600, "Termotanque" },
                    { 12, null, "", false, 300, "Secaropa" },
                    { 13, null, "", false, 100, "Tostadora" },
                    { 14, null, "", false, 100, "Plancha de pelo" },
                    { 15, null, "", false, 300, "Home Theater" },
                    { 16, null, "", false, 250, "Equipo de Sonido" },
                    { 17, null, "", false, 400, "Calentador Portatil" },
                    { 18, null, "", false, 800, "Televisor Led" },
                    { 19, null, "", false, 50, "Lampara de Pie" },
                    { 20, null, "", false, 300, "Sistema de Audio Portatil" },
                    { 21, null, "", false, 100, "Licuadora" },
                    { 22, null, "", false, 350, "Corta Cesped" },
                    { 23, null, "", false, 200, "Hidrolavadora" },
                    { 24, null, "", false, 400, "Telefono Celular" },
                    { 25, null, "", false, 400, "Generador Electrico" },
                    { 26, null, "", false, 150, "Bomba de Presion" },
                    { 27, null, "", false, 800, "Computadora de Escritorio" },
                    { 28, null, "", false, 700, "Laptop" },
                    { 29, null, "", false, 250, "Monitor UltraWide" },
                    { 30, null, "", false, 500, "Aire Acondicionado" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DeletedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, "Admin", false, "Administrador" },
                    { 2, null, "Usuario con algunos permisos de escritura", false, "Standard" },
                    { 3, null, "Solo permisos de lectura", false, "Invitado" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DeletedDate", "Email", "First_name", "IsDeleted", "Last_name", "Password", "Points", "Rol_id" },
                values: new object[,]
                {
                    { 1, null, "clint@eastwood.com", "Clint", false, "Eastwood", "$2b$10$DjsYH6P2iczga6DFAAVf/Oulu1f9Qdlw24w0Lfej3aNnQx.eqato2", 500, 2 },
                    { 2, null, "arnoldsg@skynet.com", "Arnold", false, "Schwarzenegger", "$2b$10$dvsbNpgI0E0v9X5D7r9h2un6DFsI8mx2RePLUOUaMMTWQr3hlU522", 2000, 1 },
                    { 3, null, "sylvesters@hollywood.com", "Sylvester", false, "Stallone", "$2b$10$zUJTo0YB6ltWZFwFUw3Ek.47UuzqwFNI366GhKoTJZlUQkPS..mNu", 2000, 3 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreationDate", "DeletedDate", "IsBlocked", "IsDeleted", "Money", "User_id" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 150000f, 2 },
                    { 2, new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 50f, 2 },
                    { 3, new DateTime(1995, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 1050f, 1 },
                    { 4, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 51234f, 1 },
                    { 5, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1224f, 1 },
                    { 6, new DateTime(2001, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 25040f, 1 },
                    { 7, new DateTime(1995, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 55553f, 1 },
                    { 8, new DateTime(2012, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 50f, 1 },
                    { 9, new DateTime(1942, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 120f, 1 },
                    { 10, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 54311f, 1 },
                    { 11, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3333f, 1 },
                    { 12, new DateTime(2013, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 231f, 1 },
                    { 13, new DateTime(1995, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 1050f, 1 },
                    { 14, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 51234f, 1 },
                    { 15, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1224f, 1 },
                    { 16, new DateTime(2001, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 25040f, 1 },
                    { 17, new DateTime(1995, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 55553f, 1 },
                    { 18, new DateTime(2012, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 50f, 1 },
                    { 19, new DateTime(1942, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 120f, 1 },
                    { 20, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 54311f, 1 },
                    { 21, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3333f, 1 },
                    { 22, new DateTime(2013, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 231f, 1 },
                    { 23, new DateTime(1998, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 1050f, 1 },
                    { 24, new DateTime(1999, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 51234f, 1 },
                    { 25, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1224f, 1 },
                    { 26, new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 25040f, 1 },
                    { 27, new DateTime(1985, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 55553f, 1 },
                    { 28, new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 50f, 1 },
                    { 29, new DateTime(1967, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 120f, 1 },
                    { 30, new DateTime(1978, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 54311f, 1 },
                    { 31, new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3333f, 1 },
                    { 32, new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 231f, 1 },
                    { 33, new DateTime(1992, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 1050f, 1 },
                    { 34, new DateTime(1991, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 51234f, 1 },
                    { 35, new DateTime(2017, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1224f, 1 },
                    { 36, new DateTime(2007, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 25040f, 1 },
                    { 37, new DateTime(1985, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 55553f, 1 },
                    { 38, new DateTime(2008, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 50f, 1 },
                    { 39, new DateTime(1981, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 120f, 1 },
                    { 40, new DateTime(1998, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 54311f, 1 },
                    { 41, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3333f, 1 },
                    { 42, new DateTime(2013, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 231f, 1 },
                    { 43, new DateTime(1995, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 1050f, 1 },
                    { 44, new DateTime(1995, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 51234f, 1 },
                    { 45, new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1224f, 1 },
                    { 46, new DateTime(2001, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 25040f, 1 },
                    { 47, new DateTime(1996, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 55553f, 1 },
                    { 48, new DateTime(2015, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 50f, 1 },
                    { 49, new DateTime(1976, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 120f, 1 },
                    { 50, new DateTime(1998, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 54311f, 1 },
                    { 51, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3333f, 1 },
                    { 52, new DateTime(2012, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 231f, 1 }
                });

            migrationBuilder.InsertData(
                table: "FixedTermDeposit",
                columns: new[] { "Id", "Account_id", "Amount", "Closing_date", "Creation_date", "DeletedDate", "IsDeleted", "User_id" },
                values: new object[,]
                {
                    { 1, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 2, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 3, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 4, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 5, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 6, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 7, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 8, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 9, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 10, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 11, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 12, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 13, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 14, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 15, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 16, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 17, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 18, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 19, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 20, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 21, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 22, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 23, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 24, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 25, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 26, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 27, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 28, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 29, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 30, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 31, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 32, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 33, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 34, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 35, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 36, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 37, 2, 23000m, new DateTime(2011, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 38, 2, 23000m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2 },
                    { 39, 3, 23000m, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 },
                    { 40, 3, 23000m, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Transaction_id", "Account_id", "Amount", "Concept", "Date", "DeletedDate", "IsDeleted", "To_Account", "Type", "User_id" },
                values: new object[,]
                {
                    { 1, 1, 15155, "Crédito", new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 2, 1, 4922, "Efectivo", new DateTime(1999, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 3, 1, 9340, "Prestamo", new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Crédito", 1 },
                    { 4, 1, 3211, "Sueldo", new DateTime(2013, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 5, 1, 55552, "crédito", new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 6, 1, 224, "Reintegro", new DateTime(1980, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 7, 1, 202300, "Pago", new DateTime(1994, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 8, 1, 202300, "Pago", new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 9, 1, 202300, "Pago", new DateTime(1990, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Credito", 1 },
                    { 10, 1, 202300, "Sueldo", new DateTime(1990, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 11, 1, 15155, "Crédito", new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 12, 1, 4922, "Efectivo", new DateTime(1999, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 13, 1, 9340, "Prestamo", new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Crédito", 1 },
                    { 14, 1, 3211, "Sueldo", new DateTime(2013, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 15, 1, 55552, "crédito", new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 16, 1, 224, "Reintegro", new DateTime(1980, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 17, 1, 202300, "Pago", new DateTime(1990, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 18, 1, 202300, "Pago", new DateTime(1990, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 19, 1, 202300, "Pago", new DateTime(1993, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Credito", 1 },
                    { 20, 1, 202300, "Sueldo", new DateTime(1995, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 21, 1, 15155, "Crédito", new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 22, 1, 4922, "Efectivo", new DateTime(1999, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 23, 1, 9340, "Prestamo", new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Crédito", 1 },
                    { 24, 1, 3211, "Sueldo", new DateTime(2013, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 25, 1, 55552, "crédito", new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 26, 1, 224, "Reintegro", new DateTime(1980, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 27, 1, 202300, "Pago", new DateTime(1990, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 28, 1, 202300, "Pago", new DateTime(1991, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 29, 1, 202300, "Pago", new DateTime(1997, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Credito", 1 },
                    { 30, 1, 202300, "Sueldo", new DateTime(1998, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 31, 1, 15155, "Crédito", new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 32, 1, 4922, "Efectivo", new DateTime(1999, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 33, 1, 9340, "Prestamo", new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Crédito", 1 },
                    { 34, 1, 3211, "Sueldo", new DateTime(2013, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 35, 1, 55552, "crédito", new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 36, 1, 224, "Reintegro", new DateTime(1980, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Debito", 1 },
                    { 37, 1, 202300, "Pago", new DateTime(1992, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 38, 1, 202300, "Pago", new DateTime(1991, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 },
                    { 39, 1, 202300, "Pago", new DateTime(1997, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Credito", 1 },
                    { 40, 1, 202300, "Sueldo", new DateTime(1999, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, "Efectivo", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_User_id",
                table: "Account",
                column: "User_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_FixedTermDeposit_Account_id",
                table: "FixedTermDeposit",
                column: "Account_id");

            migrationBuilder.CreateIndex(
                name: "IX_FixedTermDeposit_User_id",
                table: "FixedTermDeposit",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Account_id",
                table: "Transaction",
                column: "Account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_User_id",
                table: "Transaction",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Rol_id",
                table: "User",
                column: "Rol_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Catalogue");

            migrationBuilder.DropTable(
                name: "FixedTermDeposit");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
