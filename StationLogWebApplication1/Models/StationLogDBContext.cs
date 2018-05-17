namespace StationLogWebApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StationLogDBContext : DbContext
    {
        public StationLogDBContext()
            : base("name=StationLogDBContext")
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
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.Log)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Log>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Log)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monitor>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.Monitor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monitor>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Monitor)
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
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
