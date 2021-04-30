using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Actitudes
    {
        [Key]
        public string Codigo { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Pregunta1 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta2 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta3 { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Pregunta4 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta5 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta6 { get; set; }
         [Column(TypeName = "varchar(12)")]
        public string Idpersona{ get; set; }

    [Column(TypeName = "decimal(4)")]
        public decimal Total{ get; set; }

        public void Calcularpuntos(){
            decimal punto1,punto2,punto3,punto5,punto6;
            punto1 = Convert.ToDecimal(Pregunta1);
            punto2 = Convert.ToDecimal(Pregunta2);
            punto3 = Convert.ToDecimal(Pregunta3);
            punto5 = Convert.ToDecimal(Pregunta5);
            punto6 = Convert.ToDecimal(Pregunta6);
            Total = punto1+punto2+punto3+punto5+punto6;
        }
    }
}