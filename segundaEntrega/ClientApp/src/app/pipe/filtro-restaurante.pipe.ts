import { Pipe, PipeTransform } from '@angular/core';
import { Restaurantes } from '../segundaentrega/models/restaurantes';

@Pipe({
  name: 'filtroRestaurante'
})
export class FiltroRestaurantePipe implements PipeTransform {

  transform(restaurantes: Restaurantes[], searchText: string): any  {

    if (searchText == null) return restaurantes;

    return restaurantes.filter(p =>p.nombre.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
  }
}
