import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cuenta } from '../models/cuenta';

@Injectable({
  providedIn: 'root'
})
export class CrearCuentaService {

  baseUrl: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, ) {
    this.baseUrl = baseUrl;
  }



  post(Cuenta: Cuenta): Observable<string>{
    return this.http.post('https://localhost:5001/api/CuentaBancaria', Cuenta, {responseType: 'text'});
  }
}
