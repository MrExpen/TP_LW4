using System.ComponentModel.DataAnnotations;

namespace OpLaba4.Models;

public class CalculatorViewModel
{
    private static readonly object Lock = new();
    private static HashSet<string>? _cachedOperators;

    private static HashSet<string> CachedOperators
    {
        get
        {
            if (_cachedOperators is null)
            {
                lock (Lock)
                {
                    _cachedOperators ??= new HashSet<string>
                        { Constants.Plus, Constants.Minus, Constants.Divide, Constants.Multiply };
                }
            }

            return _cachedOperators;
        }
    }

    public ulong LeftOperand { get; set; }
    public ulong RightOperand { get; set; }

    public string? SelectedOperator { get; set; }
    public HashSet<string> Operators => CachedOperators;
    public double? Result { get; set; }

    [Required] public string Action { get; set; }
}