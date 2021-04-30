import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Conocimiento } from '../segundaentrega/models/conocimiento';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConocimientoService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string,
    private handleErrorService: HandleHttpErrorService) 
    {this.baseUrl = baseUrl; }

    get(): Observable<Conocimiento[]>{
      return this.http.get<Conocimiento[]>(this.baseUrl + 'api/Conocimientos')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Conocimiento[]>('Consulta Conocimientos', null))
        );
    }
    post(conocimiento:Conocimiento): Observable<Conocimiento> {
      return this.http.post<Conocimiento>(this.baseUrl + 'api/Conocimientos', conocimiento)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
       catchError(this.handleErrorService.handleError<Conocimiento>('Registrar Conocimiento', null))
      );
    }

    buscar(identificacion: string): Observable<Conocimiento>{
      return this.http.get<Conocimiento>(this.baseUrl+'api/Conocimientos/'+identificacion)
      .pipe(
        tap(_ => this.handleErrorService.log('Encontrado'))
      );
    }
}
