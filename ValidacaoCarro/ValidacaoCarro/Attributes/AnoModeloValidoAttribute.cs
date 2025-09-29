using System.ComponentModel.DataAnnotations;

namespace ValidacaoCarro.Attributes;

public class AnoModeloValidoAttribute : ValidationAttribute
{
    private readonly string _anoFabricacaoProperty;

    public AnoModeloValidoAttribute(string anoFabricacaoProperty)
    {
        _anoFabricacaoProperty = anoFabricacaoProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        var anoModelo = (int)value;
        var anoFabricacaoProp = validationContext.ObjectType.GetProperty(_anoFabricacaoProperty);
        var anoFabricacao = (int)(anoFabricacaoProp?.GetValue(validationContext.ObjectInstance) ?? 0);

        int anoAtual = DateTime.Now.Year;
        if (anoModelo < anoFabricacao || anoModelo > anoAtual + 1)
            return new ValidationResult(ErrorMessage ?? "Ano do Modelo inválido");

        return ValidationResult.Success;
    }
}