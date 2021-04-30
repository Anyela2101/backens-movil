import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import {HomeComponent} from '../app/home/home.component';
import { ConocimientosComponent } from './segundaentrega/conocimientos/conocimientos.component';
import { ActitudesComponent } from './segundaentrega/actitudes/actitudes.component';
import { ExamenesComponent } from './segundaentrega/examenes/examenes.component';
import { PracticasComponent } from './segundaentrega/practicas/practicas.component';
import { PersonalComponent } from './segundaentrega/personal/personal.component';
import { PersonaConsultaComponent} from './segundaentrega/persona-consulta/persona-consulta.component'
import { RestaurantesComponent } from './segundaentrega/restaurantes/restaurantes.component';
import {RestauranteConsultaComponent } from './segundaentrega/restaurante-consulta/restaurante-consulta.component';
import { ReportesComponent } from './segundaentrega/reportes/reportes.component';
import { AuthGuard } from './services/auth.guard';
import { LoginComponent } from './login/login.component';
import { ListaChequeoComponent } from './segundaentrega/lista-chequeo/lista-chequeo.component';
import { ReporteencuestaComponent } from './segundaentrega/reporteencuesta/reporteencuesta.component';
import { ReportepersonalComponent } from './segundaentrega/reportepersonal/reportepersonal.component';
import { ReporteListachequeoComponent } from './segundaentrega/reporte-listachequeo/reporte-listachequeo.component';

const routes: Routes = [ 
  {path: '', component: HomeComponent},
  {path: 'personal', component: PersonalComponent, canActivate: [AuthGuard]},
  {path: 'personaConsulta', component: PersonaConsultaComponent,canActivate: [AuthGuard]},
  {path: 'conocimientos', component: ConocimientosComponent, canActivate: [AuthGuard]},
  {path: 'actitudes', component: ActitudesComponent, canActivate: [AuthGuard]},
  {path: 'practicas', component: PracticasComponent, canActivate: [AuthGuard]},
  {path: 'examenes', component: ExamenesComponent, canActivate: [AuthGuard]},
  {path: 'restaurantes', component:RestaurantesComponent, canActivate: [AuthGuard]},
  {path: 'restauranteconsulta', component:RestauranteConsultaComponent, canActivate: [AuthGuard]},
  {path: 'reportes', component:ReportesComponent, canActivate: [AuthGuard]},
  {path: 'listachequeo', component:ListaChequeoComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'reporteencuesta', component:ReporteencuestaComponent, canActivate: [AuthGuard]},
  {path: 'reportepersonal', component:ReportepersonalComponent, canActivate: [AuthGuard]},
  {path: 'reportelistachequeo', component:ReporteListachequeoComponent, canActivate: [AuthGuard]},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
