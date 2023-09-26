using System.Data.SqlClient;

namespace Library;

public class ManagemenAnggota
{
  public string Id { get; set; }
  public string Nama { get; set; }
  public string Alamat { get; set; }
  public string NoTelp { get; set; }
  public string Email { get; set; }
  public string NoAnggota { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_library;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {Nama} - {Alamat} - {NoTelp} - {Email} - {NoAnggota}";
  }

  public List<ManagemenAnggota> GetAll()
  {
    var managemenAnggota = new List<ManagemenAnggota>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM anggota";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          managemenAnggota.Add(new ManagemenAnggota
          {
            Id = reader.GetString(0),
            Nama = reader.GetString(1),
            Alamat = reader.GetString(2),
            NoTelp = reader.GetString(3),
            Email = reader.GetString(4),
            NoAnggota = reader.GetString(5)
          });
        }
        reader.Close();
        connection.Close();

        return managemenAnggota;
      }
      reader.Close();
      connection.Close();

      return new List<ManagemenAnggota>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<ManagemenAnggota>();
  }

  public string Insert(ManagemenAnggota managemenAnggota)
  {

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO anggota VALUES(@Id, @Nama, @Alamat, @NoTelp, @Email, @NoAnggota)";

    command.Parameters.Add(new SqlParameter("@Id", managemenAnggota.Id));
    command.Parameters.Add(new SqlParameter("@Nama", managemenAnggota.Nama));
    command.Parameters.Add(new SqlParameter("@Alamat", managemenAnggota.Alamat));
    command.Parameters.Add(new SqlParameter("@NoTelp", managemenAnggota.NoTelp));
    command.Parameters.Add(new SqlParameter("@Email", managemenAnggota.Email));
    command.Parameters.Add(new SqlParameter("@NoAnggota", managemenAnggota.NoAnggota));

    try
    {
      connection.Open();

      var result = command.ExecuteNonQuery();

      connection.Close();

      return result.ToString();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

  }

  public string Update(ManagemenAnggota managemenAnggota)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE anggota SET nama = @Nama, alamat = @Alamat, no_telp = @NoTelp, email = @Email, no_anggota = @NoAnggota WHERE id = @Id";

    command.Parameters.Add(new SqlParameter("@Id", managemenAnggota.Id));
    command.Parameters.Add(new SqlParameter("@Nama", managemenAnggota.Nama));
    command.Parameters.Add(new SqlParameter("@Alamat", managemenAnggota.Alamat));
    command.Parameters.Add(new SqlParameter("@NoTelp", managemenAnggota.NoTelp));
    command.Parameters.Add(new SqlParameter("@Email", managemenAnggota.Email));
    command.Parameters.Add(new SqlParameter("@NoAnggota", managemenAnggota.NoAnggota));

    try
    {
      connection.Open();

      var result = command.ExecuteNonQuery();

      connection.Close();

      return result.ToString();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }
  }

  public string Delete(ManagemenAnggota managemenAnggota)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM anggota WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@Id", managemenAnggota.Id));

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