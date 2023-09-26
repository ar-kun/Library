using System.Data.SqlClient;

namespace Library;

public class PeminjamanBuku
{
  public string Id { get; set; }
  public string IdBuku { get; set; }
  public string IdAnggota { get; set; }
  public string TanggalPinjam { get; set; }
  public string TanggalKembali { get; set; }
  public string Status { get; set; }


  private readonly string connectionString = "Server=ARKUN;Database=db_hr_library;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {IdBuku} - {IdAnggota} - {TanggalPinjam} - {TanggalKembali} - {Status}";
  }

  public List<PeminjamanBuku> GetAll()
  {
    var peminjamanBuku = new List<PeminjamanBuku>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM peminjaman";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          peminjamanBuku.Add(new PeminjamanBuku
          {
            Id = reader.GetString(0),
            IdBuku = reader.GetString(1),
            IdAnggota = reader.GetString(2),
            TanggalPinjam = reader.GetString(3),
            TanggalKembali = reader.GetString(4),
            Status = reader.GetString(5)
          });
        }
        reader.Close();
        connection.Close();

        return peminjamanBuku;
      }
      reader.Close();
      connection.Close();

      return new List<PeminjamanBuku>();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return new List<PeminjamanBuku>();
    }
  }

  public string Insert(PeminjamanBuku peminjamanBuku)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO peminjaman VALUES(@id, @idBuku, @idAnggota, @tanggalPinjam, @tanggalKembali, @status)";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", peminjamanBuku.Id));
      command.Parameters.Add(new SqlParameter("@idBuku", peminjamanBuku.IdBuku));
      command.Parameters.Add(new SqlParameter("@idAnggota", peminjamanBuku.IdAnggota));
      command.Parameters.Add(new SqlParameter("@tanggalPinjam", peminjamanBuku.TanggalPinjam));
      command.Parameters.Add(new SqlParameter("@tanggalKembali", peminjamanBuku.TanggalKembali));
      command.Parameters.Add(new SqlParameter("@status", peminjamanBuku.Status));

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

  public string Update(PeminjamanBuku peminjamanBuku)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE peminjaman SET id_buku = @idBuku, id_anggota = @idAnggota, tanggal_pinjam = @tanggalPinjam, tanggal_kembali = @tanggalKembali, status = @status WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", peminjamanBuku.Id));
      command.Parameters.Add(new SqlParameter("@idBuku", peminjamanBuku.IdBuku));
      command.Parameters.Add(new SqlParameter("@idAnggota", peminjamanBuku.IdAnggota));
      command.Parameters.Add(new SqlParameter("@tanggalPinjam", peminjamanBuku.TanggalPinjam));
      command.Parameters.Add(new SqlParameter("@tanggalKembali", peminjamanBuku.TanggalKembali));
      command.Parameters.Add(new SqlParameter("@status", peminjamanBuku.Status));

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

  public string Delete(PeminjamanBuku peminjamanBuku)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM peminjaman WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", peminjamanBuku.Id));

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