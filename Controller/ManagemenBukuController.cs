using Library.Views;

namespace Library.Controller;

public class ManagemenBukuController
{
  private ManagemenBuku _managemenBuku;

  private ManagemenBukuView _managemenBukuView;

  public ManagemenBukuController(ManagemenBuku managemenBuku, ManagemenBukuView managemenBukuView)
  {
    _managemenBuku = managemenBuku;
    _managemenBukuView = managemenBukuView;
  }

  public void GetAll()
  {
    var results = _managemenBuku.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _managemenBukuView.List(results, "buku");
    }
  }

  public void Insert()
  {
    ManagemenBuku inputBuku = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputBuku = _managemenBukuView.Insert();
        if (string.IsNullOrEmpty(inputBuku.Id))
        {
          Console.WriteLine("Buku title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _managemenBuku.Insert(inputBuku);

    _managemenBukuView.Transaction(result);
  }

  public void Update()
  {
    var buku = new ManagemenBuku();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        buku = _managemenBukuView.Update();
        if (string.IsNullOrEmpty(buku.Id))
        {
          Console.WriteLine("Buku title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _managemenBuku.Update(buku);

    _managemenBukuView.Transaction(result);
  }

  public void Delete()
  {
    var buku = new ManagemenBuku();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        buku = _managemenBukuView.Delete();
        if (string.IsNullOrEmpty(buku.Id))
        {
          Console.WriteLine("Buku title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _managemenBuku.Delete(buku);

    _managemenBukuView.Transaction(result);
  }
}