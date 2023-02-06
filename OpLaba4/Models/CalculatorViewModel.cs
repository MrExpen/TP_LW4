using System.ComponentModel.DataAnnotations;

namespace OpLaba4.Models;

public class CalculatorViewModel
{
    public ulong LeftOperand { get; set; }
    public ulong RightOperand { get; set; }
    
    public string SelectedOperator { get; set; }
    public IEnumerable<string> Operators => new[] { "+", "-", "/", "*" };
    public double Result { get; set; }
    
    
}