using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AppAsync.Currencies;
using AppAsync.Data;
using AppAsync.Shop;
using AppAsync.Shop.Spending;

namespace AppAsync
{
  public static class Update
  {
    
    private static MoneyWriteOrReadAsync money = new MoneyWriteOrReadAsync();
    private static PricesWriteOrReadAsync prices = new PricesWriteOrReadAsync();
    private static GoodsWriteOrReadAsync goods = new GoodsWriteOrReadAsync();

    private static int apple = 0;
    private static int appleMany = 0;
    private static int microsoft = 0;
    private static int microsoftMany = 0;
    private static int _money = 100;
    public static async Task NextAsync() 
    {
      apple = DS_MoyGoods.DS_G_Apple;
      appleMany = DS_MoyGoods.DS_G_AppleMany;
      microsoft = DS_MoyGoods.DS_G_Microsoft;
      microsoftMany = DS_MoyGoods.DS_G_MicrosoftMany;
      await goods.ReadGoodsAsync(apple,appleMany, microsoft, microsoftMany);

      _money = DS_Money.S_Money;
      await money.ReadMoneyAsync(_money);

      apple = DS_Prices.SP_Apple;
      microsoft = DS_Prices.SP_Microsoft;
      await prices.ReadPricesAsync(apple, microsoft);

      await goods.WriteGoodsAsync();
      await money.WriteMoneyAsync();
      await prices.WritePricesAsync();
      
    }
    public static async Task NextReadAsync()
    {
      await goods.WriteGoodsAsync();
      await money.WriteMoneyAsync();
      await prices.WritePricesAsync();
    }
    public static void NextRead()
    {
      goods.WriteGoods();
      money.WriteMoney();
      prices.WritePrices();
    }

    public static void Next()
    {
      goods.ReadGoods(DS_MoyGoods.DS_G_Apple,DS_MoyGoods.DS_G_AppleMany, DS_MoyGoods.DS_G_Microsoft, DS_MoyGoods.DS_G_MicrosoftMany);

      money.ReadMoney(DS_Money.S_Money);

      prices.ReadPrices(DS_Prices.SP_Apple, DS_Prices.SP_Microsoft);

      goods.WriteGoods();
      money.WriteMoney();
      prices.WritePrices();
    }
  }
}
