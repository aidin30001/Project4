using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsync.Data
{
  public static class DS_MoyGoods
  {
    private static int appleGoods = 0;
    public static int DS_G_Apple
    {
      get { return appleGoods; }
      set { appleGoods = value; }
    }
    private static int microsoftGoods = 0;
    public static int DS_G_Microsoft
    {
      get { return microsoftGoods; }
      set { microsoftGoods = value; }
    }
    private static int appleMany = 0;
    public static int DS_G_AppleMany
    {
      get { return appleMany; }
      set { appleMany = value; }
    }
    private static int microsoftMany = 0;
    public static int DS_G_MicrosoftMany
    {
      get { return microsoftMany; }
      set { microsoftMany = value; }
    }
        
  }
}
