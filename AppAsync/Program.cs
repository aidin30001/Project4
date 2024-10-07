using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using AppAsync.Currencies;
using Newtonsoft.Json.Linq;
using AppAsync.Data;
using AppAsync.Shop;
using AppAsync.Shop.Spending;
using System.Text.Encodings.Web;

namespace AppAsync
{
  public class Program 
  {
    public static async Task Main(string[] args)
    {
      ThreadStart updateStart = new ThreadStart(Update.Next);
      Thread updateThread = new Thread(updateStart);

      ThreadStart start = new ThreadStart(Update.NextRead);
      Thread thread = new Thread(start);

      ThreadStart moneyStart = new ThreadStart(MoneyInfo.Next);
      Thread moneyThread = new Thread(moneyStart);

      ThreadStart manyStart = new ThreadStart(InfoGoods.Next);
      Thread manyThread = new Thread(manyStart);

      thread.Start();
      // updateThread.Start();
      
      try
      {
        bool stop = false; 

        while (!stop)
        {
          Thread.Sleep(200);
          Console.Clear();
          Text.WriteLineConsole("Добро пожаловать!");
          Console.WriteLine();
          Text.WriteMiddleConsoleTop("покупка", "продать", "деньги", "история", "выйти", "");
          string method = Console.ReadLine()!;
          switch (method.ToLower())
          {
            case "выйти":
              stop = true;
              break;
            case "деньги":
              Console.Clear();
              moneyThread.Start();
              Thread.Sleep(10);
              Console.WriteLine();
              Text.WriteMiddleConsoleTop("назад", "выйти", "");
              stop = Back();
              break;
            case "покупка":
              Console.Clear();
              await PricesInfoAsync.Next();
              Console.WriteLine();
              Text.WriteMiddleConsoleTop("введите имя продукта", "назад", "выйти", "");
              stop = CheckProducts();
              updateThread.Start();
              break;
            case "история":
              Console.Clear();
              manyThread.Start();
              Thread.Sleep(10);
              Text.WriteMiddleConsoleTop("назад", "выйти", "");
              stop = Back();
              break;
            default:
              Console.Clear();
              Text.WriteLineConsole($"нет такой команды: {method}\nповторите еще раз");
              Console.ReadKey();
              break;
          }
          
        }
      }
      catch (Exception e)
      {
        Text.WriteLineConsole(e.Message);
      }
      finally
      {
        Update.Next();
        Console.Clear();
        Text.WriteLineConsole("завершается");
        Thread.Sleep(2000);
      }
    }

    static bool Back()
    {
      bool back = false;
      bool stop = false;

      while (!back)
      {
        string strBack = Console.ReadLine()!;

        switch (strBack.ToLower())
        {
          case "назад":
            back = true;
            break;
          case "выйти":
            back = true;
            stop = true;
            break;
          default:
            Text.WriteLineConsole($"нет такой команды: {strBack}\nповторите еще раз");
            break;
        }
      }
        return stop;
    }
    static bool CheckProducts()
    {
      bool back = false;
      bool stop = false;

      while (!back)
      {
        string strBack = Console.ReadLine()!;

        switch (strBack.ToLower())
        {
          case "назад":
            back = true;
            break;
          case "выйти":
            back = true;
            stop = true;
            break;
          case "apple":
            Purchase.Next(strBack.ToLower());
            back = true;
            break;
          case "microsoft":
            Purchase.Next(strBack.ToLower());
            back = true;
            break;
          default:
            Text.WriteLineConsole($"нет такой команды: {strBack}\nповторите еще раз");
            break;
        }
      }
        return stop;
    }
  }
}
