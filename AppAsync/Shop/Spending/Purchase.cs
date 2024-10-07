using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAsync.Currencies;
using AppAsync.Data;

namespace AppAsync.Shop.Spending
{
  public static class Purchase
  {
    private static int apple = 0;
    private static int microsoft = 0;
    private static int _money = DS_Money.S_Money;
    public static void Next(string goods)
    {
      string goodInfoPurchase = "Покупка прошла успешно";
      string noGoodInfoPurchase = "Покупка не прошла \nу вас не достаточно средств";

      try
      {
        switch (goods)
        {
          case "apple":
            if (DS_Prices.SP_Apple <= DS_Money.S_Money)
            {
              Console.Clear();
              Text.WriteLineConsole(goodInfoPurchase);
              Console.ReadKey();
              _money = DS_Money.S_Money - DS_Prices.SP_Apple;
              apple = DS_Prices.SP_Apple;
              DS_MoyGoods.DS_G_AppleMany ++;
            }
            else
            {
              Console.Clear();
              Text.WriteLineConsole(noGoodInfoPurchase);
              Console.ReadKey();
            }
            break;
          case "microsoft":
            if (DS_Money.S_Money >= DS_Prices.SP_Microsoft)
            {
              Console.Clear();
              Text.WriteLineConsole(goodInfoPurchase);
              Console.ReadKey();
              _money = DS_Money.S_Money - DS_Prices.SP_Microsoft;
              microsoft = DS_Prices.SP_Microsoft;
              DS_MoyGoods.DS_G_MicrosoftMany ++;
            }
            else
            {
              Console.Clear();
              Text.WriteLineConsole(noGoodInfoPurchase);
              Console.ReadKey();
            }
            break;
          default:
            Text.WriteLineConsole($"ошибка нет такой функции {goods}");
            Console.ReadKey();
            apple = 0;
            microsoft = 0;
            break;
        } 
      } 
      catch (Exception ex)    
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        DS_Money.S_Money = _money;
        DS_MoyGoods.DS_G_Microsoft = microsoft;
        DS_MoyGoods.DS_G_Apple = apple;
      }
    }
  }
}
