import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService} from '../../services/persona.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Actitudes } from '../models/actitudes';
import { ActitudesService} from '../../services/actitudes.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-actitudes',
  templateUrl: './actitudes.component.html',
  styleUrls: ['./actitudes.component.css']
})
export class ActitudesComponent implements OnInit {
  identificacion: string;
  formGroup: FormGroup;
  persona: Persona;
  searchText: string;
  actitudes:Actitudes;

   constructor(private personaService: PersonaService,private actitudesService:ActitudesService,
     private formBuilder: FormBuilder, private modalService: NgbModal,private router: Router) { }


  ngOnInit(): void {
    this.persona = new Persona();
    this.actitudes = new Actitudes();
    this.buildForm();
  }
  private buildForm(){
    this.actitudes.pregunta1 ='';
    this.actitudes.pregunta2 ='';
    this.actitudes.pregunta3 ='';
    this.actitudes.pregunta4 ='';
    this.actitudes.pregunta5 ='';
    this.actitudes.pregunta6 ='';
    this.persona.identificacion= '';
    this.actitudes.total=0;
    
    this.formGroup = this.formBuilder.group({
      pregunta1: [this.actitudes.pregunta1, Validators.required],
      pregunta2: [this.actitudes.pregunta2, Validators.required],
      pregunta3: [this.actitudes.pregunta3, Validators.required],
      pregunta4: [this.actitudes.pregunta4, Validators.required],
      pregunta5: [this.actitudes.pregunta5, Validators.required],
      pregunta6: [this.actitudes.pregunta6, Validators.required],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add(){
    this.actitudes = this.formGroup.value;
    this.actitudes.idpersona = this.persona.identificacion
    if(this.persona != null){
    
      this.actitudesService.post(this.actitudes).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title="Resultado Operacion";
          messageBox.componentInstance.message ='Persona Creada!'
          this.actitudes = p;
          this.router.navigate(['/practicas']);
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
