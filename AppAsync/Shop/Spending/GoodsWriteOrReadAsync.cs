using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using AppAsync.Data;

namespace AppAsync.Shop.Spending
{
  public class GoodsWriteOrReadAsync
  {
    private static readonly string path = @"AppAsync\Data\Goods.json";
    private static DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<MoyGoods>));
    private static List<MoyGoods> _moyGoods = new List<MoyGoods>();

    internal async Task ReadGoodsAsync(int newGoodsApple, int newAppleMany, int newGoodsMicrosoft, int newMicrosoftMany)
    {
      await Task.Run(() => ReadGoods(newGoodsApple, newAppleMany, newGoodsMicrosoft, newMicrosoftMany));
    }
    internal void ReadGoods(int newGoodsApple, int newAppleMany, int newGoodsMicrosoft, int newMicrosoftMany)
    {
      using (FileStream file = new FileStream(path, FileMode.Create))
      {
        _moyGoods.Add(new MoyGoods(newGoodsApple, newAppleMany, newGoodsMicrosoft, newMicrosoftMany));
        jsonFormatter.WriteObject(file, _moyGoods);
      }
    }

    internal async Task WriteGoodsAsync()
    {
      await Task.Run(() => WriteGoods());
    }
    internal void WriteGoods()
    {
      using (FileStream file = new FileStream(path, FileMode.Open))
      {
        var newGoods = jsonFormatter.ReadObject(file) as List<MoyGoods>;

        if (newGoods != null)
        {
          foreach (var _newGoods in newGoods)
          {
            DS_MoyGoods.DS_G_Apple = _newGoods.AppleGoods;
            DS_MoyGoods.DS_G_Microsoft = _newGoods.MicrosoftGoods;
            DS_MoyGoods.DS_G_MicrosoftMany = _newGoods.MicrosoftMany;
            DS_MoyGoods.DS_G_AppleMany = _newGoods.AppleMany;
          }
        }
      }
    }
  }
}
