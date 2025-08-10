namespace RockPaperScissorslib;

/// <summary>
/// Харнит состояние игрока
/// </summary>
/// <param name="isComputer">игрок человек или компьютер</param>
/// <param name="name">имя игрока</param>
public class Player(bool isComputer, string name = "Компьютер")
{
    public string Name { get; set; } = name;
    public bool IsComputer { get; private set; } = isComputer;
    internal int CountWins { get;  set; } = 0;
    public RockPaperScissorsEnum Choice { get; set; }

    public string DisplayStatus()
    {
        return $"{Name} количество побед: {CountWins}.";
    }
}
/// <summary>
/// Выбор вариантов игры камень, ножницы, бумага
/// </summary>
public enum RockPaperScissorsEnum
{
    Rock = 1,
    Paper,
    Scissors
}