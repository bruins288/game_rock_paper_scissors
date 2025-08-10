namespace RockPaperScissorslib;

/// <summary>
/// Описывает игру камень, ножницы, бумага
/// </summary>
public static class Game
{
    private static int _countRounds;
    /// <summary>
    /// Устанавливает количество раундов
    /// </summary>
    public static int CountRounds
    {
        set
        {          
            _countRounds = value;
        }
        get => _countRounds;
    }
    /// <summary>
    /// Выбор значения компьютером
    /// </summary>
    /// <returns>Перечисление RockPaperScissorsEnum</returns>
    public static RockPaperScissorsEnum GetComputerChoice()
    {
        int rand = Random.Shared.Next(1, 4);
        return (RockPaperScissorsEnum)rand;
    }
    /// <summary>
    /// Ход игры
    /// </summary>
    /// <param name="player1">Первый игрок</param>
    /// <param name="player2">Второй игрок</param>
    /// <returns>Определение победителя</returns>
    public static string Play(Player player1, Player player2)
    {
        (byte choice1, byte choice2) motion = (player1.Choice, player2.Choice) switch
        {
            (RockPaperScissorsEnum.Rock, RockPaperScissorsEnum.Paper) => (0, 1),
            (RockPaperScissorsEnum.Rock, RockPaperScissorsEnum.Scissors) => (1, 0),
            (RockPaperScissorsEnum.Paper, RockPaperScissorsEnum.Scissors) => (0, 1),
            (RockPaperScissorsEnum.Paper, RockPaperScissorsEnum.Rock) => (1, 0),
            (RockPaperScissorsEnum.Scissors, RockPaperScissorsEnum.Rock) => (0, 1),
            (RockPaperScissorsEnum.Scissors, RockPaperScissorsEnum.Paper) => (1, 0),
            _ => (0, 0)
        };
        player1.CountWins += motion.choice1;
        player2.CountWins += motion.choice2;
        return motion switch
        {
            (1, 0) => $"Выиграл {player1.Name}!",
            (0, 1) => $"Выиграл {player2.Name}!",
            _ => "Ничья!"
        };
    }
    
}