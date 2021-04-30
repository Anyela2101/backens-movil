import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService} from '../../services/persona.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Practicas } from '../models/practicas';
import { PracticasService} from '../../services/practicas.service';

@Component({
  selector: 'app-practicas',
  templateUrl: './practicas.component.html',
  styleUrls: ['./practicas.component.css']
})
export class PracticasComponent implements OnInit {
  identificacion: string;
  formGroup: FormGroup;
  persona: Persona;
  searchText: string;
  practicas:Practicas;

   constructor(private personaService: PersonaService,private practicasService:PracticasService,
     private formBuilder: FormBuilder, private modalService: NgbModal) { }


  ngOnInit(): void {
    this.persona = new Persona();
    this.practicas = new Practicas();
    this.buildForm();
  }
  private buildForm(){
    this.practicas.pregunta1 ='';
    this.practicas.pregunta2 ='';
    this.practicas.pregunta3 ='';
    this.practicas.pregunta4 ='';
    this.persona.identificacion= '';
    this.practicas.total=0;
    
    this.formGroup = this.formBuilder.group({
      pregunta1: [this.practicas.pregunta1, Validators.required],
      pregunta2: [this.practicas.pregunta2, Validators.required],
      pregunta3: [this.practicas.pregunta3, Validators.required],
      pregunta4: [this.practicas.pregunta4, Validators.required]
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add(){
    this.practicas = this.formGroup.value;
    this.practicas.idpersona = this.persona.identificacion
    console.log(this.practicas);
    if(this.persona != null){
    
      this.practicasService.post(this.practicas).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title="Resultado Operacion";
          messageBox.componentInstance.message ='Practica Creada!'
          this.practicas = p;
        }
      });
    }
    
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

  get control() { 
    return this.formGroup.controls;
  }
}
