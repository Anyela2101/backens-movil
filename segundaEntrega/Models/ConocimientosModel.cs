using System;
using Entidad;
using System.ComponentModel.DataAnnotations;

namespace segundaEntrega.Models
{
    public class ConocimientosInputModel{
        public string Codigo{get;set;}
        public string Pregunta1 {get;set;}
        public string Pregunta2 {get;set;}
        public string Pregunta3 {get;set;}
        public string Pregunta4 {get;set;}
        public string Pregunta5 {get;set;}
        public string Pregunta6 {get;set;}
        public string Idpersona {get;set;}
    }

    public class ConocimientosViewModel : ConocimientosInputModel
    {
        public ConocimientosViewModel()
        {

        }
        public ConocimientosViewModel(Conocimientos conocimientos)
        {
            Pregunta1 = conocimientos.Pregunta1;
            Pregunta2 = conocimientos.Pregunta2;
            Pregunta3 = conocimientos.Pregunta3;
            Pregunta4 = conocimientos.Pregunta4;
            Pregunta5 = conocimientos.Pregunta5;
            Pregunta6 = conocimientos.Pregunta6;
            Idpersona = conocimientos.Idpersona;
            Codigo = conocimientos.Idpersona;
        }
    }
}