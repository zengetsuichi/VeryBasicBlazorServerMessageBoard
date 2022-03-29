using System.Reflection.Emit;
using Domain.Domain.Interface;
using Domain.Domain.Model;
using FileData.FileData.DataAccess;

namespace FileData.FileData.DAO;

public class PostDAO : IPostHome
{

    private FileContext fileContext;

    public PostDAO(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }
    
    public async Task<ICollection<Post>> GetAsync()
    {
        ICollection<Post> posts = fileContext.Posts;
        return posts;
    }

    public async Task<Post> GetById(int id)
    {
        return fileContext.Posts.First(t => t.Id == id);
    }

    public async Task<Post> AddAsync(Post post)
    {
        int largestId = fileContext.Posts.Max(t => t.Id);
        int nextId = largestId + 1;
        post.Id = nextId;
        fileContext.Posts.Add(post);
        fileContext.SaveChanges();
        return post;
    }

    public async Task DeleteAsync(int id)
    {
        Post toDelete = fileContext.Posts.First(t => t.Id == id);
        fileContext.Posts.Remove(toDelete);
        fileContext.SaveChanges();
    }

    public async Task UpdateAsync(Post post)
    {
        Post toUpdate = fileContext.Posts.First(t => t.Id == post.Id);
        toUpdate.OwnerId = post.OwnerId;
        fileContext.SaveChanges();
    }
}