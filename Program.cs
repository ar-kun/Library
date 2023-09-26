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
      Console.Write("Enter your choice: ");
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

    var managemenBukuController = new ManagemenBukuController(managemenBuku, managemenBukuView);

    var active = true;
    while (active)
    {
      Console.WriteLine("1. Get All");
      Console.WriteLine("2. Insert");
      Console.WriteLine("3. Update");
      Console.WriteLine("4. Delete");
      Console.WriteLine("5. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          managemenBukuController.GetAll();
          break;
        case "2":
          managemenBukuController.Insert();
          break;
        case "3":
          managemenBukuController.Update();
          break;
        case "4":
          managemenBukuController.Delete();
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

  public static void ManajemenAnggota()
  {
    var managemenAnggota = new ManagemenAnggota();
    var managemenAnggotaView = new ManagemenAnggotaView();

    var managemenAnggotaController = new ManagemenAnggotaController(managemenAnggota, managemenAnggotaView);

    var active = true;
    while (active)
    {
      Console.WriteLine("1. Get All");
      Console.WriteLine("2. Insert");
      Console.WriteLine("3. Update");
      Console.WriteLine("4. Delete");
      Console.WriteLine("5. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          managemenAnggotaController.GetAll();
          break;
        case "2":
          managemenAnggotaController.Insert();
          break;
        case "3":
          managemenAnggotaController.Update();
          break;
        case "4":
          managemenAnggotaController.Delete();
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

  public static void PeminjamanBuku()
  {
    var peminjamanBuku = new PeminjamanBuku();
    var peminjamanBukuView = new PeminjamanBukuView();

    var peminjamanBukuController = new PeminjamanBukuController(peminjamanBuku, peminjamanBukuView);

    var active = true;
    while (active)
    {
      Console.WriteLine("1. Get All");
      Console.WriteLine("2. Insert");
      Console.WriteLine("3. Update");
      Console.WriteLine("4. Delete");
      Console.WriteLine("5. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          peminjamanBukuController.GetAll();
          break;
        case "2":
          peminjamanBukuController.Insert();
          break;
        case "3":
          peminjamanBukuController.Update();
          break;
        case "4":
          peminjamanBukuController.Delete();
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