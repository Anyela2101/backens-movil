using System.Data;
using System.IO;
using System.Security.AccessControl;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [Column(TypeName = "varchar(12)")]
        public string Identificacion { get; set; }
        
        [Column(TypeName = "varchar(20)")]
        public string Nombres { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Apellidos { get; set; }

        [Column(TypeName = "int")]
        public int Edad { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Sexo { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Telefono { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string EstadoCivil { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string PaisProcedencia { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string NivelEducativo { get; set; }
        public Usuario Usuario { get; set; }
        
        [Column(TypeName = "varchar(15)")]
        public string Idrestaurante { get; set; }



    }
}
