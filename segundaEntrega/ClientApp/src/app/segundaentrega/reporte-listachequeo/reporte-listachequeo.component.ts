import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ListaChequeoService } from 'src/app/services/lista-chequeo.service';
import { RestaurantesService } from 'src/app/services/restaurantes.service';
import { ListaChequeo } from '../models/lista-chequeo';
import { Restaurantes } from '../models/restaurantes';

@Component({
  selector: 'app-reporte-listachequeo',
  templateUrl: './reporte-listachequeo.component.html',
  styleUrls: ['./reporte-listachequeo.component.css']
})
export class ReporteListachequeoComponent implements OnInit {
  nit:string;
  formGroup: FormGroup;
  restaurante: Restaurantes;
  listachequeo:ListaChequeo;
  a:string;

  constructor(private restaurantesServices: RestaurantesService, private modalService: NgbModal,private listachequeoService:ListaChequeoService) { }

  ngOnInit(): void {
    this.restaurante = new Restaurantes();
    this.listachequeo = new ListaChequeo();
    this.restaurante.nombre='';
    this.listachequeo.total = 0;
  }
  Buscar(){
    this.listachequeoService.buscar(this.nit).subscribe(
      r => {
        if (r != null) {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'restaurantes existe!!! :-)';
          this.listachequeo=r;
        }else{
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'restaurantes no existe!!! :-)';
        }
   
    });
    this.restaurantesServices.buscar(this.nit).subscribe(
      r => {
        if (r != null) {
          const messageBox = this.modalService.open(AlertModalComponent)
          this.restaurante=r;
        }else{
          const messageBox = this.modalService.open(AlertModalComponent)
        
        }
   
    });
  }
  downloadPF(){
    // Extraemos el
    const DATA = document.getElementById('htmlData');
    const doc = new jsPDF('p', 'pt', 'a4');
    const options = {
      background: 'red',
      scale: 3
    };
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
      docResult.save('reportelistachequeo.pdf');
    });
  }
}
