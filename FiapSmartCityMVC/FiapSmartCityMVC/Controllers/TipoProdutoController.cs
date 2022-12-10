using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FiapSmartCityMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiapSmartCityMVC.Controllers
{
    public class TipoProdutoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            // Criando o atributo da lista
            IList<Models.TipoProduto> listaTipo = new List<Models.TipoProduto>();

            // Adicionando na lista o TipoProduto da Tinta
            listaTipo.Add(new TipoProduto()
            {
                IdTipo = 1,
                DescricaoTipo = "Tinta",
                Comercializado = true
            });

            listaTipo.Add(new TipoProduto()
            {
                IdTipo = 2,
                DescricaoTipo = "Filtro de água",
                Comercializado = true
            });

            listaTipo.Add(new TipoProduto()
            {
                IdTipo = 3,
                DescricaoTipo = "Captador de energia",
                Comercializado = false
            });

            // Retornando para View a lista de Tipos
            return View(listaTipo);

        }
    }
}


