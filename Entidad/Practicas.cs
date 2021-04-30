using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Practicas
    {
        [Key]
        public string Codigo { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Pregunta1 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Pregunta3 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Pregunta4 { get; set; }
         [Column(TypeName = "varchar(12)")]
        public string Idpersona{ get; set; }

        [Column(TypeName = "decimal(4)")]
        public decimal Total{ get; set; }
        


        public void Calcularpuntos(){
            decimal punto1,punto2,punto4;
            punto1 = Convert.ToDecimal(Pregunta1);
            punto2 = Convert.ToDecimal(Pregunta2);
            punto4 = Convert.ToDecimal(Pregunta4);
            Total = punto1+punto2+punto4;
        }
    }

}