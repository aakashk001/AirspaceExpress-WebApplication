using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class AirspaceExpressContext : DbContext
    {
        public AirspaceExpressContext()
        {
        }

        public AirspaceExpressContext(DbContextOptions<AirspaceExpressContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Fare> Fare { get; set; }
        public virtual DbSet<FlightData> FlightData { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<PassengerDetails> PassengerDetails { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        public virtual DbSet<AvailbleFlights> AvailbleFlights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("AirspaceConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("pk_bookingId");

                entity.Property(e => e.BookingId)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BookingCost).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.DeparturDate).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightIndex).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.NoOfTicket).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.TicketStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TravelBookingClass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FlightIndexNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FlightIndex)
                    .HasConstraintName("fk_BookingFlightIndex");
            });

            modelBuilder.Entity<Fare>(entity =>
            {
                entity.Property(e => e.FareId)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BaseFare).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightIndex).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.FlightIndexNavigation)
                    .WithMany(p => p.Fare)
                    .HasForeignKey(d => d.FlightIndex)
                    .HasConstraintName("fk_FlightIndex");
            });

            modelBuilder.Entity<FlightData>(entity =>
            {
                entity.HasKey(e => e.Sdid)
                    .HasName("pk_sdid");

                entity.Property(e => e.Sdid)
                    .HasColumnName("SDID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Destination)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.FlightIndex)
                    .HasName("pk_flightIndex");

                entity.Property(e => e.FlightIndex)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ArivalTime).HasColumnType("datetime");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.FlightId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sdid)
                    .HasColumnName("SDID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SeatsAvailable).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Stops).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Sd)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.Sdid)
                    .HasConstraintName("fk_sdid");
            });

            modelBuilder.Entity<PassengerDetails>(entity =>
            {
                entity.HasKey(e => e.PassengerId)
                    .HasName("pk_PrimaryKey");

                entity.Property(e => e.PassengerId)
                    .HasColumnName("PassengerID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BookingId).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightIndex).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PassengerAge).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("fk_passengerBookingId");

                entity.HasOne(d => d.FlightIndexNavigation)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.FlightIndex)
                    .HasConstraintName("fk_passengerflightIndex");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_userdata");

                entity.ToTable("userData");

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WalletAmount).HasColumnType("numeric(10, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
