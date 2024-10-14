using System;
using System.Collections.Generic;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Contactus> Contactus { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deliveryroute> Deliveryroutes { get; set; }
    

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Parcel> Parcels { get; set; }

    public virtual DbSet<Parcelstatus> Parcelstatuses { get; set; }

    public virtual DbSet<Pricing> Pricings { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=DESKTOP-69I9EEJ\\SQLEXPRESS;database=CargoMSdb;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admin__3213E83F6B2E18D9");

            entity.HasOne(d => d.User).WithMany(p => p.Admins).HasConstraintName("FK__admin__user_id__398D8EEE");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__booking__3213E83FC82BF2B2");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings).HasConstraintName("FK__booking__custome__5CD6CB2B");

            entity.HasOne(d => d.Parcel).WithMany(p => p.Bookings).HasConstraintName("FK__booking__parcel___5DCAEF64");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__city__3213E83FEF0DB305");

            entity.HasOne(d => d.State).WithMany(p => p.Cities).HasConstraintName("FK__city__state_id__48CFD27E");
        });

        modelBuilder.Entity<Contactus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contactu__3213E83F52E76BFB");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__country__3213E83FC3B0807D");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F2F848D3E");

            entity.HasOne(d => d.User).WithMany(p => p.Customers).HasConstraintName("FK__customer__user_i__3C69FB99");
        });
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F2F848D3E");

            // Specify the foreign key constraint and set Cascade delete behavior
            entity.HasOne(d => d.User)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__customer__user_i__3C69FB99")
                .OnDelete(DeleteBehavior.Cascade); // Enable Cascade Delete
        });

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Deliveryroute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__delivery__3213E83F3E3DE79D");

            entity.HasOne(d => d.FromCity).WithMany(p => p.DeliveryrouteFromCities).HasConstraintName("FK__deliveryr__from___60A75C0F");

            entity.HasOne(d => d.ToCity).WithMany(p => p.DeliveryrouteToCities).HasConstraintName("FK__deliveryr__to_ci__619B8048");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F80E2DB3A");

            entity.HasOne(d => d.User).WithMany(p => p.Employees).HasConstraintName("FK__employee__user_i__3F466844");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__feedback__3213E83F3457BB74");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Feedbacks).HasConstraintName("FK__feedback__create__4BAC3F29");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__invoice__3213E83F0C3D42E5");

            entity.HasOne(d => d.Booking).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__invoice__Booking__6477ECF3");
        });

        modelBuilder.Entity<Parcel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parcel__3213E83F3BE0D3D3");

            entity.HasOne(d => d.Customer).WithMany(p => p.Parcels).HasConstraintName("FK__parcel__customer__5812160E");

            entity.HasOne(d => d.FromCity).WithMany(p => p.ParcelFromCities).HasConstraintName("FK__parcel__from_cit__59063A47");

            entity.HasOne(d => d.ToCity).WithMany(p => p.ParcelToCities).HasConstraintName("FK__parcel__to_city___59FA5E80");
        });

        modelBuilder.Entity<Parcelstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parcelst__3213E83F098127BE");

            entity.HasOne(d => d.Parcel).WithMany(p => p.Parcelstatuses).HasConstraintName("FK__parcelsta__parce__6754599E");

            entity.HasOne(d => d.UpdateByUser).WithMany(p => p.Parcelstatuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__parcelsta__updat__68487DD7");
        });

        modelBuilder.Entity<Pricing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pricing__3213E83F33D1C0EF");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__state__3213E83F4073DBA3");

            entity.HasOne(d => d.Country).WithMany(p => p.States).HasConstraintName("FK__state__country_i__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___user__3213E83F3E6A2DE4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
