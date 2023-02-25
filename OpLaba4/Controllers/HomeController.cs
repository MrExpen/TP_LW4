using Microsoft.AspNetCore.Mvc;
using OpLaba4.Models;

namespace OpLaba4.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new CalculatorViewModel());
    }

    [HttpPost]
    public IActionResult Index(CalculatorViewModel model)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Result = model.Result;
            
            switch (model.Action)
            {
                case Constants.Calculate :
                    switch (model.SelectedOperator)
                    {
                        case Constants.Plus:
                            model.Result = model.LeftOperand + model.RightOperand;
                            break;
                        case Constants.Minus:
                            model.Result = (double)model.LeftOperand - model.RightOperand;
                            break;
                        case Constants.Divide:
                            model.Result = model.LeftOperand / (double)model.RightOperand;
                            break;
                        case Constants.Multiply:
                            model.Result = model.LeftOperand * model.RightOperand;
                            break;
                        default:
                            ModelState.AddModelError("SelectedOperator",
                                $"SelectedOperator should be in {string.Join(", ", model.Operators)}");
                            break;
                    }
                    break;
                case Constants.Clear:
                    return RedirectToAction(nameof(Index));
                default:
                    ModelState.AddModelError("Action", "Invalid action");
                    break;
            }
        }

        return View(model);
    }
}