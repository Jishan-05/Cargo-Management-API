using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordSaltToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    role = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    date_joined = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___user__3213E83F3E6A2DE4", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contactus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__contactu__3213E83F52E76BFB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__country__3213E83FC3B0807D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pricing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    base_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    price_per_km = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    price_per_kg = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pricing__3213E83F33D1C0EF", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__admin__3213E83F6B2E18D9", x => x.id);
                    table.ForeignKey(
                        name: "FK__admin__user_id__398D8EEE",
                        column: x => x.user_id,
                        principalTable: "_user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__3213E83F2F848D3E", x => x.id);
                    table.ForeignKey(
                        name: "FK__customer__user_i__3C69FB99",
                        column: x => x.user_id,
                        principalTable: "_user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3213E83F80E2DB3A", x => x.id);
                    table.ForeignKey(
                        name: "FK__employee__user_i__3F466844",
                        column: x => x.user_id,
                        principalTable: "_user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__state__3213E83F4073DBA3", x => x.id);
                    table.ForeignKey(
                        name: "FK__state__country_i__45F365D3",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    feedback_text = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__feedback__3213E83F3457BB74", x => x.id);
                    table.ForeignKey(
                        name: "FK__feedback__create__4BAC3F29",
                        column: x => x.created_by,
                        principalTable: "customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    state_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__city__3213E83FEF0DB305", x => x.id);
                    table.ForeignKey(
                        name: "FK__city__state_id__48CFD27E",
                        column: x => x.state_id,
                        principalTable: "state",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "deliveryroute",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_city_id = table.Column<int>(type: "int", nullable: true),
                    to_city_id = table.Column<int>(type: "int", nullable: true),
                    distance_km = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__delivery__3213E83F3E3DE79D", x => x.id);
                    table.ForeignKey(
                        name: "FK__deliveryr__from___60A75C0F",
                        column: x => x.from_city_id,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__deliveryr__to_ci__619B8048",
                        column: x => x.to_city_id,
                        principalTable: "city",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "parcel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tracking_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    parcel_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    from_city_id = table.Column<int>(type: "int", nullable: true),
                    to_city_id = table.Column<int>(type: "int", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    height = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    lenght = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    width = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__parcel__3213E83F3BE0D3D3", x => x.id);
                    table.ForeignKey(
                        name: "FK__parcel__customer__5812160E",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__parcel__from_cit__59063A47",
                        column: x => x.from_city_id,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__parcel__to_city___59FA5E80",
                        column: x => x.to_city_id,
                        principalTable: "city",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parcel_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    booking_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    amount_paid = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    payment_status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__booking__3213E83FC82BF2B2", x => x.id);
                    table.ForeignKey(
                        name: "FK__booking__custome__5CD6CB2B",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__booking__parcel___5DCAEF64",
                        column: x => x.parcel_id,
                        principalTable: "parcel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "parcelstatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parcel_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    update_by_user_id = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__parcelst__3213E83F098127BE", x => x.id);
                    table.ForeignKey(
                        name: "FK__parcelsta__parce__6754599E",
                        column: x => x.parcel_id,
                        principalTable: "parcel",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__parcelsta__updat__68487DD7",
                        column: x => x.update_by_user_id,
                        principalTable: "_user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateOnly>(type: "date", nullable: false),
                    CustmerName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Price = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invoice__3213E83F0C3D42E5", x => x.id);
                    table.ForeignKey(
                        name: "FK__invoice__Booking__6477ECF3",
                        column: x => x.BookingId,
                        principalTable: "booking",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_admin_user_id",
                table: "admin",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_customer_id",
                table: "booking",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_parcel_id",
                table: "booking",
                column: "parcel_id");

            migrationBuilder.CreateIndex(
                name: "IX_city_state_id",
                table: "city",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_user_id",
                table: "customer",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_deliveryroute_from_city_id",
                table: "deliveryroute",
                column: "from_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_deliveryroute_to_city_id",
                table: "deliveryroute",
                column: "to_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_user_id",
                table: "employee",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_created_by",
                table: "feedback",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_BookingId",
                table: "invoice",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_parcel_customer_id",
                table: "parcel",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_parcel_from_city_id",
                table: "parcel",
                column: "from_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_parcel_to_city_id",
                table: "parcel",
                column: "to_city_id");

            migrationBuilder.CreateIndex(
                name: "UQ__parcel__7AC3E9AF6CA7E7C5",
                table: "parcel",
                column: "tracking_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_parcelstatus_parcel_id",
                table: "parcelstatus",
                column: "parcel_id");

            migrationBuilder.CreateIndex(
                name: "IX_parcelstatus_update_by_user_id",
                table: "parcelstatus",
                column: "update_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_country_id",
                table: "state",
                column: "country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "contactus");

            migrationBuilder.DropTable(
                name: "deliveryroute");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "parcelstatus");

            migrationBuilder.DropTable(
                name: "pricing");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "parcel");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "_user");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
