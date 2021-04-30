
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class ListaChequeo
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string Codigo { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Pregunta1 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta2 { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Pregunta3 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Pregunta4 { get; set; }
         [Column(TypeName = "varchar(12)")]
         public string Pregunta5 { get; set; }
         [Column(TypeName = "varchar(12)")]
         public string Pregunta6 { get; set; }
         [Column(TypeName = "varchar(12)")]
         public string Pregunta7 { get; set; }
         [Column(TypeName = "varchar(12)")]
         public string Pregunta8 { get; set; }
         [Column(TypeName = "varchar(12)")]

         public string Pregunta9 { get; set; }
         [Column(TypeName = "varchar(15)")]

        public string nit{ get; set; }
         [Column(TypeName = "float")]
        public float Total{ get; set; }

        public void Calcularpuntos(){
            float punto1,punto2,punto3,punto4,punto5,punto6,punto7,punto8,punto9;
            punto1 = float.Parse(Pregunta1);
            punto2 = float.Parse(Pregunta2);
            punto3 = float.Parse(Pregunta3);
            punto4 = float.Parse(Pregunta4);
            punto5 = float.Parse(Pregunta5);
            punto6 = float.Parse(Pregunta6);
            punto7 = float.Parse(Pregunta7);
            punto8 = float.Parse(Pregunta8);
            punto9 = float.Parse(Pregunta9);
            Total = punto1+punto2+punto3+punto4+punto5+punto6+punto7+punto8+punto9;
        }

    }
}