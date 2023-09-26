using Library.Controller;
using Library.Views;

namespace Library;

public class Program
{
  private static void Main()
  {
    var active = true;
    while (active)
    {
      Console.WriteLine("1. Manajemen Buku");
      Console.WriteLine("2. Manajemen Anggota");
      Console.WriteLine("3. Peminjaman Buku");
      Console.WriteLine("4. Exit");
      var input = Console.ReadLine();
      active = Menu(input);
    }
  }

  public static bool Menu(string input)
  {
    switch (input)
    {
      case "1":
        ManagemenBuku();
        break;
      case "2":
        ManajemenAnggota();
        break;
      case "3":
        PeminjamanBuku();
        break;
      case "4":
        return false;
      default:
        Console.WriteLine("Invalid choice");
        break;
    }

    return true;
  }

  public static void ManagemenBuku()
  {
    var managemenBuku = new ManagemenBuku();
    var managemenBukuView = new ManagemenBukuView();

    var managemenController = new ManagemenBukuController(managemenBuku, managemenBukuView);

    var active = true;
    while (active)
    {
      Console.WriteLine("1. Get All");
      Console.WriteLine("2. Insert");
      Console.WriteLine("3. Update");
      Console.WriteLine("4. Delete");
      Console.WriteLine("5. Back");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          managemenController.GetAll();
          break;
        case "2":
          managemenController.Insert();
          break;
        case "3":
          managemenController.Update();
          break;
        case "4":
          managemenController.Delete();
          break;
        case "5":
          active = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }




}