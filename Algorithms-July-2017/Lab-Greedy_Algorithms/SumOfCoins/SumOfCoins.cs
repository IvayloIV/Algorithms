using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var result = new Dictionary<int, int>();
        var currentSum = 0;
        coins = coins.OrderByDescending(a => a).ToList();

        var index = 0;
        while (index < coins.Count && currentSum < targetSum)
        {
            var currentCoin = coins[index];
            if (currentSum + currentCoin <= targetSum)
            {
                var remainder = (targetSum - currentSum) / currentCoin;
                currentSum += currentCoin * remainder;
                result.Add(currentCoin, remainder);
            }
            index++;
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}