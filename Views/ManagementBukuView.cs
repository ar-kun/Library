using BasicConnectivity;

namespace Library.Views;

public class ManagemenBukuView : GeneralView
{

  public ManagemenBuku Insert()
  {
    Console.WriteLine("Insert id buku");
    var id = Console.ReadLine();
    Console.WriteLine("Insert judul buku");
    var judul = Console.ReadLine();
    Console.WriteLine("Insert pengarang buku");
    var pengarang = Console.ReadLine();
    Console.WriteLine("Insert penerbit buku");
    var penerbit = Console.ReadLine();
    Console.WriteLine("Insert tahun terbit buku");
    var tahun_terbit = Console.ReadLine();
    Console.WriteLine("Insert isbn buku");
    var isbn = Console.ReadLine();

    return new ManagemenBuku
    {
      Id = id,
      Judul = judul,
      Pengarang = pengarang,
      Penerbit = penerbit,
      TahunTerbit = tahun_terbit,
      ISBN = isbn
    };
  }

  public ManagemenBuku Update()
  {
    Console.WriteLine("Insert id buku");
    var id = Console.ReadLine();
    Console.WriteLine("Insert judul buku");
    var judul = Console.ReadLine();
    Console.WriteLine("Insert pengarang buku");
    var pengarang = Console.ReadLine();
    Console.WriteLine("Insert penerbit buku");
    var penerbit = Console.ReadLine();
    Console.WriteLine("Insert tahun terbit buku");
    var tahun_terbit = Console.ReadLine();
    Console.WriteLine("Insert isbn buku");
    var isbn = Console.ReadLine();

    return new ManagemenBuku
    {
      Id = id,
      Judul = judul,
      Pengarang = pengarang,
      Penerbit = penerbit,
      TahunTerbit = tahun_terbit,
      ISBN = isbn
    };
  }

  public ManagemenBuku Delete()
  {
    Console.WriteLine("Insert id buku");
    var id = Console.ReadLine();
    return new ManagemenBuku
    {
      Id = id
    };
  }

}