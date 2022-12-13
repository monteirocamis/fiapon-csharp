using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Properties.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCityMVC.Controllers
{
    public class PetController : Controller
    {
        private readonly PetRepository tipoProdutoRepository;

        public PetController()
        {
            tipoProdutoRepository = new petRepository();

        }

        [Filtros.LogFilter]
        [HttpGet]

        public IActionResult Index()
        {
            var listaPet = petRepository.Listar();
            return View(listaPet);
        }

        // anotacao de uso verb http get
        [HttpGet]

        public ActionResult Cadastrar()
        {
            return View(new Pet());
        }

        // anotacao de uso verb http get
        [HttpGet]








        public ActionResult Cadastrar(Models.Pet pet)
        {

            if (ModelState.IsValid)
            {
                PetRepository.Inserir(pet);

                @TempData["mensagem"] = "pet cadastrado com sucesso";
                return RedirectToAction("Index", "Pet");
            }
            else
            {
                return View(pet);
            }
        }




         







        public ActionResult Editar(int Id)
        {
            var pet = petRepository.Consultar(Id);
            return View(pet);
        }

        [HttpGet]










        public ActionResult Editar(Models.Pet pet)
        {

            if (ModelState.IsValid)
            {
                petRepository.Alterar(pet);

                @TempData["mensagem"] = "pet alterado com sucesso";
                return RedirectToAction("Index", "Pet");
            }
            else
            {
                return View(pet);
            }

        }

        [HttpGet]











        public ActionResult Excluir(int Id)
        {
            petRepository.Excluir(Id);

            @TempData["mensagem"] = "pet EXCLUIDO com sucesso";
            return RedirectToAction("Index", "Pet");

        }
    }
}
