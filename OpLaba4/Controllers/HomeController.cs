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
        if (string.IsNullOrEmpty(model.SelectedOperator) || !model.Operators.Contains(model.SelectedOperator))
        {
            ModelState.AddModelError("SelectedOperator", $"SelectedOperator should be in {string.Join(", ", model.Operators)}");
        }

        if (ModelState.IsValid)
        {
            switch (model.SelectedOperator)
            {
                case "+":
                    model.Result = model.LeftOperand + model.RightOperand;
                    break;
                case "-":
                    model.Result = (double)model.LeftOperand - model.RightOperand;
                    break;
                case "/":
                    model.Result = model.LeftOperand / (double)model.RightOperand;
                    break;
                case "*":
                    model.Result = model.LeftOperand * model.RightOperand;
                    break;
                default:
                    ModelState.AddModelError("Operator", "Invalid operator");
                    break;
            }
        }

        return View(model);
    }
}