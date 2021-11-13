import { Component, OnInit } from '@angular/core';
import { CrearCuentaService } from '../services/crear-cuenta.service';
import { Cuenta } from '../models/cuenta';

@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']
})
export class CrearCuentaComponent implements OnInit {

  cuenta: Cuenta | undefined;

  nombre: string = "";
  tipoCuenta: string = "";
  numero: string = "";
  ciudad: string = "";
  email: string = "";

  constructor(private crearCuentaService: CrearCuentaService, ) { }

  ngOnInit(): void {
  }

  addCuenta(){
    this.cuenta = new Cuenta();
    
    this.cuenta.nombre = this.nombre;
    this.cuenta.tipoCuenta = this.tipoCuenta;
    this.cuenta.numero = this.numero;
    this.cuenta.ciudad = this.ciudad;
    this.cuenta.email = this.email;

    this.crearCuentaService.post(this.cuenta).subscribe(console.log);
  }

}
