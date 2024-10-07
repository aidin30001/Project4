using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsync
{
  public static class Text
  {
    private static int step = 30;
    private static char symbol = '-';
    public static void WriteLineConsole( params string[] value)
    {
      Console.WriteLine(new string(symbol, step));
      foreach (var item in value)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine(new string(symbol, step));
    }
    public static void WriteTopConsole( params string[] value)
    {
      Console.WriteLine(new string(symbol, step));
      foreach (var item in value)
      {
        Console.WriteLine(item);
      }
    }
    public static void WriteDownConsole( params string[] value)
    {
      foreach (var item in value)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine(new string(symbol, step));
    }
    public static void WriteMiddleConsoleTop(params string[] value)
    {
      foreach (var item in value)
      {
        Console.WriteLine(new string(symbol, step));
        Console.WriteLine(item);
      }
    }
    public static void WriteMiddleConsoleDown( params string[] value)
    {
      foreach (var item in value)
      {
        Console.WriteLine(item);
        Console.WriteLine(new string(symbol, step));
      }
    }
  }
}
