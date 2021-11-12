using Banco.Domain.Contracts;
using System;
using System.Globalization;

namespace Banco.Application
{
    /// <summary>
    /// Comando 
    /// </summary>
    public class RetirarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICuentaBancariaRepository _cuentaRepository;
        private readonly IMailServer _emailServer;

        public RetirarService(
           IUnitOfWork unitOfWork,
           ICuentaBancariaRepository cuentaRepository,
           IMailServer emailServer
       )
        {
            _unitOfWork = unitOfWork;
            _cuentaRepository = cuentaRepository;
            _emailServer = emailServer;

        }

        public RetirarResponse Retirar(RetirarRequest request){

            var cuenta = _cuentaRepository.FindFirstOrDefault(cuenta=>cuenta.Numero== request.NumeroCuenta);//infraestructura-datos
            if(cuenta == null) return new RetirarResponse("La cuenta no existe");
            var response = cuenta.Retirar(request.Valor, request.Ciudad, request.FechaMovimiento);
            _cuentaRepository.Update(cuenta);
            _unitOfWork.Commit();
            var responseMail=_emailServer.Send("Se efectúo consignación", cuenta.Email);//infraestructura-system
            return new RetirarResponse(response);
        }

    }

    public record RetirarRequest(string NumeroCuenta, string Ciudad, decimal Valor, DateTime FechaMovimiento);

    public record RetirarResponse 
    {
        public RetirarResponse()
        {

        }

        public RetirarResponse(string mensaje)
        {
            Mensaje = mensaje;
        }

        public string Mensaje { get; set; }
    }
}
