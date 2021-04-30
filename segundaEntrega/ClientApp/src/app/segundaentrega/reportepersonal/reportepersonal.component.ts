import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PersonaService } from 'src/app/services/persona.service';
import { RestaurantesService } from 'src/app/services/restaurantes.service';
import { Persona } from '../models/persona';
import { Restaurantes } from '../models/restaurantes';

@Component({
  selector: 'app-reportepersonal',
  templateUrl: './reportepersonal.component.html',
  styleUrls: ['./reportepersonal.component.css']
})
export class ReportepersonalComponent implements OnInit {
  searchText:string;
  formGroup: FormGroup;
  nit:string;
  restaurantes:Restaurantes[];
  restaurantes2:Restaurantes[];
  personas:Persona[];
  personas2:Persona[];
  constructor(private formBuilder: FormBuilder, private modalService: NgbModal,private personaService:PersonaService) { }

  ngOnInit(): void {
    this.nit = '';
    this.Traerlista();
  }

  Traerlista(){
    this.personaService.get().subscribe(result=>{
      
      this.personas =result;
    })
  }
  Buscar(){
    this.personas.forEach(element => {
      console.log('hola')
      console.log(element.Idrestaurante+'asdasd'+this.searchText+element.nombres);
      if(element.Idrestaurante == this.searchText){
        console.log('hola1')
        this.personas.push(element);
        console.log('hola2')
      }
      console.log('jola')
    });
    
  }
  downloadPF(){
    
  }

}
