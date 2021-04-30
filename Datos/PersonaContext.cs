using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class PersonaContext: DbContext
    {
        public PersonaContext(DbContextOptions options): base(options){
        }
        public DbSet<Persona> Personas {get;set;}
         public DbSet<Restaurante> Restaurantes {get;set;}
         public DbSet <Usuario> Usuarios {get;set;}
         public DbSet <Conocimientos> Conocimientos {get;set;}
         public DbSet <Actitudes> Actitudes {get;set;}
         public DbSet <Practicas> Practicas {get;set;}
         public DbSet <ListaChequeo> ListaChequeos {get;set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder){
             modelBuilder
                .Entity<Persona>()
                .HasOne<Restaurante>()
                .WithMany()
                .HasForeignKey(p => p.Idrestaurante);
                modelBuilder
                .Entity<Conocimientos>()
                .HasOne<Persona>()
                .WithMany()
                .HasForeignKey(p => p.Idpersona);
                 modelBuilder
                .Entity<Actitudes>()
                .HasOne<Persona>()
                .WithMany()
                .HasForeignKey(p => p.Idpersona);
                 modelBuilder
                .Entity<Practicas>()
                .HasOne<Persona>()
                .WithMany()
                .HasForeignKey(p => p.Idpersona);
                modelBuilder
                .Entity<ListaChequeo>()
                .HasOne<Restaurante>()
                .WithMany()
                .HasForeignKey(p => p.nit);
         }

    }
}