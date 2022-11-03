
using Dapper;
using Proyecto_Final_Polo_Tecnologico_Incluit.Models;
using System.Data.SqlClient;

namespace Proyecto_Final_Polo_Tecnologico_Incluit.Rules;


public class PublicacionRule
{
    private readonly IConfiguration _configuration;

    public PublicacionRule(IConfiguration configuration)
    {
        _configuration = configuration; 
    }

    public Publicacion GetPublicacionRandom()
    {
        //var connectionString = @"Server=DESKTOP-67VKNPT;Database=BlogDataBase;Trusted_Connection=True";
        var connectionString = _configuration.GetConnectionString("BlogDataBase");


        using var connection = new SqlConnection(connectionString);
        {
            connection.Open();
            var post = connection.Query<Publicacion>("select top 1 * from Publicacion order by newId()");

            return post.First();
        }

        
    }

    public Publicacion GetPostById(int id)
    {
        var connectionString = _configuration.GetConnectionString("BlogDataBase");


        using var connection = new SqlConnection(connectionString);
        {
            connection.Open();
            var post = connection.QueryFirstOrDefault<Publicacion>("select * from Publicacion where Id = @id", new { id});

            return post;
        }
    }

    public List<Publicacion> GetPostHome()
    {
        var connectionString = _configuration.GetConnectionString("BlogDataBase");


        using var connection = new SqlConnection(connectionString);
        {
            connection.Open();
            var posts = connection.Query<Publicacion>("select top 4 * from Publicacion order by Creacion desc");

            return posts.ToList();
        }


    }
}
