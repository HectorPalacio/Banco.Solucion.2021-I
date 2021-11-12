using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public const decimal SOBREGIRO = -1000;
        public CuentaCorriente( string numero, string nombre, string ciudad, string email) : base( numero, nombre, ciudad, email)
        {
        }

        public override string Retirar(decimal valor, string ciudad, DateTime fechaMovimiento)
        {
            List<string> errores = new List<string>();
            errores = PuedeRetirar(valor);

            if(errores.Any()){
                return errores[0];
            }else{
                MovimientoFinanciero movimiento = new MovimientoFinanciero(this, valor, 0, fechaMovimiento);
                Saldo -= valor;
                this.Movimientos.Add(movimiento);
                return "Se realizó el retiro satisfactoriamente";
            }
        }
        public override List<string> PuedeRetirar(decimal valor)
        {
            List<string> errors = new List<string>();
            decimal nuevoSaldo = Saldo - valor;
            if(nuevoSaldo < SOBREGIRO){
                errors.Add("No es posible realizar el retiro, el valor supera al saldo en la cuenta");
            }
            return errors;
        }
    }

    [Serializable]
    public class CuentaCorrienteRetirarMaximoSobregiroException : Exception
    {
        public CuentaCorrienteRetirarMaximoSobregiroException() { }
        public CuentaCorrienteRetirarMaximoSobregiroException(string message) : base(message) { }
        public CuentaCorrienteRetirarMaximoSobregiroException(string message, Exception inner) : base(message, inner) { }
        protected CuentaCorrienteRetirarMaximoSobregiroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
