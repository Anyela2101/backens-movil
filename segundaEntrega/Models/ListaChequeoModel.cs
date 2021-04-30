using System;
using Entidad;
using System.ComponentModel.DataAnnotations;

namespace segundaEntrega.Models
{
    public class ListaChequeoInputModel{
        public string Codigo{get;set;}
        public string Pregunta1 {get;set;}
        public string Pregunta2 {get;set;}
        public string Pregunta3 {get;set;}
        public string Pregunta4 {get;set;}
        public string Pregunta5 {get;set;}
        public string Pregunta6 {get;set;}
        public string Pregunta7 {get;set;}
        public string Pregunta8 {get;set;}
        public string Pregunta9 {get;set;}
        public string nit {get;set;}
    }

    public class ListaChequeoViewModel : ListaChequeoInputModel{
        public ListaChequeoViewModel()
        {

        }
        public ListaChequeoViewModel(ListaChequeo listaChequeo)
        {
            Pregunta1 = listaChequeo.Pregunta1;
            Pregunta2 = listaChequeo.Pregunta2;
            Pregunta3 = listaChequeo.Pregunta3;
            Pregunta4 = listaChequeo.Pregunta4;
            Pregunta5 = listaChequeo.Pregunta5;
            Pregunta6 = listaChequeo.Pregunta6;
            Pregunta7 = listaChequeo.Pregunta7;
            Pregunta8 = listaChequeo.Pregunta8;
            Pregunta9 = listaChequeo.Pregunta9;
            nit = listaChequeo.nit; 
            Codigo = listaChequeo.nit;
        }
    }
}