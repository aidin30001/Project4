using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppAsync.Currencies
{
  [DataContract]
  public class Money
  {
    [DataMember]
    public int MoneyGetSet { get; set; }
    public Money(int money)
    {
      MoneyGetSet = money;
    }
  }
}
