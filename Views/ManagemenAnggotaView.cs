using BasicConnectivity;

namespace Library.Views;

public class ManagemenAnggotaView : GeneralView
{

  public ManagemenAnggota Insert()
  {
    Console.WriteLine("Insert id anggota");
    var id = Console.ReadLine();
    Console.WriteLine("Insert nama anggota");
    var nama = Console.ReadLine();
    Console.WriteLine("Insert alamat anggota");
    var alamat = Console.ReadLine();
    Console.WriteLine("Insert no telp anggota");
    var no_telp = Console.ReadLine();
    Console.WriteLine("Insert email anggota");
    var email = Console.ReadLine();
    Console.WriteLine("Insert no anggota anggota");
    var no_anggota = Console.ReadLine();

    return new ManagemenAnggota
    {
      Id = id,
      Nama = nama,
      Alamat = alamat,
      NoTelp = no_telp,
      Email = email,
      NoAnggota = no_anggota
    };
  }

  public ManagemenAnggota Update()
  {
    Console.WriteLine("Insert id anggota");
    var id = Console.ReadLine();
    Console.WriteLine("Insert nama anggota");
    var nama = Console.ReadLine();
    Console.WriteLine("Insert alamat anggota");
    var alamat = Console.ReadLine();
    Console.WriteLine("Insert no telp anggota");
    var no_telp = Console.ReadLine();
    Console.WriteLine("Insert email anggota");
    var email = Console.ReadLine();
    Console.WriteLine("Insert no anggota anggota");
    var no_anggota = Console.ReadLine();

    return new ManagemenAnggota
    {
      Id = id,
      Nama = nama,
      Alamat = alamat,
      NoTelp = no_telp,
      Email = email,
      NoAnggota = no_anggota
    };
  }

  public ManagemenAnggota Delete()
  {
    Console.WriteLine("Insert id anggota");
    var id = Console.ReadLine();
    return new ManagemenAnggota
    {
      Id = id
    };
  }

}