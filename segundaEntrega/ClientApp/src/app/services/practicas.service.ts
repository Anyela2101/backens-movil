import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Practicas} from '../segundaentrega/models/practicas';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PracticasService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string,
    private handleErrorService: HandleHttpErrorService) 
    {this.baseUrl = baseUrl; }

    get(): Observable<Practicas[]>{
      return this.http.get<Practicas[]>(this.baseUrl + 'api/Practicas')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Practicas[]>('Consulta Practicas', null))
        );
    }
    post(Practicas:Practicas): Observable<Practicas> {
      return this.http.post<Practicas>(this.baseUrl + 'api/Practicas', Practicas)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
       catchError(this.handleErrorService.handleError<Practicas>('Registrar Practicas', null))
      );
    }
    buscar(identificacion: string): Observable<Practicas>{
      return this.http.get<Practicas>(this.baseUrl+'api/Practicas/'+identificacion)
      .pipe(
        tap(_ => this.handleErrorService.log('Encontrado'))
      );
    }
}
