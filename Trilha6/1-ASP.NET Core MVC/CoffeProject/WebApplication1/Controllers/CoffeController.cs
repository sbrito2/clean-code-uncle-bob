
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Implementations;
using WebApplication1.Models;
using WebApplication1.Models.CoffeViewModels;

namespace WebApplication1.Controllers
{
    public class CoffeController : Controller
    {
        public CoffeController()
        {
        }

        public async Task<IActionResult> Create(Coffe coffe)
        {
            // if(coffe != null)
            // {
                var coffeService = new CoffeImp();
                await coffeService.Create(coffe);
            //     return RedirectToAction(nameof(Index));
            // }

            return View(coffe);
        }

        public async Task<IActionResult>  Index()
        {
            var coffeService = new CoffeImp();
            var coffes = await coffeService.ReadAll();

            var models = coffes.Select(x => new CoffeViewModel(){CofId = x.CofId, CofCountry = x.CofCountry}).ToList();

            return View(models);
        }

         public async Task<IActionResult> ReadOne(int id)
        {
            var coffeService = new CoffeImp();
            var coffe = await coffeService.Read(id);

            if(coffe == null)
            {
                return NotFound();
            }
            
            return View(coffe);
        }

        public async Task<IActionResult> Update(int id, Coffe coffe)
        {
            if(coffe == null)
            {
                return NotFound();
            }

            coffe.CofId = id;
            var coffeService = new CoffeImp();
            coffe = await coffeService.Update(coffe);

            if(coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var coffeService = new CoffeImp();
            var response = await coffeService.Delete(id);

            if(!response)
            {
                return NotFound();
            }

            return View(response);
        }
    }
}
