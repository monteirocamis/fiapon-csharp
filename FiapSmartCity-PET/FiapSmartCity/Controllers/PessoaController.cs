using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepository pessoaRepository;

        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
        }
        
        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var pessoa = pessoaRepository.Listar();
            return View(pessoa);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new Pessoa());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.Inserir(pessoa);

                @TempData["mensagem"] = "Pessoa cadastrada com sucesso!";
                return RedirectToAction("Index", "Pessoa");

            }
            else
            {
                return View(pessoa);
            }
        }
        
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoa = pessoaRepository.Consultar(Id);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Models.Pessoa pessoa)
        {

            if (ModelState.IsValid)
            {
                pessoaRepository.Alterar(pessoa);

                @TempData["mensagem"] = "Pessoa alterada com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoa);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var pessoa = pessoaRepository.Consultar(Id);
            return View(pessoa);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            pessoaRepository.Excluir(Id);

            @TempData["mensagem"] = "Pessoa removida com sucesso!";

            return RedirectToAction("Index", "Pessoa");
        }
    }
}
