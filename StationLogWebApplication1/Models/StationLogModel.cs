namespace StationLogWebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StationLogModel : DbContext
    {
        public StationLogModel()
            : base("name=StationLogModel")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Messages)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.Monitor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Alerts)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Equipments)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
