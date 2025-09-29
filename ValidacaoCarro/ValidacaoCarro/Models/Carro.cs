namespace ValidacaoCarro.Models;

public class Carro
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public string Renavam { get; set; }
    public string Chassi { get; set; }
    public DateTime AnoFabricacao { get; set; }
    public DateTime AnoModelo { get; set; }
    public string TipoCombustivel { get; set; }
    public float ValorSeguro { get; set; } 
    public string NomeProprietario { get; set; }
}