using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistema_Onawa_Deco.Models
{
    public partial class OnawaDecoDbContext : DbContext
    {
        public OnawaDecoDbContext()
        {
        }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Seminario> Seminarios { get; set; }
        public DbSet<ProfesorSeminario> ProfesorSeminarios { get; set; }
        public DbSet<SeminarioSocio> SocioSeminario { get; set; }
        public OnawaDecoDbContext(DbContextOptions<OnawaDecoDbContext> options)
            : base(options)
        {
        }
    


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*  if (!optionsBuilder.IsConfigured)
              {
                   optionsBuilder.UseSqlServer("Server=BANGO-MAX-LUCIA\\SQLEXPRESS;Database=Onawa_Deco;user=sa;password=Password_123;Trusted_Connection=True;");
              }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);

            //Genero la clave de muchos a muchos para los socios y los seminarios
            modelBuilder.Entity<SeminarioSocio>().HasKey(pv => new { pv.SocioId, pv.SeminarioId });

            modelBuilder.Entity<SeminarioSocio>()
            .HasOne<Socio>(sa => sa.Socio)
            .WithMany(s => s.SocioSeminarios)
            .HasForeignKey(pv => pv.SocioId);


            modelBuilder.Entity<SeminarioSocio>()
            .HasOne<Seminario>(sa => sa.Seminario)
            .WithMany(a => a.SocioSeminarios)
            .HasForeignKey(sa => sa.SeminarioId);

            //Genero la clave de muchos a muchos para los profesores y los seminarios
            modelBuilder.Entity<ProfesorSeminario>().HasKey(pv => new { pv.ProfesorDni, pv.SeminarioId });

            modelBuilder.Entity<ProfesorSeminario>()
            .HasOne<Profesor>(sa => sa.Profesor)
            .WithMany(s => s.ProfesorSeminarios)
            .HasForeignKey(pv => pv.ProfesorDni);


            modelBuilder.Entity<ProfesorSeminario>()
            .HasOne<Seminario>(sa => sa.Seminario)
            .WithMany(a => a.ProfesorSeminarios)
            .HasForeignKey(sa => sa.SeminarioId);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
