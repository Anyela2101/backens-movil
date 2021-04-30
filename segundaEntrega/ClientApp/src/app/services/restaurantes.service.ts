import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Restaurantes } from '../segundaentrega/models/restaurantes';

@Injectable({
  providedIn: 'root'
})
export class RestaurantesService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
    {
    this.baseUrl = baseUrl;
    }
    get(): Observable<Restaurantes[]> {
    return this.http.get<Restaurantes[]>(this.baseUrl + 'api/Restaurante')
    .pipe(
    tap(_ => this.handleErrorService.log('datos enviados')),
    catchError(this.handleErrorService.handleError<Restaurantes[]>('Consulta Restaurantes', null))
    );
    }
    post(restaurante: Restaurantes): Observable<Restaurantes> {

      return this.http.post<Restaurantes>(this.baseUrl + 'api​/Restaurante', restaurante)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Restaurantes>('Registrar Restaurantes', null))
      );
    }

    Todos(): Observable<Restaurantes[]>{
      return this.http.get<Restaurantes[]>(this.baseUrl+ 'api/Restaurante')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Restaurantes[]>('Consulta Restaurantes', null))
      );
    }
    buscar(idrestaurante: string): Observable<Restaurantes>
    {
      return this.http.get<Restaurantes>(this.baseUrl+'api/Restaurante/'+idrestaurante)
      .pipe(
        tap(_ => this.handleErrorService.log('Encontrado')),
        catchError(this.handleErrorService.handleError<Restaurantes>('Buscar restaurante', null))
      );
    }
    registrar(idrestaurante: Restaurantes): Observable<Restaurantes> {
      return this.http.post<Restaurantes>(this.baseUrl + 'api/Restaurante', idrestaurante)
        .pipe(
          tap(_ => this.handleErrorService.log('datos enviados')),
          catchError(this.handleErrorService.handleError<Restaurantes>('Registrar Restaurantes', null))
        );
    }
    
}
