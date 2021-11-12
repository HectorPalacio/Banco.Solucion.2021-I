import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrearCuentaComponent } from './cuentaBancaria/crear-cuenta/crear-cuenta.component';

const routes: Routes = [
  {
    path: 'crearCuenta', component: CrearCuentaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
