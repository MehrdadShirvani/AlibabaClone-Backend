using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketOrderAndCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Accounts_BuyerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Transportations_TransportationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Tickets_TicketId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Transactions",
                newName: "TicketOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TicketId",
                table: "Transactions",
                newName: "IX_Transactions_TicketOrderId");

            migrationBuilder.RenameColumn(
                name: "TransportationId",
                table: "Tickets",
                newName: "TicketOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TransportationId",
                table: "Tickets",
                newName: "IX_Tickets_TicketOrderId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledAt",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxUsages = table.Column<int>(type: "int", nullable: false),
                    MaxUsagesPerAccount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportationId = table.Column<long>(type: "bigint", nullable: false),
                    BuyerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketOrder_Accounts_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketOrder_Transportations_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CouponId",
                table: "Transactions",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SerialNumber",
                table: "Tickets",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_BuyerId",
                table: "TicketOrder",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_Id",
                table: "TicketOrder",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_TransportationId",
                table: "TicketOrder",
                column: "TransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrder_TicketOrderId",
                table: "Tickets",
                column: "TicketOrderId",
                principalTable: "TicketOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Coupon_CouponId",
                table: "Transactions",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TicketOrder_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                principalTable: "TicketOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrder_TicketOrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Coupon_CouponId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TicketOrder_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "TicketOrder");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CouponId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SerialNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CanceledAt",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketOrderId",
                table: "Transactions",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions",
                newName: "IX_Transactions_TicketId");

            migrationBuilder.RenameColumn(
                name: "TicketOrderId",
                table: "Tickets",
                newName: "TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketOrderId",
                table: "Tickets",
                newName: "IX_Tickets_TransportationId");

            migrationBuilder.AddColumn<long>(
                name: "BuyerId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Accounts_BuyerId",
                table: "Tickets",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Transportations_TransportationId",
                table: "Tickets",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Tickets_TicketId",
                table: "Transactions",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
