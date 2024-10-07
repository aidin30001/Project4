using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using AppAsync.Data;

namespace AppAsync.Currencies
{
  public class MoneyWriteOrReadAsync
  {
    private static readonly string path = @"AppAsync\Data\Money.json";
    private static DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Money>));
    private static List<Money> _money = new List<Money>();
    
    internal async Task ReadMoneyAsync(int newMoney)
    {
      await Task.Run(() => ReadMoney(newMoney));
    }
    internal void ReadMoney(int newMoney)
    {
      using (FileStream file = new FileStream(path, FileMode.Create))
      {
        _money.Add(new Money(newMoney));
        jsonFormatter.WriteObject(file, _money);
      }
    }

    internal async Task WriteMoneyAsync()
    {
      await Task.Run (() => WriteMoney());
    }
    
    internal void WriteMoney()
    {
      using (FileStream file = new FileStream(path, FileMode.Open))
      {
        var newMoney = jsonFormatter.ReadObject(file) as List<Money>;

        if (newMoney != null)
        {
          foreach (var _newMoney in newMoney)
          {
            DS_Money.S_Money = _newMoney.MoneyGetSet;
          }
        }
      }
    }
  }
}
