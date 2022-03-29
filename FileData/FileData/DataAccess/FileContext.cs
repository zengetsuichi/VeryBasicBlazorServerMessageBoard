using System.Text.Json;
using Domain.Domain.Model;

namespace FileData.FileData.DataAccess;

public class FileContext
{
    
    private string postFilePath = "posts.json";

    private ICollection<Post>? posts;

    public ICollection<Post> Posts
    {
        get
        {
            if (posts == null)
            {
                LoadData();
            }

            return posts!;
        }
    }

    public FileContext()
    {
        if (!File.Exists(postFilePath))
        {
            Seed();
        }
    }

    private void Seed()
    {
        Post[] ps =
        {
            new Post(1, "Dishes","Dont forget about Dishes")
            {
                Id = 1,
            },
            new Post(1, "Walk the dog", "Everytime I walk my dog, he try to run away from me")
            {
                Id = 1,
            },
            new Post(2, "Don't try to this", "Don't try to be like me and eat 1000 apple seeds. Bad Idea :(")
            {
                Id = 3,
            }
        };
        posts = ps.ToList();
        SaveChanges();
    }

    public void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Posts);
        File.WriteAllText(postFilePath, serialize);
        posts = null;
    }

    private void LoadData()
    {
        string content = File.ReadAllText(postFilePath);
        posts = JsonSerializer.Deserialize<List<Post>>(content);
    }
}