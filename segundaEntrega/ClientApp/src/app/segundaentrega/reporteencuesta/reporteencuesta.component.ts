import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService} from '../../services/persona.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Practicas } from '../models/practicas';
import { PracticasService} from '../../services/practicas.service';
import { ConocimientoService } from 'src/app/services/conocimiento.service';
import { ActitudesService } from 'src/app/services/actitudes.service';
import { Actitudes } from '../models/actitudes';
import { Conocimiento } from '../models/conocimiento';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-reporteencuesta',
  templateUrl: './reporteencuesta.component.html',
  styleUrls: ['./reporteencuesta.component.css']
})
export class ReporteencuestaComponent implements OnInit {
  identificacion:string;
  formGroup: FormGroup;
  persona:Persona;
  actitudes:Actitudes;
  conocimiento:Conocimiento;
  practicas:Practicas;
  constructor(private formBuilder: FormBuilder, private modalService: NgbModal,private conocimientoService:ConocimientoService,
        private actitudesService:ActitudesService,private practicasService:PracticasService,
        private personaService:PersonaService) { }

  ngOnInit(): void {
    this.actitudes = new Actitudes();
    this.conocimiento = new Conocimiento();
    this.practicas = new Practicas();
    this.persona = new Persona();
    this.actitudes.total = 0;
    this.conocimiento.total = 0;
    this.practicas.total = 0;
    this.persona.nombres = '';
  }
  Buscar(){
    this.personaService.buscar(this.identificacion).subscribe(
      r=>{
        this.persona = r;
      }
    )
    this.conocimientoService.buscar(this.identificacion).subscribe(
      r => {
        this.conocimiento = r;
      }
    )
    this.actitudesService.buscar(this.identificacion).subscribe(
      r => {
        this.actitudes = r;
      }
    )
    this.practicasService.buscar(this.identificacion).subscribe(
      r => {
        this.practicas = r;
      }
    )
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
      docResult.save('reporteencuesta.pdf');
    });
  }
}
