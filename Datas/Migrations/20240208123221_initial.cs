using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    AccountHolderId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "accountHolder",
                columns: table => new
                {
                    AccountHolderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountHolder", x => x.AccountHolderId);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountHolderId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    UserAccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDetailsAddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountDetailsAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InitialAmount = table.Column<double>(type: "float", nullable: false),
                    AccountHolderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountHolderId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_customers_accountHolder_AccountHolderId",
                        column: x => x.AccountHolderId,
                        principalTable: "accountHolder",
                        principalColumn: "AccountHolderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customers_accountHolder_AccountHolderId1",
                        column: x => x.AccountHolderId1,
                        principalTable: "accountHolder",
                        principalColumn: "AccountHolderId");
                    table.ForeignKey(
                        name: "FK_customers_account_AccountDetailsAccountNumber",
                        column: x => x.AccountDetailsAccountNumber,
                        principalTable: "account",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_customers_addresses_AddressDetailsAddressId",
                        column: x => x.AddressDetailsAddressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_AccountDetailsAccountNumber",
                table: "customers",
                column: "AccountDetailsAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_customers_AccountHolderId",
                table: "customers",
                column: "AccountHolderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_AccountHolderId1",
                table: "customers",
                column: "AccountHolderId1");

            migrationBuilder.CreateIndex(
                name: "IX_customers_AddressDetailsAddressId",
                table: "customers",
                column: "AddressDetailsAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "accountHolder");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
