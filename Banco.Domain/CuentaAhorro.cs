using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Domain
{
    public class CuentaAhorro : CuentaBancaria
    {

        public const decimal TOPERETIRO = 10000;

        public CuentaAhorro(string numero, string nombre, string ciudad, string email) : base(numero, nombre, ciudad, email)
        {
        }

        public override string Retirar(decimal valor, string ciudad, DateTime fechaMovimiento)
        {
            List<string> errores = new List<string>();
            errores = PuedeRetirar(valor);
            if (errores.Any()) 
            {
                // throw new CuentaAhorroTopeDeRetiroException("No es posible realizar el Retiro");
                return errores[0];
            }else{
                Saldo -= valor;
                var retiro = new MovimientoFinanciero(this, valor,0, fechaMovimiento);
                this.Movimientos.Add(retiro);
                return "Se realizó  el retiro satisfactoriamenteXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            }
        }

        public override List<string> PuedeRetirar(decimal valor) 
        {
            List<string> errors = new List<string>();
            if(valor > Saldo){
                errors.Add("No es posible realizar el retiro, el valor supera al saldo en la cuenta");
            }else if(valor > TOPERETIRO){
                errors.Add("No es posible realizar el retiro, supera el tope mínimo permitido de retiro");
            }
            //decimal nuevoSaldo = Saldo - valor;
            // if (nuevoSaldo <= TOPERETIRO) 
            // {
            // }
            return errors;
        }
        
    }


    [Serializable]
    public class CuentaAhorroTopeDeRetiroException : Exception
    {
        public CuentaAhorroTopeDeRetiroException() { }
        public CuentaAhorroTopeDeRetiroException(string message) : base(message) { }
        public CuentaAhorroTopeDeRetiroException(string message, Exception inner) : base(message, inner) { }
        protected CuentaAhorroTopeDeRetiroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
