﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizItemAnswerEntityQuizItemEntity",
                columns: table => new
                {
                    IncorrectAnswersId = table.Column<int>(type: "int", nullable: false),
                    QuizItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizItemAnswerEntityQuizItemEntity", x => new { x.IncorrectAnswersId, x.QuizItemsId });
                    table.ForeignKey(
                        name: "FK_QuizItemAnswerEntityQuizItemEntity_Answers_IncorrectAnswersId",
                        column: x => x.IncorrectAnswersId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizItemAnswerEntityQuizItemEntity_QuizItems_QuizItemsId",
                        column: x => x.QuizItemsId,
                        principalTable: "QuizItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuizItemId = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    UserAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => new { x.UserId, x.QuizId, x.QuizItemId });
                    table.ForeignKey(
                        name: "FK_UserAnswers_QuizItems_QuizItemId",
                        column: x => x.QuizItemId,
                        principalTable: "QuizItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizEntityQuizItemEntity",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    QuizzesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizEntityQuizItemEntity", x => new { x.ItemsId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuizEntityQuizItemEntity_QuizItems_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "QuizItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizEntityQuizItemEntity_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Answer" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" },
                    { 5, "5" },
                    { 6, "6" },
                    { 7, "7" },
                    { 8, "8" },
                    { 9, "9" },
                    { 10, "10" },
                    { 11, "11" },
                    { 12, "12" },
                    { 13, "13" },
                    { 14, "14" }
                });

            migrationBuilder.InsertData(
                table: "QuizItems",
                columns: new[] { "Id", "CorrectAnswer", "Question" },
                values: new object[,]
                {
                    { 1, "5", "2 + 3" },
                    { 2, "6", "2 * 3" },
                    { 3, "5", "8 - 3" },
                    { 4, "4", "8 : 2" },
                    { 5, "10", "7 + 3" },
                    { 6, "16", "2 * 8" },
                    { 7, "8", "2^3" },
                    { 8, "40", "8 * 5" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Matematyka" },
                    { 2, "Arytmetyka" }
                });

            migrationBuilder.InsertData(
                table: "QuizEntityQuizItemEntity",
                columns: new[] { "ItemsId", "QuizzesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "QuizItemAnswerEntityQuizItemEntity",
                columns: new[] { "IncorrectAnswersId", "QuizItemsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 2 },
                    { 6, 4 },
                    { 6, 8 },
                    { 7, 2 },
                    { 7, 6 },
                    { 8, 4 },
                    { 9, 3 },
                    { 10, 6 },
                    { 10, 7 },
                    { 11, 5 },
                    { 11, 7 },
                    { 12, 5 },
                    { 12, 8 },
                    { 13, 5 },
                    { 13, 7 },
                    { 14, 6 },
                    { 14, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizEntityQuizItemEntity_QuizzesId",
                table: "QuizEntityQuizItemEntity",
                column: "QuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizItemAnswerEntityQuizItemEntity_QuizItemsId",
                table: "QuizItemAnswerEntityQuizItemEntity",
                column: "QuizItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuizItemId",
                table: "UserAnswers",
                column: "QuizItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizEntityQuizItemEntity");

            migrationBuilder.DropTable(
                name: "QuizItemAnswerEntityQuizItemEntity");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuizItems");
        }
    }
}
