using System.ComponentModel.DataAnnotations;

namespace DTOs.Validators
{
    public class ValidadorCuit : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string cuit = value as string;

            if (string.IsNullOrEmpty(cuit)) return true; //Porque es opcional, si no se carga es valido

            bool esValido = false;
            if (cuit.Length == 13)
            {
                int verificador;
                int resultado = 0;
                string cuit_nro = cuit.Replace("-", string.Empty);
                string codes = "6789456789";
                long cuit_long = 0;
                if (long.TryParse(cuit_nro, out cuit_long))
                {
                    verificador = int.Parse(cuit_nro[cuit_nro.Length - 1].ToString());
                    int x = 0;
                    while (x < 10)
                    {

                        int digitoValidador = int.Parse(codes.Substring((x), 1));
                        int digito = int.Parse(cuit_nro.Substring((x), 1));
                        int digitoValidacion = digitoValidador * digito;
                        resultado += digitoValidacion;
                        x++;
                    }
                    resultado = resultado % 11;
                    esValido = (resultado == verificador);
                }
            }
            return esValido;
        }
    }
}
