import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RestaurantesComponent } from './segundaentrega/restaurantes/restaurantes.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { ActitudesComponent } from './segundaentrega/actitudes/actitudes.component';
import { ConocimientosComponent } from './segundaentrega/conocimientos/conocimientos.component';
import { ExamenesComponent } from './segundaentrega/examenes/examenes.component';
import { InicioSesionComponent } from './inicio-sesion/inicio-sesion.component';
import { PracticasComponent } from './segundaentrega/practicas/practicas.component';
import { PersonalComponent } from './segundaentrega/personal/personal.component';
import { PersonaService } from './services/persona.service';
import { RestaurantesService } from './services/restaurantes.service';
import { PersonaConsultaComponent } from './segundaentrega/persona-consulta/persona-consulta.component';
import { FiltroPersonaPipe } from './pipe/filtro-persona.pipe';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { ReportesComponent } from './segundaentrega/reportes/reportes.component';
import { FiltroRestaurantePipe } from './pipe/filtro-restaurante.pipe';
import {JwtInterceptor} from './services/jwt.interceptor';
import { LoginComponent } from './login/login.component';
import { ListaChequeoComponent } from './segundaentrega/lista-chequeo/lista-chequeo.component';
import { RestauranteConsultaComponent } from './segundaentrega/restaurante-consulta/restaurante-consulta.component';
import { ReportepersonalComponent } from './segundaentrega/reportepersonal/reportepersonal.component';
import { ReporteencuestaComponent } from './segundaentrega/reporteencuesta/reporteencuesta.component';
import { ReporteListachequeoComponent } from './segundaentrega/reporte-listachequeo/reporte-listachequeo.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RestaurantesComponent,
    FooterComponent,
    HeaderComponent,
    ActitudesComponent,
    ConocimientosComponent,
    ExamenesComponent,
    InicioSesionComponent,
    PracticasComponent,
    PersonalComponent,
    PersonaConsultaComponent,
    FiltroPersonaPipe,
    AlertModalComponent,
    ReportesComponent,
    FiltroRestaurantePipe,
    LoginComponent,
    ListaChequeoComponent,
    RestauranteConsultaComponent,
    ReportepersonalComponent,
    ReporteencuestaComponent,
    ReporteListachequeoComponent,
    
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
    ]),
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: 
  [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
