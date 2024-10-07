using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AppAsync.Data;

namespace AppAsync.Shop
{
  public class PricesWriteOrReadAsync
  {
    private static readonly string path = @"AppAsync\Data\Prices.json";
    private static DataContractSerializer jsonFormatter = new DataContractSerializer(typeof(List<Prices>));
    private static List<Prices> _prices = new List<Prices>();

    internal async Task ReadPricesAsync(int newPricesApple, int newPricesMicrosoft)
    {
      await Task.Run(() => ReadPrices(newPricesApple, newPricesMicrosoft));
    }
    internal void ReadPrices(int newPricesApple, int newPricesMicrosoft)
    {
      using (FileStream file = new FileStream(path, FileMode.Create))
      {
        _prices.Add(new Prices(newPricesApple, newPricesMicrosoft));
        jsonFormatter.WriteObject(file, _prices);
      }
    }

    internal async Task WritePricesAsync()
    {
      await Task.Run (() => WritePrices());
    }
    internal void WritePrices()
    {
      using (FileStream file = new FileStream(path, FileMode.Open))
      {
        var newPrices = jsonFormatter.ReadObject(file) as List<Prices>;

        if (newPrices != null)
        {
          foreach (var _newPrices in newPrices)
          {
            DS_Prices.SP_Apple = _newPrices.P_Apple;
            DS_Prices.SP_Microsoft = _newPrices.P_Microsoft;
          }
        }
      }
    }
  }
}
