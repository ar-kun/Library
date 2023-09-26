using BasicConnectivity;

namespace Library.Views;

public class PeminjamanBukuView : GeneralView
{
  public PeminjamanBuku Insert()
  {
    Console.WriteLine("Insert id peminjaman buku");
    var id = Console.ReadLine();
    Console.WriteLine("Insert id anggota");
    var id_anggota = Console.ReadLine();
    Console.WriteLine("Insert id buku");
    var id_buku = Console.ReadLine();
    Console.WriteLine("Insert tanggal peminjaman");
    var tanggal_peminjaman = Console.ReadLine();
    Console.WriteLine("Insert tanggal pengembalian");
    var tanggal_pengembalian = Console.ReadLine();
    Console.WriteLine("Insert status peminjaman");
    var status_peminjaman = Console.ReadLine();

    return new PeminjamanBuku
    {
      Id = id,
      IdAnggota = id_anggota,
      IdBuku = id_buku,
      TanggalPinjam = tanggal_peminjaman,
      TanggalKembali = tanggal_pengembalian,
      Status = status_peminjaman
    };
  }

  public PeminjamanBuku Update()
  {
    Console.WriteLine("Insert id peminjaman buku");
    var id = Console.ReadLine();
    Console.WriteLine("Insert id anggota");
    var id_anggota = Console.ReadLine();
    Console.WriteLine("Insert id buku");
    var id_buku = Console.ReadLine();
    Console.WriteLine("Insert tanggal peminjaman");
    var tanggal_peminjaman = Console.ReadLine();
    Console.WriteLine("Insert tanggal pengembalian");
    var tanggal_pengembalian = Console.ReadLine();
    Console.WriteLine("Insert status peminjaman");
    var status_peminjaman = Console.ReadLine();

    return new PeminjamanBuku
    {
      Id = id,
      IdAnggota = id_anggota,
      IdBuku = id_buku,
      TanggalPinjam = tanggal_peminjaman,
      TanggalKembali = tanggal_pengembalian,
      Status = status_peminjaman
    };
  }

  public PeminjamanBuku Delete()
  {
    Console.WriteLine("Insert id peminjaman buku");
    var id = Console.ReadLine();

    return new PeminjamanBuku
    {
      Id = id,

    };
  }

}