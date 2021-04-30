import { Component, OnInit } from '@angular/core';
import { Restaurantes } from '../models/restaurantes';
import {RestaurantesService} from '../../services/restaurantes.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ListaChequeo } from '../models/lista-chequeo';
import { ListaChequeoService } from '../../services/lista-chequeo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-chequeo',
  templateUrl: './lista-chequeo.component.html',
  styleUrls: ['./lista-chequeo.component.css']
})

export class ListaChequeoComponent implements OnInit {
  formGroup: FormGroup;
  searchText: string;
  nit: string;
  restaurante: Restaurantes;
  listachequeo: ListaChequeo;
  aaa:string;
  bbb:string;

  constructor(private restauranteService: RestaurantesService, private listachequeoService: ListaChequeoService,
    private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit(): void { 
    this.restaurante = new Restaurantes();
    this.listachequeo = new ListaChequeo();
    this.buildForm();
  }

  private buildForm(){
    this.listachequeo.pregunta1 ='';
    this.listachequeo.pregunta2 ='';
    this.listachequeo.pregunta3 ='';
    this.listachequeo.pregunta4 ='';
    this.listachequeo.pregunta5 ='';
    this.listachequeo.pregunta6 ='';
    this.listachequeo.pregunta7 ='';
    this.listachequeo.pregunta8 ='';
    this.listachequeo.pregunta9 ='';
    this.restaurante.nit= '';
    
    this.formGroup = this.formBuilder.group({
      pregunta1: [this.listachequeo.pregunta1, Validators.required],
      pregunta2: [this.listachequeo.pregunta2, Validators.required],
      pregunta3: [this.listachequeo.pregunta3, Validators.required],
      pregunta4: [this.listachequeo.pregunta4, Validators.required],
      pregunta5: [this.listachequeo.pregunta4, Validators.required],
      pregunta6: [this.listachequeo.pregunta4, Validators.required],
      pregunta7: [this.listachequeo.pregunta4, Validators.required],
      pregunta8: [this.listachequeo.pregunta4, Validators.required],
      pregunta9: [this.listachequeo.pregunta4, Validators.required]
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add(){
    this.listachequeo = this.formGroup.value;
    this.listachequeo.nit = this.restaurante.nit;
    if(this.restaurante != null){
    
      this.listachequeoService.post(this.listachequeo).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title="Resultado Operacion";
          messageBox.componentInstance.message ='lista de chequeo Creada!'
          this.listachequeo = p;
        }
      });
    }
    
  }
  Buscar(){
    this.restauranteService.buscar(this.nit).subscribe(
      r => {
        if (r != null) {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Restaurante existe!!! :-)';
          this.restaurante=r;
        }else{
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Restaurante no existe!!! :-)';
        }
   
    });
  }
  downloadPF(){

  }

  get control() { 
    return this.formGroup.controls;
  }

}
