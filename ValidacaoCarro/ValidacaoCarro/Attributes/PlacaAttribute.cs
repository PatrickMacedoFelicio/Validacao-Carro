using System.ComponentModel.DataAnnotations;

namespace ValidacaoCarro.Attributes;

public class PlacaAttribute : ValidationAttribute
{
    private static readonly HashSet<string> PlacasCadastradas = new();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        var placa = value.ToString()?.ToUpper();
        if (PlacasCadastradas.Contains(placa))
            return new ValidationResult(ErrorMessage ?? "Placa já cadastrada");
        
        PlacasCadastradas.Add(placa);
        return ValidationResult.Success;
    }
}