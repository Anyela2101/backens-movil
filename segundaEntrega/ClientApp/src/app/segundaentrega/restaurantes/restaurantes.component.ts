import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { Restaurantes} from '../models/restaurantes';
import {RestaurantesService} from '../../services/restaurantes.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-restaurantes',
  templateUrl: './restaurantes.component.html',
  styleUrls: ['./restaurantes.component.css']
})
export class RestaurantesComponent implements OnInit {
  formGroup: FormGroup;
  restaurantes: Restaurantes;

  constructor(private restauranteService:RestaurantesService, private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.restaurantes=new Restaurantes();
    this.buildForm();
  }

  private buildForm(){
    this.restaurantes.nit = '';
    this.restaurantes.nombre = '';
    this.restaurantes.propietario = '';
    this.restaurantes.direccion = '';
    this.restaurantes.cantidadPersonal = 0;
    this.restaurantes.telefono = '';
    this.restaurantes.email = '';
    this.restaurantes.sedes = 0;
    this.restaurantes.aFuncionamiento = 0;
    this.restaurantes.especialidad = '';
    this.formGroup = this.formBuilder.group({
      nit: [this.restaurantes.nit, Validators.required],
      nombre: [this.restaurantes.nombre, Validators.required],
      propietario: [this.restaurantes.propietario, Validators.required],
      direccion: [this.restaurantes.direccion, Validators.required],
      cantidadPersonal: [this.restaurantes.cantidadPersonal, [Validators.required, Validators.min(1)]],
      telefono: [this.restaurantes.telefono, Validators.required],
      email: [this.restaurantes.email, Validators.required],
      sedes: [this.restaurantes.sedes, [Validators.required, Validators.min(1)]],
      añoFuncionamiento: [this.restaurantes.aFuncionamiento, [Validators.required, Validators.min(1)]],
      especialidad: [this.restaurantes.especialidad, Validators.required],
    });
   
  }

  onSubmit() {

        if (this.formGroup.invalid) {
          return;
        }
        this.add();
  }

  add() {
    this.restaurantes = this.formGroup.value;
    this.restauranteService.registrar(this.restaurantes).subscribe(
      p => {
        if(p!==null)
        {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Restaurante creado!!! :-)';
          this.restaurantes = p;
        }
      }
    )
  }

  get control() { 
    return this.formGroup.controls;
  }
 
 
}
