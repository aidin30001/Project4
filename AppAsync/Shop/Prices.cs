using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AppAsync.Shop
{
  [DataContract]
  public class Prices
  {
    [DataMember]
    public int P_Apple { get; set; }
    [DataMember]
    public int P_Microsoft { get; set; }
    public Prices(int pricesApple, int pricesMicrosoft)
    {
      P_Apple = pricesApple;
      P_Microsoft = pricesMicrosoft;
    }
  }
}
