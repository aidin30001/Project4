using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsync.Data
{
  public class DS_Money
  {
    private static int money = 100;
    public static int S_Money
    {
      get { return money; }
      set { money = value; }
    }
  }
}
