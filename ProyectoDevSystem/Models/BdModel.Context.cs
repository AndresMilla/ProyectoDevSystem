//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoDevSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_PROYECTOEntities : DbContext
    {
        public DB_PROYECTOEntities()
            : base("name=DB_PROYECTOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ENCUESTA> ENCUESTAs { get; set; }
        public virtual DbSet<PREGUNTA> PREGUNTAS { get; set; }
        public virtual DbSet<RESPUESTA> RESPUESTAS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
    }
}
