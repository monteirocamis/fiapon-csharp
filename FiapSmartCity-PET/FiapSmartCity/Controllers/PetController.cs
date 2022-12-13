using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class PetController : Controller
    {
        private readonly PetRepository petRepository;

        public PetController()
        {
            petRepository = new PetRepository();

        }

       // [Filtros.LogFilter]
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
        [HttpPost]



        public ActionResult Cadastrar(Models.Pet pet)
        {

            if (ModelState.IsValid)
            {
                petRepository.Inserir(pet);

                @TempData["mensagem"] = "pet cadastrado com sucesso";
                return RedirectToAction("Index", "Pet");
            }
            else
            {
                return View(pet);
            }
        }


        [HttpGet]

        public ActionResult Editar(int Id)
        {
            var pet = petRepository.Consultar(Id);
            return View(pet);
        }

        [HttpPost]


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
        public ActionResult Consultar(int Id)
        {
            var pet = petRepository.Consultar(Id);
            return View(pet);
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
