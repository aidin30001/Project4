using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAsync.Data;

namespace AppAsync.Shop
{
  public static class PricesInfoAsync
  {
    private static int num = 0;
    private static readonly Random random = new Random();
    private static readonly PricesWriteOrReadAsync prices = new PricesWriteOrReadAsync();

    internal static async Task Next(int year = 0)
    {
      string infoWorld = null!;
      
      if (year == num)   
      {
        infoWorld = $"Apple: {DS_Prices.SP_Apple}\nMicrosoft: {DS_Prices.SP_Microsoft}";
      }
      else if (year != num)
      {
        DS_Prices.SP_Apple = random.Next(100);
        DS_Prices.SP_Microsoft = random.Next(100);
        await Update.NextAsync();
        infoWorld = $"Через {year} лет\nApple: {DS_Prices.SP_Apple}\nMicrosoft: {DS_Prices.SP_Microsoft}";
      }
      Text.WriteLineConsole(infoWorld);
    }
  }
}
