import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { PersonaService } from 'src/app/services/persona.service';
import { Examenes } from '../models/Examen';
import { Persona } from '../models/persona';


@Component({
  selector: 'app-examenes',
  templateUrl: './examenes.component.html',
  styleUrls: ['./examenes.component.css']
})
export class ExamenesComponent implements OnInit {
  identificacion:string;
  formGroup: FormGroup;
  persona: Persona;
  path= '';
  examen : Examenes;
  
  constructor(private personaService:PersonaService,private modalService: NgbModal, private http: HttpClient, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.persona = new Persona();
    this.persona.nombres='';
    this.persona.apellidos='';
    this.persona.edad=0;
    this.buildForm();
  }
  private buildForm(){
    this.formGroup = this.formBuilder.group({
      'nombre':['', Validators.required]
    });
  }

  Buscar(){
    this.personaService.buscar(this.identificacion).subscribe(
      r => {
        if (r != null) {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Persona existe!!! :-)';
          this.persona=r;
        }else{
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Persona no existe!!! :-)';
        }
   
    });
  }

  add(){
    this.examen = this.formGroup.value;
    this.examen.path = this.path;
    this.persona.examenes.push(this.examen);
    console.log(this.persona);
  }

  subirArchivo(files: FileList){
    const archivo = files.item(0);
    const formdata = new FormData();
    formdata.append('file',archivo, archivo.name);
    formdata.append('upload_preset', 'wbknyi3k' );
    formdata.append('signature', 'bfd09f95f331f558cbd1320e67aa8d488770583e');
    this.http.post('https://api.cloudinary.com/v1_1/dbj9awcvs/upload', formdata).subscribe((respuesta: any)=>{
      this.path=respuesta.secure_url;
    });
  }
}
