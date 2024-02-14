using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class postgre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Pincode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false),
                    AadharNumber = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    AccountDetailsAccountNumber = table.Column<string>(type: "text", nullable: true),
                    InitialAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customers_account_AccountDetailsAccountNumber",
                        column: x => x.AccountDetailsAccountNumber,
                        principalTable: "account",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_customers_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tezoBank",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tezoBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tezoBank_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    UserAccountId = table.Column<string>(type: "text", nullable: false),
                    ReceiverAccountId = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transaction_customers_ReceiverAccountId",
                        column: x => x.ReceiverAccountId,
                        principalTable: "customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transaction_customers_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_AccountDetailsAccountNumber",
                table: "customers",
                column: "AccountDetailsAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_customers_AddressId",
                table: "customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tezoBank_CustomerId",
                table: "tezoBank",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_ReceiverAccountId",
                table: "transaction",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_UserAccountId",
                table: "transaction",
                column: "UserAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tezoBank");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
