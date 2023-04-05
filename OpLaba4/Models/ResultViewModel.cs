namespace OpLaba4.Models;

public class ResultViewModel
{
    public string? LeftOperand { get; set; }
    public string? RightOperand { get; set; }
    public string? SelectedOperator { get; set; }
    public string? Result { get; set; }

    public string Message =>
        HasData ? $"{LeftOperand} {SelectedOperator} {RightOperand} = {Result}" : "Не найдено информации в сесии";

    public string MessageV2
    {
        get
        {
            if (HasData)
            {
                return Message.Remove(Message.LastIndexOfAny(new[] { '=' }), 1)
                    .Insert(Message.LastIndexOfAny(new[] { '=' }), "Равно");
            }

            return Message;
        }
    }

    public bool HasData => Result is not null
                           && LeftOperand is not null
                           && RightOperand is not null
                           && SelectedOperator is not null;
}