using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsync.Data
{
  public static class DS_Prices
  {
    private static int P_Apple = 10;
    public static int SP_Apple
    {
      get { return P_Apple ; }
      set { P_Apple  = value; }
    }

    private static int P_Microsoft = 10;
    public static int SP_Microsoft
    {
      get { return P_Microsoft; }
      set { P_Microsoft = value; }
    }
    
  }
}
