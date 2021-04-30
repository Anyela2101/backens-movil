import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Actitudes } from '../segundaentrega/models/actitudes';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ActitudesService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string,
    private handleErrorService: HandleHttpErrorService) 
    {this.baseUrl = baseUrl; }

    get(): Observable<Actitudes[]>{
      return this.http.get<Actitudes[]>(this.baseUrl + 'api/Actitudes')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Actitudes[]>('Consulta Actitudes', null))
        );
    }
    post(actitudes:Actitudes): Observable<Actitudes> {
      return this.http.post<Actitudes>(this.baseUrl + 'api/Actitudes', actitudes)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
       catchError(this.handleErrorService.handleError<Actitudes>('Registrar Conocimiento', null))
      );
    }
    buscar(identificacion: string): Observable<Actitudes>{
      return this.http.get<Actitudes>(this.baseUrl+'api/Actitudes/'+identificacion)
      .pipe(
        tap(_ => this.handleErrorService.log('Encontrado'))
      );
    }
}