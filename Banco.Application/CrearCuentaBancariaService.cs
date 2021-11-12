﻿using Banco.Domain;
using Banco.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Application
{
    public class CrearCuentaBancariaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICuentaBancariaRepository _cuentaRepository;
        private readonly IMailServer _emailServer;

        public CrearCuentaBancariaService(
           IUnitOfWork unitOfWork,
           ICuentaBancariaRepository cuentaRepository,
           IMailServer emailServer
       )
        {
            _unitOfWork = unitOfWork;
            _cuentaRepository = cuentaRepository;
            _emailServer = emailServer;
        }
        public string CrearCuentaBancaria(CuentaBancariaRequest request)
        {
            CuentaBancaria cuenta = _cuentaRepository.FindFirstOrDefault(t => t.Numero == request.Numero);
            if (cuenta == null)
            {
                CuentaBancaria cuentaNueva =  TipoCuenta.CrearCuenta(
                                                request.TipoCuenta,
                                                request.Numero,
                                                request.Nombre,
                                                request.Ciudad,
                                                request.Email
                                                );
                _cuentaRepository.Add(cuentaNueva);
                _unitOfWork.Commit();
                return $"Se creó con exito la cuenta número {cuentaNueva.Numero}.";
            }
            else
            {
                return  $"El número de cuenta {cuenta.Numero} ya exite";
            }
        }

    }
    public class CuentaBancariaRequest
    {
        public string Nombre { get; set; }
        public string TipoCuenta { get; set; }
        public string Numero { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }

    }
    public static class TipoCuenta
    {
        public static CuentaBancaria CrearCuenta(string tipoCuenta, string numero, string nombre, string ciudad, string email)
        {
            if (tipoCuenta.Equals("Ahorro"))
            {
                return new CuentaAhorro(numero, nombre, ciudad, email);
            }
            return new CuentaCorriente(numero, nombre, ciudad, email);
        }
    }
}
