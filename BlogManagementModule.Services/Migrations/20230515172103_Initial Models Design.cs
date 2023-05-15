using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogManagementModule.Services.Migrations
{
    public partial class InitialModelsDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CategoryDescription = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Roles = table.Column<int>(type: "integer", nullable: false, defaultValue: 2),
                    Username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    PermanentAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletorId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userAccounts_userAccounts_DeletorId",
                        column: x => x.DeletorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userAccounts_userAccounts_LastModifiedId",
                        column: x => x.LastModifiedId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blogAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlogCategoryId = table.Column<int>(type: "integer", nullable: false),
                    BlogName = table.Column<string>(type: "text", nullable: false),
                    BlogDescription = table.Column<string>(type: "text", nullable: true),
                    BlogStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    PublishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsAllowPublicComment = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeleteTime = table.Column<long>(type: "bigint", nullable: true),
                    DeletorId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogAccounts_blogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "blogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogAccounts_userAccounts_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogAccounts_userAccounts_DeletorId",
                        column: x => x.DeletorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogAccounts_userAccounts_LastModifiedId",
                        column: x => x.LastModifiedId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blogComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    DeleteRemarks = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeleteTime = table.Column<long>(type: "bigint", nullable: true),
                    DeletorId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogComments_blogAccounts_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogComments_userAccounts_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogComments_userAccounts_DeletorId",
                        column: x => x.DeletorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogComments_userAccounts_LastModifiedId",
                        column: x => x.LastModifiedId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blogFileInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlogAccountId = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileLocation = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeleteTime = table.Column<long>(type: "bigint", nullable: true),
                    DeletorId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogFileInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogFileInformations_blogAccounts_BlogAccountId",
                        column: x => x.BlogAccountId,
                        principalTable: "blogAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogFileInformations_userAccounts_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogFileInformations_userAccounts_DeletorId",
                        column: x => x.DeletorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blogFileInformations_userAccounts_LastModifiedId",
                        column: x => x.LastModifiedId,
                        principalTable: "userAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "blogViewHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublicUser = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogViewHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogViewHistory_blogAccounts_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogViewHistory_userAccounts_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "blogCategories",
                columns: new[] { "Id", "CategoryDescription", "CategoryName", "IsActive" },
                values: new object[,]
                {
                    { 1, null, "IT", true },
                    { 2, null, "Bank", true },
                    { 3, null, "School", true },
                    { 4, null, "Collage", true },
                    { 5, null, "Account", true },
                    { 6, null, "Coding", true },
                    { 7, null, "GameDevelopment", true },
                    { 8, null, "UnrealEngine", true },
                    { 9, null, "C++", true }
                });

            migrationBuilder.InsertData(
                table: "userAccounts",
                columns: new[] { "Id", "CreationTime", "DeleteTime", "DeletorId", "EmailAddress", "LastModificationTime", "LastModifiedId", "MobileNumber", "Password", "PermanentAddress", "Roles", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), null, null, "bijay.adhikari.27648@gmail.com", null, null, "+977-9865413772", "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=", "Lalbandi,Sarlahi", 1, "Bijay_Admin" },
                    { 2L, new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), null, null, "bjsoft1@gmail.com", null, null, "+977-9827876333", "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=", "Lalbandi,Sarlahi", 2, "Bijay_User" },
                    { 3L, new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), null, null, "bijay.adhikari1@gmail.com", null, null, "+977-9800000000", "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=", "Lalbandi,Sarlahi", 2, "Bijay_User1" },
                    { 4L, new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), null, null, "bijay.adhikari2@gmail.com", null, null, "+977-9800000001", "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=", "Lalbandi,Sarlahi", 2, "Bijay_User2" },
                    { 5L, new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), null, null, "bijay.adhikari3@gmail.com", null, null, "+977-9800000002", "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=", "Lalbandi,Sarlahi", 2, "Bijay_User3" },
                    { 6L, new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), null, null, "bijay.adhikari4@gmail.com", null, null, "+977-9800000003", "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=", "Lalbandi,Sarlahi", 2, "Bijay_User4" }
                });

            migrationBuilder.InsertData(
                table: "blogAccounts",
                columns: new[] { "Id", "BlogCategoryId", "BlogDescription", "BlogName", "CreationTime", "CreatorId", "DeleteTime", "DeletorId", "ExpiryDate", "IsAllowPublicComment", "IsDelete", "IsPublic", "LastModificationTime", "LastModifiedId", "PublishedDate" },
                values: new object[,]
                {
                    { 1L, 1, "Hello1", "Title1", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 2L, 1, "Hello2", "Title2", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 3L, 1, "Hello3", "Title3", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 4L, 1, "Hello4", "Title4", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 5L, 1, "Hello5", "Title5", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 6L, 1, "Hello6", "Title6", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 7L, 1, "Hello7", "Title7", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null },
                    { 8L, 1, "Hello8", "Title8", new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135), 1L, null, null, null, true, false, true, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogAccounts_BlogCategoryId",
                table: "blogAccounts",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogAccounts_CreatorId",
                table: "blogAccounts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogAccounts_DeletorId",
                table: "blogAccounts",
                column: "DeletorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogAccounts_LastModifiedId",
                table: "blogAccounts",
                column: "LastModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_blogComments_BlogId",
                table: "blogComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blogComments_CreatorId",
                table: "blogComments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogComments_DeletorId",
                table: "blogComments",
                column: "DeletorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogComments_LastModifiedId",
                table: "blogComments",
                column: "LastModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_blogFileInformations_BlogAccountId",
                table: "blogFileInformations",
                column: "BlogAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_blogFileInformations_CreatorId",
                table: "blogFileInformations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogFileInformations_DeletorId",
                table: "blogFileInformations",
                column: "DeletorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogFileInformations_LastModifiedId",
                table: "blogFileInformations",
                column: "LastModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_blogViewHistory_BlogId",
                table: "blogViewHistory",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blogViewHistory_CreatorId",
                table: "blogViewHistory",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_DeletorId",
                table: "userAccounts",
                column: "DeletorId");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_LastModifiedId",
                table: "userAccounts",
                column: "LastModifiedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogComments");

            migrationBuilder.DropTable(
                name: "blogFileInformations");

            migrationBuilder.DropTable(
                name: "blogViewHistory");

            migrationBuilder.DropTable(
                name: "blogAccounts");

            migrationBuilder.DropTable(
                name: "blogCategories");

            migrationBuilder.DropTable(
                name: "userAccounts");
        }
    }
}
