using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryExpenseName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CategoryExpenseId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_CategoryExpenses_CategoryExpenseId",
                        column: x => x.CategoryExpenseId,
                        principalTable: "CategoryExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryExpenses",
                columns: new[] { "Id", "CategoryExpenseName" },
                values: new object[,]
                {
                    { 1, "Еда" },
                    { 2, "Транспорт" },
                    { 3, "Одежда" },
                    { 4, "Развлечения" },
                    { 5, "Образование" },
                    { 6, "Здоровье" },
                    { 7, "КоммунальныеУслуги" },
                    { 8, "Кредиты" },
                    { 9, "ДомашниеЖивотные" },
                    { 10, "Путешествия" },
                    { 11, "ЛичныеРасходы" },
                    { 12, "Благотворительность" },
                    { 13, "Абонементы" },
                    { 14, "Подарок" },
                    { 15, "Другое" }
                });

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryIncomeName",
                value: "Премия");

            migrationBuilder.InsertData(
                table: "CategoryIncomes",
                columns: new[] { "Id", "CategoryIncomeName" },
                values: new object[,]
                {
                    { 3, "Подработка" },
                    { 4, "Дивиденды" },
                    { 5, "Проценты" },
                    { 6, "Подарки" },
                    { 7, "Продажа" },
                    { 8, "СдачаВАренду" },
                    { 9, "СоциальныеВыплаты" },
                    { 10, "Пенсия" },
                    { 11, "Стипендия" },
                    { 12, "ВозвратДолгов" },
                    { 13, "ДругиеДоходы" }
                });

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrencyName",
                value: "RUB");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrencyName",
                value: "USD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrencyName",
                value: "EUR");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryExpenseId",
                table: "Expenses",
                column: "CategoryExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyId",
                table: "Expenses",
                column: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "CategoryExpenses");

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryIncomeName",
                value: "Подарок");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrencyName",
                value: "USD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrencyName",
                value: "EUR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrencyName",
                value: "RUB");
        }
    }
}
