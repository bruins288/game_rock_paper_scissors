using Microsoft.VisualBasic;
using RockPaperScissorslib;

public partial class Program
{
    private static int GetChoicePlayers()
    {

        Console.Write("выберете количество игроков от 1 до 2: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
        {
            return choice;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Игроков должно быть не более двух!");
        }
    }
    private static void Run()
    {
       Game.CountRounds = 3;
        
        int countPlayers = GetChoicePlayers();
        Player player1 = countPlayers == 1 ? new Player(isComputer: true) : new Player(isComputer: false, name: "Игрок1");
        Player player2 = new(isComputer: false, name: "Игрок2");
        while (Game.CountRounds > 0)
        {
            if (countPlayers == 1)
            {
                player1.Choice = Game.GetComputerChoice();
                Console.WriteLine($"{player1.Name} сделал ход.\n");
            }
            else
            {
                player1.Choice = GetUserMotion(player1);
            }
            player2.Choice = GetUserMotion(player2);
            string result = Game.Play(player1, player2);
            Console.WriteLine(result);
            Game.CountRounds--;
        }

        Console.WriteLine($"Игра закончилась со счетом: {player1.Name} {player1.CountWins} : {player2.CountWins} {player2.Name}");
    }
    private static RockPaperScissorsEnum GetUserMotion(Player player)
    {
        Console.WriteLine($"\nХод {player.Name}:\nКамень - 1\nБумага - 2\nНожницы - 3");
        var input = Console.ReadLine();
        if (Enum.TryParse(typeof(RockPaperScissorsEnum), input, out var result))
        {
            return (RockPaperScissorsEnum)result;
        }
        else
        {
            throw new ArgumentException("Выбор должен быть от 1 до 3 включительно!");
        }
    }
}
