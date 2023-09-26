using System.Data.SqlClient;

namespace Library;

public class ManagemenBuku
{
  public string Id { get; set; }
  public string Judul { get; set; }
  public string Pengarang { get; set; }
  public string Penerbit { get; set; }
  public string TahunTerbit { get; set; }
  public string ISBN { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_library;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {Judul} - {Pengarang} - {Penerbit} - {TahunTerbit} - {ISBN}";
  }

  public List<ManagemenBuku> GetAll()
  {
    var managemenBuku = new List<ManagemenBuku>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM library";
    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          managemenBuku.Add(new ManagemenBuku
          {
            Id = reader.GetString(0),
            Judul = reader.GetString(1),
            Pengarang = reader.GetString(2),
            Penerbit = reader.GetString(3),
            TahunTerbit = reader.GetString(4),
            ISBN = reader.GetString(5)
          });
        }
        reader.Close();
        connection.Close();

        return managemenBuku;
      }
      reader.Close();
      connection.Close();

      return new List<ManagemenBuku>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<ManagemenBuku>();
  }

  public string Insert(ManagemenBuku managemenBuku)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO library VALUES (@id, @judul, @pengarang, @penerbit, @tahun_terbit, @isbn)";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", managemenBuku.Id));
      command.Parameters.Add(new SqlParameter("@judul", managemenBuku.Judul));
      command.Parameters.Add(new SqlParameter("@pengarang", managemenBuku.Pengarang));
      command.Parameters.Add(new SqlParameter("@penerbit", managemenBuku.Penerbit));
      command.Parameters.Add(new SqlParameter("@tahun_terbit", managemenBuku.TahunTerbit));
      command.Parameters.Add(new SqlParameter("@isbn", managemenBuku.ISBN));

      connection.Open();
      using var transaction = connection.BeginTransaction();
      try
      {
        command.Transaction = transaction;

        var result = command.ExecuteNonQuery();

        transaction.Commit();
        connection.Close();

        return result.ToString();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        return $"Error Transaction: {ex.Message}";
      }
    }
    catch (Exception ex)
    {
      return $"Error: {ex.Message}";
    }
  }

  public string Update(ManagemenBuku managemenBuku)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE library SET id = @id, judul = @judul, pengarang = @pengarang, penerbit = @penerbit, tahun_terbit = @tahun_terbit, isbn = @isbn WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", managemenBuku.Id));
      command.Parameters.Add(new SqlParameter("@judul", managemenBuku.Judul));
      command.Parameters.Add(new SqlParameter("@pengarang", managemenBuku.Pengarang));
      command.Parameters.Add(new SqlParameter("@penerbit", managemenBuku.Penerbit));
      command.Parameters.Add(new SqlParameter("@tahun_terbit", managemenBuku.TahunTerbit));
      command.Parameters.Add(new SqlParameter("@isbn", managemenBuku.ISBN));

      connection.Open();
      using var transaction = connection.BeginTransaction();
      try
      {
        command.Transaction = transaction;

        var result = command.ExecuteNonQuery();

        transaction.Commit();
        connection.Close();

        return result.ToString();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        return $"Error Transaction: {ex.Message}";
      }
    }
    catch (Exception ex)
    {
      return $"Error: {ex.Message}";
    }

  }

  public string Delete(ManagemenBuku managemenBuku)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM library WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", managemenBuku.Id));

      connection.Open();
      using var transaction = connection.BeginTransaction();
      try
      {
        command.Transaction = transaction;

        var result = command.ExecuteNonQuery();

        transaction.Commit();
        connection.Close();

        return result.ToString();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        return $"Error Transaction: {ex.Message}";
      }
    }
    catch (Exception ex)
    {
      return $"Error: {ex.Message}";
    }
  }
}