using System;
namespace CompositionExec2.Entities;

public class Comment : IEquatable<Comment>
{
    public Comment(string text)
    {
        Id = Guid.NewGuid();
        Text = text;
    }

    public Guid Id { get; private set; }
    public string Text { get; private set; }

    public bool Equals(Comment? other)
    {
        return Id == other?.Id;
    }

}