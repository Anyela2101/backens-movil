using System;
using Entidad;
using System.ComponentModel.DataAnnotations;

namespace segundaEntrega.Models
{
    public class ActitudesInputModel{
        public string Codigo{get;set;}
        public string Pregunta1 {get;set;}
        public string Pregunta2 {get;set;}
        public string Pregunta3 {get;set;}
        public string Pregunta4 {get;set;}
        public string Pregunta5 {get;set;}
        public string Pregunta6 {get;set;}
        public string Idpersona {get;set;}
    }

    public class ActitudesViewModel : ActitudesInputModel
    {
        public ActitudesViewModel()
        {

        }
        public ActitudesViewModel(Actitudes actitudes)
        {
            Pregunta1 = actitudes.Pregunta1;
            Pregunta2 = actitudes.Pregunta2;
            Pregunta3 = actitudes.Pregunta3;
            Pregunta4 = actitudes.Pregunta4;
            Pregunta5 = actitudes.Pregunta5;
            Pregunta6 = actitudes.Pregunta6;
            Idpersona = actitudes.Idpersona;
            Codigo = actitudes.Idpersona;
        }
    }
}