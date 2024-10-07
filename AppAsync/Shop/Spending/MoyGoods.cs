using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppAsync.Shop.Spending
{
  [DataContract]
  public class MoyGoods
  {
    [DataMember]
    public int AppleGoods { get; set; }
    [DataMember]
    public int MicrosoftGoods { get; set; }
    [DataMember]
    public int AppleMany { get; set; }
    [DataMember]
    public int MicrosoftMany { get; set; }

    public MoyGoods(int appleGoods, int appleMany, int microsoftGoods, int microsoftMany)
    {
      AppleGoods = appleGoods;
      MicrosoftGoods = microsoftGoods;
      AppleMany = appleMany;
      MicrosoftMany = microsoftMany;
    }
  }
}
