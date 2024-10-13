﻿// <auto-generated />
using System;
using CargoManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CargoManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CargoManagementSystem.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__admin__3213E83F6B2E18D9");

                    b.HasIndex("UserId");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("amount_paid");

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("datetime")
                        .HasColumnName("booking_date");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int?>("ParcelId")
                        .HasColumnType("int")
                        .HasColumnName("parcel_id");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("payment_status");

                    b.HasKey("Id")
                        .HasName("PK__booking__3213E83FC82BF2B2");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ParcelId");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("state_id");

                    b.HasKey("Id")
                        .HasName("PK__city__3213E83FEF0DB305");

                    b.HasIndex("StateId");

                    b.ToTable("city");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Contactus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("PK__contactu__3213E83F52E76BFB");

                    b.ToTable("contactus");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__country__3213E83FC3B0807D");

                    b.ToTable("country");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__customer__3213E83F2F848D3E");

                    b.HasIndex("UserId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Deliveryroute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("DistanceKm")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("distance_km");

                    b.Property<int?>("FromCityId")
                        .HasColumnType("int")
                        .HasColumnName("from_city_id");

                    b.Property<int?>("ToCityId")
                        .HasColumnType("int")
                        .HasColumnName("to_city_id");

                    b.HasKey("Id")
                        .HasName("PK__delivery__3213E83F3E3DE79D");

                    b.HasIndex("FromCityId");

                    b.HasIndex("ToCityId");

                    b.ToTable("deliveryroute");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__employee__3213E83F80E2DB3A");

                    b.HasIndex("UserId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<string>("FeedbackText")
                        .HasColumnType("text")
                        .HasColumnName("feedback_text");

                    b.HasKey("Id")
                        .HasName("PK__feedback__3213E83F3457BB74");

                    b.HasIndex("CreatedBy");

                    b.ToTable("feedback");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<string>("CustmerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__invoice__3213E83F0C3D42E5");

                    b.HasIndex("BookingId");

                    b.ToTable("invoice");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int?>("FromCityId")
                        .HasColumnType("int")
                        .HasColumnName("from_city_id");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("height");

                    b.Property<decimal?>("Lenght")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("lenght");

                    b.Property<string>("ParcelType")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("parcel_type");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int?>("ToCityId")
                        .HasColumnType("int")
                        .HasColumnName("to_city_id");

                    b.Property<string>("TrackingId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tracking_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("weight");

                    b.Property<decimal?>("Width")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("width");

                    b.HasKey("Id")
                        .HasName("PK__parcel__3213E83F3BE0D3D3");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FromCityId");

                    b.HasIndex("ToCityId");

                    b.HasIndex(new[] { "TrackingId" }, "UQ__parcel__7AC3E9AF6CA7E7C5")
                        .IsUnique();

                    b.ToTable("parcel");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Parcelstatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ParcelId")
                        .HasColumnType("int")
                        .HasColumnName("parcel_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int>("UpdateByUserId")
                        .HasColumnType("int")
                        .HasColumnName("update_by_user_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("PK__parcelst__3213E83F098127BE");

                    b.HasIndex("ParcelId");

                    b.HasIndex("UpdateByUserId");

                    b.ToTable("parcelstatus");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Pricing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("BasePrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("base_price");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<decimal?>("PricePerKg")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price_per_kg");

                    b.Property<decimal?>("PricePerKm")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price_per_km");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("PK__pricing__3213E83F33D1C0EF");

                    b.ToTable("pricing");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__state__3213E83F4073DBA3");

                    b.HasIndex("CountryId");

                    b.ToTable("state");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateJoined")
                        .HasColumnType("datetime")
                        .HasColumnName("date_joined");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("password_salt");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK___user__3213E83F3E6A2DE4");

                    b.ToTable("_user");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Admin", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.User", "User")
                        .WithMany("Admins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__admin__user_id__398D8EEE");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Booking", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__booking__custome__5CD6CB2B");

                    b.HasOne("CargoManagementSystem.Models.Parcel", "Parcel")
                        .WithMany("Bookings")
                        .HasForeignKey("ParcelId")
                        .HasConstraintName("FK__booking__parcel___5DCAEF64");

                    b.Navigation("Customer");

                    b.Navigation("Parcel");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.City", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK__city__state_id__48CFD27E");

                    b.Navigation("State");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Customer", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__customer__user_i__3C69FB99");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Deliveryroute", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.City", "FromCity")
                        .WithMany("DeliveryrouteFromCities")
                        .HasForeignKey("FromCityId")
                        .HasConstraintName("FK__deliveryr__from___60A75C0F");

                    b.HasOne("CargoManagementSystem.Models.City", "ToCity")
                        .WithMany("DeliveryrouteToCities")
                        .HasForeignKey("ToCityId")
                        .HasConstraintName("FK__deliveryr__to_ci__619B8048");

                    b.Navigation("FromCity");

                    b.Navigation("ToCity");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Employee", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.User", "User")
                        .WithMany("Employees")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__employee__user_i__3F466844");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Feedback", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.Customer", "CreatedByNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__feedback__create__4BAC3F29");

                    b.Navigation("CreatedByNavigation");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Invoice", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.Booking", "Booking")
                        .WithMany("Invoices")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK__invoice__Booking__6477ECF3");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Parcel", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.Customer", "Customer")
                        .WithMany("Parcels")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__parcel__customer__5812160E");

                    b.HasOne("CargoManagementSystem.Models.City", "FromCity")
                        .WithMany("ParcelFromCities")
                        .HasForeignKey("FromCityId")
                        .HasConstraintName("FK__parcel__from_cit__59063A47");

                    b.HasOne("CargoManagementSystem.Models.City", "ToCity")
                        .WithMany("ParcelToCities")
                        .HasForeignKey("ToCityId")
                        .HasConstraintName("FK__parcel__to_city___59FA5E80");

                    b.Navigation("Customer");

                    b.Navigation("FromCity");

                    b.Navigation("ToCity");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Parcelstatus", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.Parcel", "Parcel")
                        .WithMany("Parcelstatuses")
                        .HasForeignKey("ParcelId")
                        .HasConstraintName("FK__parcelsta__parce__6754599E");

                    b.HasOne("CargoManagementSystem.Models.User", "UpdateByUser")
                        .WithMany("Parcelstatuses")
                        .HasForeignKey("UpdateByUserId")
                        .IsRequired()
                        .HasConstraintName("FK__parcelsta__updat__68487DD7");

                    b.Navigation("Parcel");

                    b.Navigation("UpdateByUser");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.State", b =>
                {
                    b.HasOne("CargoManagementSystem.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK__state__country_i__45F365D3");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Booking", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.City", b =>
                {
                    b.Navigation("DeliveryrouteFromCities");

                    b.Navigation("DeliveryrouteToCities");

                    b.Navigation("ParcelFromCities");

                    b.Navigation("ParcelToCities");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Feedbacks");

                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.Parcel", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Parcelstatuses");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("CargoManagementSystem.Models.User", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("Parcelstatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
