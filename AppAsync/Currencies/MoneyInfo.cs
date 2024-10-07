using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAsync.Data;

namespace AppAsync.Currencies
{
  public static class MoneyInfo
  {
    private static readonly MoneyWriteOrReadAsync money = new MoneyWriteOrReadAsync();
    public static void Next()
    {
      string? infoWorld = null;
      infoWorld = $"Деньги: {DS_Money.S_Money}";

      Text.WriteLineConsole(infoWorld);
    }
  }
}
