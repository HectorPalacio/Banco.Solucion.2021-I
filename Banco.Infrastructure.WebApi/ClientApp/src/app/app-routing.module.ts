import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrearCuentaComponent } from './cuentaBancaria/crear-cuenta/crear-cuenta.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: 'crearCuenta', component: CrearCuentaComponent
  },
  {
    path: '', component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
