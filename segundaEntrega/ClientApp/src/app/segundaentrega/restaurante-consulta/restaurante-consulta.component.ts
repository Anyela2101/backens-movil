import { Component, OnInit } from '@angular/core';
import { RestaurantesService } from 'src/app/services/restaurantes.service';
import { SignalRService } from 'src/app/services/signal-r.service';
import { Restaurantes } from '../models/restaurantes';

@Component({
  selector: 'app-restaurante-consulta',
  templateUrl: './restaurante-consulta.component.html',
  styleUrls: ['./restaurante-consulta.component.css']
})
export class RestauranteConsultaComponent implements OnInit {

  restaurantes:Restaurantes[];
  searchText: string;
  restaurante:Restaurantes;
  constructor(private restauranteService: RestaurantesService, private signalRService: SignalRService) { }

  ngOnInit(): void {
    this.consultaRestaurante();
    
   this.signalRService.restauranteReceived.subscribe((restaurante: Restaurantes) => {
      this.restaurantes.push(restaurante);
    }); 
  }
  consultaRestaurante(){
    this.restauranteService.get().subscribe(result=>{
      this.restaurantes =result;
    })
  }

}
