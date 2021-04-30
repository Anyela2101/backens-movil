import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService} from '../../services/persona.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Conocimiento } from '../models/conocimiento';
import { ConocimientoService} from '../../services/conocimiento.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-conocimientos',
  templateUrl: './conocimientos.component.html',
  styleUrls: ['./conocimientos.component.css']
})
export class ConocimientosComponent implements OnInit {
  identificacion: string;
  formGroup: FormGroup;
  persona: Persona;
  searchText: string;
  conocimientos:Conocimiento;

   constructor(private personaService: PersonaService,private conocimientoService:ConocimientoService,
     private formBuilder: FormBuilder, private modalService: NgbModal,private router: Router) { }


  ngOnInit(): void {
    this.persona = new Persona();
    this.conocimientos = new Conocimiento();
    this.buildForm();
  }
  private buildForm(){
    this.conocimientos.pregunta1 ='';
    this.conocimientos.pregunta2 ='';
    this.conocimientos.pregunta3 ='';
    this.conocimientos.pregunta4 ='';
    this.conocimientos.pregunta5 ='';
    this.conocimientos.pregunta6 ='';
    this.persona.identificacion= '';
    this.conocimientos.total=0;
    
    this.formGroup = this.formBuilder.group({
      pregunta1: [this.conocimientos.pregunta1, Validators.required],
      pregunta2: [this.conocimientos.pregunta2, Validators.required],
      pregunta3: [this.conocimientos.pregunta3, Validators.required],
      pregunta4: [this.conocimientos.pregunta4, Validators.required],
      pregunta5: [this.conocimientos.pregunta5, Validators.required],
      pregunta6: [this.conocimientos.pregunta6, Validators.required],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add(){
    this.conocimientos = this.formGroup.value;
    this.conocimientos.idpersona = this.persona.identificacion;
    console.log(this.persona.nombres);
    if(this.persona != null){
    
      this.conocimientoService.post(this.conocimientos).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title="Resultado Operacioon";
          messageBox.componentInstance.message ='Persona Creada!';
          this.router.navigate(['/actitudes']);
          this.conocimientos = p;
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
