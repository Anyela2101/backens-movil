import { Component, OnInit } from '@angular/core';
import { RestaurantesService } from 'src/app/services/restaurantes.service';
import { Restaurantes } from '../models/restaurantes';

import {Persona} from '../models/persona';
import {PersonaService} from '../../services/persona.service';

import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent{
  restaurantes:Restaurantes[];
  personas:Persona[];
  searchText: string;
  encontro:string;
  name = 'Angular';
  page = 1;
  pageSize =5;
  constructor(private restauranteService: RestaurantesService,private modalService: NgbModal,
              private personaService:PersonaService) { }

  ngOnInit(): void {
    this.consultaRestaurante();
    this.consultaPersona();
    //this.downloadPF();
  }
  Buscar(){
    this.restauranteService.buscar(this.searchText).subscribe(
      r => {
        
        if (r != null) {
          //this.encontro='s';
        /*   const messageBox = this.modalService.open(AlertModalComponent) */
          /* messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Persona existe!!! :-)'; */
          //this.restaurante=r;
        }else{
          //this.encontro='n';
       /*    const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Persona no existe!!! :-)'; */
        }
        /* if(this.encontro='s'){
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Persona existe!!! :-)';
        }else{
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Persona no existe!!! :-)';
        } */
    });

    //this.downloadPF();
  }
  consultaRestaurante(){
    console.log('tabla');
    this.restauranteService.get().subscribe(result=>{
      this.restaurantes =result;
    });
    console.log('tabla2');
  }
  consultaPersona(){
    this.personaService.get().subscribe(result=>{
      this.personas=result;
    })
  }
  downloadPF(){
    console.log('11111');
    // Extraemos el
    const DATA = document.getElementById('htmlData');
    const doc = new jsPDF('p', 'pt', 'a4');
    const options = {
      background: 'red',
      scale: 3
    };
    console.log('2');
    html2canvas(DATA, options).then((canvas) => {

      const img = canvas.toDataURL('image/PNG');

      // Add image Canvas to PDF
      const bufferX = 15;
      const bufferY = 15;
      const imgProps = (doc as any).getImageProperties(img);
      const pdfWidth = doc.internal.pageSize.getWidth() - 2 * bufferX;
      const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
      doc.addImage(img, 'PNG', bufferX, bufferY, pdfWidth, pdfHeight, undefined, 'FAST');
      return doc;
    }).then((docResult) => {
      //docResult.save(`${new Date().toISOString()}_tutorial.pdf`);
      docResult.save('prueba.pdf');
    });
    console.log('hola');
  }
}
