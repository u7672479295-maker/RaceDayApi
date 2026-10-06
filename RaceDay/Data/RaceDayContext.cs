using Microsoft.EntityFrameworkCore;
using RaceDayApi.Models;
namespace RaceDayApi.Data
{
    public class RaceDayContext : DbContext
    {
        public RaceDayContext(DbContextOptions<RaceDayContext> options) :
            base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //for configuring the unique emails
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            //configuring one-to-one relationship between user and emergencycontact
            modelBuilder.Entity<EmergencyContact>()
                .HasOne(ec => ec.ParticipantUser)
                .WithOne(u => u.EmergencyContact)
                .HasForeignKey<EmergencyContact>(ec => ec.ParticipantUserId)
                .OnDelete(DeleteBehavior.Cascade);

            //configuring one-to-one relationship between Enrolment and Result
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Enrolment)
                .WithOne(e => e.Result)
                .HasForeignKey<Result>(r => r.EnrolmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrolment>()
                .HasOne(e => e.ParticipantUser)
                .WithMany(u => u.Enrolments)
                .HasForeignKey(e => e.ParticipantUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrolment>()
                .HasOne(e => e.Event)
                .WithMany(ev => ev.Enrolments)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}