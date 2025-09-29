using Microsoft.AspNetCore.Mvc;
using ValidacaoCarro.Models;

namespace ValidacaoCarro.Controllers;

public class CarroController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("Cadastrar");
    }

    [HttpPost]
    public IActionResult Cadastrar(CarroViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var carro = new Carro
        {
            Id = model.Id,
            Placa = model.Placa,
            Renavam = model.Renavam,
            Chassi = model.Chassi,
            AnoFabricacao = model.AnoFabricacao,
            AnoModelo = model.AnoModelo,
            TipoCombustivel = model.TipoCombustivel,
            ValorSeguro = model.ValorSeguro,
            NomeProprietario = model.NomeProprietario,
            
        };    
        TempData["Mensagem"] = "Carro cadastrado com sucesso!";
        
        return RedirectToAction("Index"); 
    }
}