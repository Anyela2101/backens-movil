import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { ListaChequeo } from '../segundaentrega/models/lista-chequeo';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ListaChequeoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string,
    private handleErrorService: HandleHttpErrorService) 
    {this.baseUrl = baseUrl; }

  get(): Observable<ListaChequeo[]>{
    return this.http.get<ListaChequeo[]>(this.baseUrl + 'api/ListaChequeo')
    .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<ListaChequeo[]>('Consulta ListaChequeo', null))
      );
  }
  post(listaChequeo:ListaChequeo): Observable<ListaChequeo> {
    return this.http.post<ListaChequeo>(this.baseUrl + 'api/ListaChequeo', listaChequeo)
    .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<ListaChequeo>('Registrar ListaChequeo', null))
    );
  }
  buscar(codigo: string): Observable<ListaChequeo>{
    return this.http.get<ListaChequeo>(this.baseUrl+'api/ListaChequeo/'+codigo)
    .pipe(
      tap(_ => this.handleErrorService.log('Encontrado')),
      catchError(this.handleErrorService.handleError<ListaChequeo>('Buscar ListaChequeo', null))
    );
  }
}
