namespace WebApplication_v._1._1.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Заявители> Заявителиs { get; set; }
        public DbSet<Сотрудники> Сотрудникиs { get; set; }
        public DbSet<Филиалы> Филиалыs { get; set; }
        public DbSet<ФилиалыСотрудники> ФилиалыСотрудникиs { get; set; }
        public DbSet<Принятые_заявления> Принятые_заявленияs { get; set; }
        public IQueryable<Принятые_заявления> Принятые_Заявленияs { get; internal set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ФилиалыСотрудники>()       // THIS IS FIRST
        .HasOne(u => u.Филиалы).WithMany(u => u.ФилиалыСотрудникиs).IsRequired().OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ФилиалыСотрудники>()
                .HasKey(t => new { t.id_s, t.id_f });

            modelBuilder.Entity<ФилиалыСотрудники>()
                .HasOne(pt => pt.Сотрудники)
                .WithMany(p => p.ФилиалыСотрудникиs)
                .HasForeignKey(pt => pt.id_s);

            modelBuilder.Entity<ФилиалыСотрудники>()       // THIS IS SECOND.
                .HasOne(eu => eu.Филиалы)               // THIS LINES
                .WithMany(e => e.ФилиалыСотрудникиs)       //   SHOULD BE
                .HasForeignKey(eu => eu.id_f);     //   REMOVED
        }
     }
}
