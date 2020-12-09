using System;

namespace CashReturnCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cashItemValues = { 1, 5, 10, 20, 50, 100, 200, 500, 1000 };
            bool[] cashItemIsCoin = { true, true, true, true, false, false, false, false, false };
            Console.WriteLine("Hvor mye skal det betales? ");
            var paymentAmountString = Console.ReadLine();
            var paymentAmount = Convert.ToInt32(paymentAmountString);
            var countOfCashItem = new int[9];
            while (SumAmount(countOfCashItem, cashItemValues) < paymentAmount)
            {
                Console.Write("Angi betaling (eks: 7x5kr betyr sju femkroner): ");
                var paymentString = Console.ReadLine();
                if (!paymentString.Contains("x") || !paymentString.Contains("kr")) continue;
                var xIndex = paymentString.IndexOf("x");
                var countString = paymentString.Substring(0, xIndex);
                var isSuccessCount = int.TryParse(countString, out int count);
                if (!isSuccessCount) continue;
                var cashItemString = paymentString.Substring(xIndex + 1);
                var isSuccessCashItem = int.TryParse(cashItemString, out int cashItem);
                if (!isSuccessCashItem) continue;
                var cashItemIndex = Array.IndexOf(cashItemValues, cashItem);
                if (cashItemIndex == -1) continue;
            }

        }

        private static int SumAmount(int[] countOfCashItem, int[] cashItemValues)
        {
            var sum = 0;
            for (var i = 0; i < countOfCashItem.Length; i++)
            {
                sum += countOfCashItem[i] * cashItemValues[i];
            }
            return sum;
        }
    }
}
