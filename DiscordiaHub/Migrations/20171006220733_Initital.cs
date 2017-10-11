using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DiscordiaHub.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    byond_version = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    cid = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ckey = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    country = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    first_seen = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    flags = table.Column<int>(type: "int", nullable: false),
                    ip = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    last_seen = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    rank = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    registered = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "polls",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    end = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    question = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    type = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_polls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "populations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    admin_count = table.Column<int>(type: "int", nullable: false),
                    player_count = table.Column<int>(type: "int", nullable: false),
                    server = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_populations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    banned_by_id = table.Column<int>(type: "int", nullable: true),
                    cid = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    expiration_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ip = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    job = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    reason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    server = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    target_id = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    unbanned = table.Column<bool>(type: "bit", nullable: true),
                    unbanned_by_id = table.Column<int>(type: "int", nullable: true),
                    unbanned_time = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bans", x => x.id);
                    table.ForeignKey(
                        name: "fk_bans_players_banned_by_id",
                        column: x => x.banned_by_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bans_players_target_id",
                        column: x => x.target_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bans_players_unbanned_by_id",
                        column: x => x.unbanned_by_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    author = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    author_id = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_books_players_author_id",
                        column: x => x.author_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "poll_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    max_value = table.Column<int>(type: "int", nullable: true),
                    min_value = table.Column<int>(type: "int", nullable: true),
                    poll_id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_poll_options", x => x.id);
                    table.ForeignKey(
                        name: "fk_poll_options_polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "poll_text_replies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    player_id = table.Column<int>(type: "int", nullable: true),
                    poll_id = table.Column<int>(type: "int", nullable: true),
                    text = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    time = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_poll_text_replies", x => x.id);
                    table.ForeignKey(
                        name: "fk_poll_text_replies_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_poll_text_replies_polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "poll_votes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    option_id = table.Column<int>(type: "int", nullable: false),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    poll_id = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_poll_votes", x => x.id);
                    table.ForeignKey(
                        name: "fk_poll_votes_poll_options_option_id",
                        column: x => x.option_id,
                        principalTable: "poll_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_poll_votes_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_poll_votes_polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bans_banned_by_id",
                table: "bans",
                column: "banned_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_bans_target_id",
                table: "bans",
                column: "target_id");

            migrationBuilder.CreateIndex(
                name: "ix_bans_unbanned_by_id",
                table: "bans",
                column: "unbanned_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_options_poll_id",
                table: "poll_options",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_text_replies_player_id",
                table: "poll_text_replies",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_text_replies_poll_id",
                table: "poll_text_replies",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_votes_option_id",
                table: "poll_votes",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_votes_player_id",
                table: "poll_votes",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_votes_poll_id",
                table: "poll_votes",
                column: "poll_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bans");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "poll_text_replies");

            migrationBuilder.DropTable(
                name: "poll_votes");

            migrationBuilder.DropTable(
                name: "populations");

            migrationBuilder.DropTable(
                name: "poll_options");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "polls");
        }
    }
}
