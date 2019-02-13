using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OtakuNET.Domain.Migrations
{
    public partial class Ef_CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageSrc = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(maxLength: 10, nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 10, nullable: false),
                    FullName = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AvatarId = table.Column<int>(nullable: true),
                    Login = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Images_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animanga",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ImageSrc = table.Column<string>(nullable: true),
                    Raiting = table.Column<double>(nullable: false),
                    StudioImageSrc = table.Column<string>(nullable: true),
                    StudioName = table.Column<string>(maxLength: 40, nullable: false),
                    Tag = table.Column<string>(maxLength: 10, nullable: false),
                    Title = table.Column<string>(nullable: false),
                    SeasonKey = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animanga", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Animanga_Seasons_SeasonKey",
                        column: x => x.SeasonKey,
                        principalTable: "Seasons",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    ProfileId = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UserMangaList_ProfileId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserList_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserList_Profiles_UserMangaList_ProfileId",
                        column: x => x.UserMangaList_ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AnimangaLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimangaKey = table.Column<string>(nullable: false),
                    Href = table.Column<string>(nullable: false),
                    Text = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimangaLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimangaLink_Animanga_AnimangaKey",
                        column: x => x.AnimangaKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Updates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimeKey = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(maxLength: 10, nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Updates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Updates_Animanga_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeAnimeList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimeKey = table.Column<string>(nullable: false),
                    ListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_AnimeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anime_AnimeList_Animanga_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anime_AnimeList_UserList_ListId",
                        column: x => x.ListId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaMangaList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListId = table.Column<int>(nullable: false),
                    MangaKey = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga_MangaList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manga_MangaList_UserList_ListId",
                        column: x => x.ListId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manga_MangaList_Animanga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileHistoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimeKey = table.Column<string>(nullable: true),
                    MangaKey = table.Column<string>(nullable: true),
                    ProfileId = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    UserListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileHistoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileHistoryItem_Animanga_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileHistoryItem_Animanga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileHistoryItem_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileHistoryItem_UserList_UserListId",
                        column: x => x.UserListId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataListInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimeKey = table.Column<string>(nullable: true),
                    MangaKey = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    UpdateId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataListInfomation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataListInfomation_Animanga_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataListInfomation_Animanga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Animanga",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataListInfomation_Updates_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "Updates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animanga_SeasonKey",
                table: "Animanga",
                column: "SeasonKey");

            migrationBuilder.CreateIndex(
                name: "IX_AnimangaLink_AnimangaKey",
                table: "AnimangaLink",
                column: "AnimangaKey");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeList_AnimeKey",
                table: "AnimeAnimeList",
                column: "AnimeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeList_ListId",
                table: "AnimeAnimeList",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_DataListInfomation_AnimeKey",
                table: "DataListInformation",
                column: "AnimeKey");

            migrationBuilder.CreateIndex(
                name: "IX_DataListInfomation_MangaKey",
                table: "DataListInformation",
                column: "MangaKey");

            migrationBuilder.CreateIndex(
                name: "IX_DataListInfomation_UpdateId",
                table: "DataListInformation",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_MangaList_ListId",
                table: "MangaMangaList",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_MangaList_MangaKey",
                table: "MangaMangaList",
                column: "MangaKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileHistoryItem_AnimeKey",
                table: "ProfileHistoryItem",
                column: "AnimeKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileHistoryItem_MangaKey",
                table: "ProfileHistoryItem",
                column: "MangaKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileHistoryItem_ProfileId",
                table: "ProfileHistoryItem",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileHistoryItem_UserListId",
                table: "ProfileHistoryItem",
                column: "UserListId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AvatarId",
                table: "Profiles",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_Updates_AnimeKey",
                table: "Updates",
                column: "AnimeKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserList_ProfileId",
                table: "UserList",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserList_UserMangaList_ProfileId",
                table: "UserList",
                column: "UserMangaList_ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimangaLink");

            migrationBuilder.DropTable(
                name: "AnimeAnimeList");

            migrationBuilder.DropTable(
                name: "DataListInformation");

            migrationBuilder.DropTable(
                name: "MangaMangaList");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "ProfileHistoryItem");

            migrationBuilder.DropTable(
                name: "Updates");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropTable(
                name: "Animanga");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
