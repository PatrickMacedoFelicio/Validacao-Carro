using System.ComponentModel.DataAnnotations;

namespace ValidacaoCarro.Attributes;

public class RenavamAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return true;

        var renavam = value.ToString().Replace(".", "").Replace("-", "").Trim();
        if (renavam.Length != 11 || !renavam.All(char.IsDigit))
            return false;

        var numeros = renavam.Substring(0, 10).Select(c => int.Parse(c.ToString())).ToArray();
        int digitoInformado = int.Parse(renavam[10].ToString());

        int soma = 0;
        int multiplicador = 2;

        for (int i = numeros.Length - 1; i >= 0; i--)
        {
            soma += numeros[i] * multiplicador;
            multiplicador++;
            if (multiplicador > 11) multiplicador = 2;
        }

        int resto = soma % 11;
        int digitoCalculado = (resto == 0 || resto == 1) ? 0 : 11 - resto;

        return digitoCalculado == digitoInformado;
    }
}
