import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService} from '../../services/persona.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Restaurantes } from '../models/restaurantes';
import { RestaurantesService } from 'src/app/services/restaurantes.service';
import { Usuario } from '../models/usuario';


@Component({
  selector: 'app-personal',
  templateUrl: './personal.component.html',
  styleUrls: ['./personal.component.css']
})
export class PersonalComponent implements OnInit {
  formGroup: FormGroup;
  persona: Persona;
  searchText: string;
  restaurantes: Restaurantes[];
  restaurante: Restaurantes;

  constructor(private personaService: PersonaService,private restauranteService:RestaurantesService,
     private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit() {
    this.persona = new Persona();
    //this.restaurante = new Restaurantes();
    //this.consultarRestaurantes();
    this.buildForm();
  }

  private buildForm(){
    this.persona.identificacion = '';
    this.persona.nombres = '';
    this.persona.apellidos = '';
    this.persona.edad = 0;
    this.persona.sexo = '';
    this.persona.telefono = '';
    this.persona.email = '';
    this.persona.estadoCivil = '';
    this.persona.paisProcedencia = '';
    this.persona.Idrestaurante ='';
    this.persona.nivelEducativo = '';
    this.persona.usuario.user = '';
    this.persona.usuario.password = '';
    
    
    this.formGroup = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombres: [this.persona.nombres, Validators.required],
      apellidos: [this.persona.apellidos, Validators.required],
      edad: [this.persona.edad, [Validators.required, Validators.min(1)]],
      sexo: [this.persona.sexo, [Validators.required,  this.validarSexo]],
      telefono: [this.persona.telefono, Validators.required],
      email: [this.persona.email, Validators.required],
      estadoCivil: [this.persona.estadoCivil, Validators.required],
      paisProcedencia: [this.persona.paisProcedencia, Validators.required],
      Idrestaurante: [this.persona.Idrestaurante, Validators.required],
      nivelEducativo: [this.persona.nivelEducativo, Validators.required],
      usuario: ['', Validators.required],
      contrasena: ['', Validators.required]

    });
   
  }

  private validarSexo (control: AbstractControl){
    const sexo = control.value;

    if(sexo.toLocaleUpperCase()!== 'MASCULINO' && sexo.toLocaleUpperCase()!== 'FEMENINO'){
      return {validarSexo: true, messageSexo: 'Sexo No Valido' };
    }
    return null;
  }

  onSubmit() {

        if (this.formGroup.invalid) {
          return;
        }
        this.add();
  }


  add(){
    this.persona = this.formGroup.value;
    console.log("NIT: "+this.persona.email+"  ID: "+this.persona.identificacion);
  /*   this.BuscarIdrestaurante(this.persona.idrestaurante);
      
    if(this.restaurante!=null){ */
      var usuario = new Usuario();
      usuario.user = this.formGroup.value.usuario;
      usuario.password = this.formGroup.value.contrasena;
      usuario.email = this.persona.email;
      usuario.firstName = this.persona.nombres;
      usuario.lastName = this.persona.apellidos;
      usuario.tipo = "Usuario";
      this.persona.usuario = usuario;
      this.personaService.post(this.persona).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title="Resultado Operacion";
          messageBox.componentInstance.message ='Persona Creada!'
          this.persona = p;
        }
        });
    /* }else{
      const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title="Resultado Operacion";
          messageBox.componentInstance.message ='NIT RESTAURANTE NO EXISTE!'
    } */

    
    }
    BuscarIdrestaurante(idrestaurante: string){
      this.restauranteService.buscar(idrestaurante).subscribe( r => {
        this.restaurante = r;
      }

      );
      
    }

    get control() { 
      return this.formGroup.controls;
    }

    consultarRestaurantes(){
      this.restauranteService.get().subscribe(result=>{
        this.restaurantes=result;
      });
    }
    
}
