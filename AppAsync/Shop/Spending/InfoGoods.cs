using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAsync.Data;

namespace AppAsync.Shop.Spending
{
  public static class InfoGoods
  {
    private static readonly GoodsWriteOrReadAsync goods = new GoodsWriteOrReadAsync();

    public static void Next()
    {
      string? infoWorld = null;
      
      if (DS_MoyGoods.DS_G_Apple == 0 && DS_MoyGoods.DS_G_Microsoft == 0)
      {
        infoWorld = $"У вас нет покупок";
      }
      else if (DS_MoyGoods.DS_G_Apple != 0 && DS_MoyGoods.DS_G_Microsoft != 0)
      {
        Text.WriteLineConsole($"Apple за {DS_MoyGoods.DS_G_Apple}$ {DS_MoyGoods.DS_G_AppleMany} столько раз покупали", $"Microsoft за {DS_MoyGoods.DS_G_Microsoft}$ {DS_MoyGoods.DS_G_MicrosoftMany} столько раз покупали");
      }
      else if (DS_MoyGoods.DS_G_Apple != 0)
      {
        infoWorld = $"Apple за {DS_MoyGoods.DS_G_Apple}$ {DS_MoyGoods.DS_G_AppleMany} столько раз покупали";
      }
      else if (DS_MoyGoods.DS_G_Microsoft != 0)
      {
        infoWorld = $"Microsoft за {DS_MoyGoods.DS_G_Microsoft}$ {DS_MoyGoods.DS_G_MicrosoftMany} столько раз покупали";
      }
      Text.WriteLineConsole(infoWorld!);
    }
  }
}
