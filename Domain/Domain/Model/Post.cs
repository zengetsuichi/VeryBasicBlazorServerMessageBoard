namespace Domain.Domain.Model;

public class Post
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string PostText { get; set; }

    public Post(int ownerId, string title, string postText)
    {
        OwnerId = ownerId;
        Title = title;
        PostText = postText;

    }
    
    public Post()
    {

    }
}