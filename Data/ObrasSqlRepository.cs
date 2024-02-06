using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UrbanTheater.Models;
namespace UrbanTheater.Data
{
    public class ObrasSqlRepository : IObrasRepository
    {
        private readonly string _connectionString;

        public ObrasSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Obras Get(int id)
        {
            Obras obra = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT ObraID, Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel FROM Obras WHERE ObraID = @ObraID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ObraID", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            obra = new Obras
                            {
                                ObraID = Convert.ToInt32(reader["ObraID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Autores = new List<string>(),
                                Duracion = Convert.ToDecimal(reader["Duracion"]),
                                Actores = new List<string>(),
                                Imagenes = new List<string>(),
                                Fechas = reader["Fechas"].ToString(),
                                Slug = reader["Slug"].ToString(),
                                Cartel = reader["Cartel"].ToString(),
                            };

                            foreach (var autor in reader["Autores"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                obra.Autores.Add(autor.Trim());
                            }

                            foreach (var actor in reader["Actores"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                obra.Actores.Add(actor.Trim());
                            }
                            foreach (var imagen in reader["Imagenes"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                obra.Imagenes.Add(imagen.Trim());
                            }
                        }
                    }
                }
            }
            return obra;
        }

        public List<Obras> GetAll()
        {
            var obras = new List<Obras>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT ObraID, Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel FROM Obras";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var obra = new Obras
                        {
                            ObraID = Convert.ToInt32(reader["ObraID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Autores = new List<string>(),
                            Duracion = Convert.ToDecimal(reader["Duracion"]),
                            Actores = new List<string>(),
                            Imagenes = new List<string>(),
                            Fechas = reader["Fechas"].ToString(),
                            Slug = reader["Slug"].ToString(),
                            Cartel = reader["Cartel"].ToString(),
                        };

                        // Procesar y añadir Autores
                        obra.Autores.AddRange(reader["Autores"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(autor => autor.Trim()));

                        // Procesar y añadir Actores
                        obra.Actores.AddRange(reader["Actores"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(actor => actor.Trim()));

                        // Procesar y añadir Imagenes
                        obra.Imagenes.AddRange(reader["Imagenes"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(imagen => imagen.Trim()));

                        obras.Add(obra);
                    }
                }
            }
            return obras;
        }

        public void Update(Obras obra)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
            UPDATE Obras 
            SET 
                Nombre = @Nombre, 
                Descripcion = @Descripcion, 
                Autores = @Autores, 
                Duracion = @Duracion, 
                Actores = @Actores, 
                Imagenes = @Imagenes, 
                Fechas = @Fechas, 
                Slug = @Slug, 
                Cartel = @Cartel 
            WHERE ObraID = @ObraID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ObraID", obra.ObraID);
                    command.Parameters.AddWithValue("@Nombre", obra.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", obra.Descripcion);
                    command.Parameters.AddWithValue("@Autores", string.Join(",", obra.Autores));
                    command.Parameters.AddWithValue("@Duracion", obra.Duracion);
                    command.Parameters.AddWithValue("@Actores", string.Join(",", obra.Actores));
                    command.Parameters.AddWithValue("@Imagenes", string.Join(",", obra.Imagenes));
                    command.Parameters.AddWithValue("@Fechas", obra.Fechas);
                    command.Parameters.AddWithValue("@Slug", obra.Slug);
                    command.Parameters.AddWithValue("@Cartel", obra.Cartel);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
