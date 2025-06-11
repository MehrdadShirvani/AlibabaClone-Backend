using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MajorAndMinorUpdateAfterProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountDetail_Accounts_AccountId",
                table: "BankAccountDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrder_Accounts_BuyerId",
                table: "TicketOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrder_Transportations_TransportationId",
                table: "TicketOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrder_TicketOrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Coupon_CouponId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TicketOrder_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_People_IdNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrder",
                table: "TicketOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccountDetail",
                table: "BankAccountDetail");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TicketOrder",
                newName: "TicketOrders");

            migrationBuilder.RenameTable(
                name: "Coupon",
                newName: "Coupons");

            migrationBuilder.RenameTable(
                name: "BankAccountDetail",
                newName: "BankAccountDetails");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionType_Title",
                table: "TransactionTypes",
                newName: "IX_TransactionTypes_Title");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_TransportationId",
                table: "TicketOrders",
                newName: "IX_TicketOrders_TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_Id",
                table: "TicketOrders",
                newName: "IX_TicketOrders_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_BuyerId",
                table: "TicketOrders",
                newName: "IX_TicketOrders_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccountDetail_AccountId",
                table: "BankAccountDetails",
                newName: "IX_BankAccountDetails_AccountId");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorAccountId",
                table: "People",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccountDetails",
                table: "BankAccountDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                unique: true,
                filter: "[TicketOrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_People_CreatorAccountId",
                table: "People",
                column: "CreatorAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountDetails_Accounts_AccountId",
                table: "BankAccountDetails",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Accounts_CreatorAccountId",
                table: "People",
                column: "CreatorAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_Accounts_BuyerId",
                table: "TicketOrders",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_Transportations_TransportationId",
                table: "TicketOrders",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrders_TicketOrderId",
                table: "Tickets",
                column: "TicketOrderId",
                principalTable: "TicketOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Coupons_CouponId",
                table: "Transactions",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TicketOrders_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                principalTable: "TicketOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountDetails_Accounts_AccountId",
                table: "BankAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Accounts_CreatorAccountId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_Accounts_BuyerId",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_Transportations_TransportationId",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrders_TicketOrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Coupons_CouponId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TicketOrders_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_People_CreatorAccountId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccountDetails",
                table: "BankAccountDetails");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatorAccountId",
                table: "People");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TicketOrders",
                newName: "TicketOrder");

            migrationBuilder.RenameTable(
                name: "Coupons",
                newName: "Coupon");

            migrationBuilder.RenameTable(
                name: "BankAccountDetails",
                newName: "BankAccountDetail");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionTypes_Title",
                table: "TransactionType",
                newName: "IX_TransactionType_Title");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_TransportationId",
                table: "TicketOrder",
                newName: "IX_TicketOrder_TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_Id",
                table: "TicketOrder",
                newName: "IX_TicketOrder_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_BuyerId",
                table: "TicketOrder",
                newName: "IX_TicketOrder_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccountDetails_AccountId",
                table: "BankAccountDetail",
                newName: "IX_BankAccountDetail_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrder",
                table: "TicketOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccountDetail",
                table: "BankAccountDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_People_IdNumber",
                table: "People",
                column: "IdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountDetail_Accounts_AccountId",
                table: "BankAccountDetail",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrder_Accounts_BuyerId",
                table: "TicketOrder",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrder_Transportations_TransportationId",
                table: "TicketOrder",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
