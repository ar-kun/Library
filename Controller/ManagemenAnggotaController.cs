using Library.Views;

namespace Library.Controller;

public class ManagemenAnggotaController
{
  private ManagemenAnggota _managemenAnggota;

  private ManagemenAnggotaView _managemenAnggotaView;

  public ManagemenAnggotaController(ManagemenAnggota managemenAnggota, ManagemenAnggotaView managemenAnggotaView)
  {
    _managemenAnggota = managemenAnggota;
    _managemenAnggotaView = managemenAnggotaView;
  }

  public void GetAll()
  {
    var results = _managemenAnggota.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _managemenAnggotaView.List(results, "anggota");
    }
  }

  public void Insert()
  {
    ManagemenAnggota inputAnggota = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputAnggota = _managemenAnggotaView.Insert();
        if (string.IsNullOrEmpty(inputAnggota.Id))
        {
          Console.WriteLine("Anggota title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _managemenAnggota.Insert(inputAnggota);

    _managemenAnggotaView.Transaction(result);
  }

  public void Update()
  {
    var anggota = new ManagemenAnggota();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        anggota = _managemenAnggotaView.Update();
        if (string.IsNullOrEmpty(anggota.Id))
        {
          Console.WriteLine("Anggota title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _managemenAnggota.Update(anggota);

    _managemenAnggotaView.Transaction(result);
  }

  public void Delete()
  {
    var anggota = new ManagemenAnggota();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        anggota = _managemenAnggotaView.Delete();
        if (string.IsNullOrEmpty(anggota.Id))
        {
          Console.WriteLine("Anggota title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _managemenAnggota.Delete(anggota);

    _managemenAnggotaView.Transaction(result);
  }
}