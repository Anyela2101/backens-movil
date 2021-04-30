import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../segundaentrega/models/persona';
import { PersonaService } from '../services/persona.service';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(personas: Persona[], searchText: string): any  {

    if (searchText == null) return personas;

    return personas.filter(p =>p.nombres.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 || p.identificacion.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
  }

}
