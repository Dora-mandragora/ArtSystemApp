using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtSystemApp.Migrations
{
    public partial class AddDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Users_UserId",
                table: "Access");

            migrationBuilder.DropForeignKey(
                name: "FK_Folder_Users_UserId",
                table: "Folder");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Access_AccessId",
                table: "Work");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Folder_FolderId",
                table: "Work");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Image_ImageId",
                table: "Work");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Theme_ThemeId",
                table: "Work");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Users_UserId",
                table: "Work");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Work",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theme",
                table: "Theme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Format",
                table: "Format");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folder",
                table: "Folder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Access",
                table: "Access");

            migrationBuilder.RenameTable(
                name: "Work",
                newName: "Works");

            migrationBuilder.RenameTable(
                name: "Theme",
                newName: "Themes");

            migrationBuilder.RenameTable(
                name: "Format",
                newName: "Formats");

            migrationBuilder.RenameTable(
                name: "Folder",
                newName: "Folders");

            migrationBuilder.RenameTable(
                name: "Access",
                newName: "Accesses");

            migrationBuilder.RenameIndex(
                name: "IX_Work_UserId",
                table: "Works",
                newName: "IX_Works_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_ThemeId",
                table: "Works",
                newName: "IX_Works_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_ImageId",
                table: "Works",
                newName: "IX_Works_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_FolderId",
                table: "Works",
                newName: "IX_Works_FolderId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_AccessId",
                table: "Works",
                newName: "IX_Works_AccessId");

            migrationBuilder.RenameIndex(
                name: "IX_Folder_UserId",
                table: "Folders",
                newName: "IX_Folders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Access_UserId",
                table: "Accesses",
                newName: "IX_Accesses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                table: "Works",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Themes",
                table: "Themes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formats",
                table: "Formats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folders",
                table: "Folders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FormatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_FormatId",
                table: "Pictures",
                column: "FormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_Users_UserId",
                table: "Accesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Accesses_AccessId",
                table: "Works",
                column: "AccessId",
                principalTable: "Accesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Folders_FolderId",
                table: "Works",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Pictures_ImageId",
                table: "Works",
                column: "ImageId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Themes_ThemeId",
                table: "Works",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_UserId",
                table: "Works",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_Users_UserId",
                table: "Accesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_ImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Accesses_AccessId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Folders_FolderId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Pictures_ImageId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Themes_ThemeId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_UserId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Themes",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formats",
                table: "Formats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folders",
                table: "Folders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses");

            migrationBuilder.RenameTable(
                name: "Works",
                newName: "Work");

            migrationBuilder.RenameTable(
                name: "Themes",
                newName: "Theme");

            migrationBuilder.RenameTable(
                name: "Formats",
                newName: "Format");

            migrationBuilder.RenameTable(
                name: "Folders",
                newName: "Folder");

            migrationBuilder.RenameTable(
                name: "Accesses",
                newName: "Access");

            migrationBuilder.RenameIndex(
                name: "IX_Works_UserId",
                table: "Work",
                newName: "IX_Work_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_ThemeId",
                table: "Work",
                newName: "IX_Work_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_ImageId",
                table: "Work",
                newName: "IX_Work_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_FolderId",
                table: "Work",
                newName: "IX_Work_FolderId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_AccessId",
                table: "Work",
                newName: "IX_Work_AccessId");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_UserId",
                table: "Folder",
                newName: "IX_Folder_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Accesses_UserId",
                table: "Access",
                newName: "IX_Access_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Work",
                table: "Work",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theme",
                table: "Theme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Format",
                table: "Format",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folder",
                table: "Folder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Access",
                table: "Access",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatId = table.Column<int>(type: "int", nullable: true),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Format_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Format",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_FormatId",
                table: "Image",
                column: "FormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Users_UserId",
                table: "Access",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_Users_UserId",
                table: "Folder",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Access_AccessId",
                table: "Work",
                column: "AccessId",
                principalTable: "Access",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Folder_FolderId",
                table: "Work",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Image_ImageId",
                table: "Work",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Theme_ThemeId",
                table: "Work",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Users_UserId",
                table: "Work",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
