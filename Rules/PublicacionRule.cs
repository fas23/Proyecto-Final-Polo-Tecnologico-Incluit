
using Dapper;
using Proyecto_Final_Polo_Tecnologico_Incluit.Models;
using System.Data.SqlClient;

namespace Proyecto_Final_Polo_Tecnologico_Incluit.Rules;


public class PublicacionRule
{
    public Publicacion GetPublicacionRandom()
    {
        var connectionString = @"Server=DESKTOP-67VKNPT;Database=BlogDataBase;Trusted_Connection=True";
        using var connection = new SqlConnection(connectionString);
        {
            connection.Open();
            var post = connection.Query<Publicacion>("select top 1 * from Publicacion ");

            return post.First();
        }

        
    }
}
