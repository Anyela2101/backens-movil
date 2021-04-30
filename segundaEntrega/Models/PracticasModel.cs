using System;
using Entidad;
using System.ComponentModel.DataAnnotations;

namespace segundaEntrega.Models
{
    public class PracticasInputModel{
        public string Codigo{get;set;}
        
        public string Pregunta1 {get;set;}
        public string Pregunta2 {get;set;}
        public string Pregunta3 {get;set;}
        public string Pregunta4 {get;set;}
        public string Idpersona {get;set;}
    }

    public class PracticasViewModel : PracticasInputModel
    {
        public PracticasViewModel()
        {

        }
        public PracticasViewModel(Practicas practicas)
        {
            Pregunta1 = practicas.Pregunta1;
            Pregunta2 = practicas.Pregunta2;
            Pregunta3 = practicas.Pregunta3;
            Pregunta4 = practicas.Pregunta4;
            Idpersona = practicas.Idpersona;
            Codigo = practicas.Idpersona;
        }
    }
}