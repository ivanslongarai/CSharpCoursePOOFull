using System.Text;

namespace CompositionExec2.Entities;

public class Post
{
    private IList<Comment> _comments = new List<Comment>();

    public Post(string title, string content)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        Moment = DateTime.UtcNow;
        Likes = 0;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime Moment { get; private set; }
    public int Likes { get; private set; }
    public IReadOnlyCollection<Comment> Comments => _comments.ToArray();

    public void AddLike()
    {
        Likes++;
    }

    public void RemoveLike()
    {
        if (Likes > 0)
            Likes--;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        if (_comments.Where(x => x.Id == comment.Id).FirstOrDefault() != null)
            _comments.Remove(comment);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("------------------------------------------------------");
        sb.AppendLine(Title);
        sb.AppendLine($"{Likes} Likes - {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
        sb.AppendLine(Content);
        sb.AppendLine("Comments:");
        foreach (var comment in Comments)
            sb.AppendLine(comment.Text);
        sb.AppendLine("------------------------------------------------------");
        return sb.ToString();
    }

}