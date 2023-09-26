using Library.Views;

namespace Library.Controller;

public class PeminjamanBukuController
{
  private PeminjamanBuku _peminjamanBuku;

  private PeminjamanBukuView _peminjamanBukuView;

  public PeminjamanBukuController(PeminjamanBuku peminjamanBuku, PeminjamanBukuView peminjamanBukuView)
  {
    _peminjamanBuku = peminjamanBuku;
    _peminjamanBukuView = peminjamanBukuView;
  }

  public void GetAll()
  {
    var results = _peminjamanBuku.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _peminjamanBukuView.List(results, "peminjaman buku");
    }
  }

  public void Insert()
  {
    PeminjamanBuku inputPeminjamanBuku = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputPeminjamanBuku = _peminjamanBukuView.Insert();
        if (string.IsNullOrEmpty(inputPeminjamanBuku.Id))
        {
          Console.WriteLine("Peminjaman Buku title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _peminjamanBuku.Insert(inputPeminjamanBuku);

    _peminjamanBukuView.Transaction(result);
  }

  public void Update()
  {
    var peminjamanBuku = new PeminjamanBuku();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        peminjamanBuku = _peminjamanBukuView.Update();
        if (string.IsNullOrEmpty(peminjamanBuku.Id))
        {
          Console.WriteLine("Peminjaman Buku title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _peminjamanBuku.Update(peminjamanBuku);

    _peminjamanBukuView.Transaction(result);
  }

  public void Delete()
  {
    var peminjamanBuku = new PeminjamanBuku();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        peminjamanBuku = _peminjamanBukuView.Delete();
        if (string.IsNullOrEmpty(peminjamanBuku.Id))
        {
          Console.WriteLine("Peminjaman Buku title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _peminjamanBuku.Delete(peminjamanBuku);

    _peminjamanBukuView.Transaction(result);
  }
}