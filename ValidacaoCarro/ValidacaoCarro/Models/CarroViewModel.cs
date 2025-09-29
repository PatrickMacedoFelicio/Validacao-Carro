using System.ComponentModel.DataAnnotations;
using ValidacaoCarro.Attributes;

namespace ValidacaoCarro.Models;

public class CarroViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Placa é obrigatória")]
    [RegularExpression(@"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$", ErrorMessage = "Placa no formato Mercosul inválida (ex: ABC1D23)")]
    [Placa(ErrorMessage = "Placa já cadastrada")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "Renavam é obrigatório")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Renavam deve ter 11 dígitos numéricos")]
    [Renavam(ErrorMessage = "Renavam inválido")]
    public string Renavam { get; set; }

    [Required(ErrorMessage = "Chassi é obrigatório")]
    [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$", ErrorMessage = "Chassi inválido (17 caracteres, sem I, O ou Q)")]
    public string Chassi { get; set; }

    [Required(ErrorMessage = "Ano de Fabricação é obrigatório")]
    [Range(1980, 2100, ErrorMessage = "Ano de Fabricação inválido")]
    public int AnoFabricacao { get; set; }

    [Required(ErrorMessage = "Ano do Modelo é obrigatório")]
    [AnoModeloValido(nameof(AnoFabricacao), ErrorMessage = "Ano do Modelo deve ser >= Ano de Fabricação e <= Ano atual + 1")]
    public int AnoModelo { get; set; }

    [Required(ErrorMessage = "Tipo de Combustível é obrigatório")]
    [RegularExpression(@"^(Gasolina|Diesel|Etanol|Flex|Elétrico|GNV)$", ErrorMessage = "Tipo de combustível inválido")]
    public string TipoCombustivel { get; set; }

    [Required(ErrorMessage = "O Valor do Seguro é obrigatório")]
    [Range(500, double.MaxValue, ErrorMessage = "O valor do seguro deve ser maior ou igual a 500")]
    public float? ValorSeguro { get; set; }

    [Required(ErrorMessage = "Nome do Proprietário é obrigatório")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Nome deve ter entre 6 e 100 caracteres")]
    [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "Nome deve conter apenas letras e espaços")]
    public string NomeProprietario { get; set; }
}
