using System.Collections.Concurrent;
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
        ViewBag.Result = model.Result;
        if (!model.Operators.Contains(model.SelectedOperator ?? string.Empty))
        {
            ModelState.AddModelError("SelectedOperator",
                $"SelectedOperator should be in {string.Join(", ", model.Operators)}");
        }

        switch (model.Action)
        {
            case Constants.Calculate:
                if (ModelState.IsValid)
                {
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
                    }
                }

                break;
            case Constants.Clear:
                return RedirectToAction(nameof(Index));
            default:
                ModelState.AddModelError("Action", "Invalid action");
                break;
        }

        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString(Constants.LeftOperand, model.LeftOperand.ToString());
            HttpContext.Session.SetString(Constants.RightOperand, model.RightOperand.ToString());
            HttpContext.Session.SetString(Constants.SelectedOperator, model.SelectedOperator!);
            HttpContext.Session.SetString(Constants.Result, model.Result.ToString()!);
        }
        
        return View(model);
    }

    public IActionResult Result()
    {
        return View(new ResultViewModel
        {
            LeftOperand = HttpContext.Session.GetString(Constants.LeftOperand),
            RightOperand = HttpContext.Session.GetString(Constants.RightOperand),
            Result = HttpContext.Session.GetString(Constants.Result),
            SelectedOperator = HttpContext.Session.GetString(Constants.SelectedOperator)
        });
    }
}