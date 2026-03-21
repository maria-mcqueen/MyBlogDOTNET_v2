

namespace MyBlog.Domain.Aggregates.JournalAggregate;

public sealed class JournalEntry : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

    private JournalEntry() { }

    private JournalEntry(Guid id, string title, string content) : base(id)
    {
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public static JournalEntry Create(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title)) 
            throw new ArgumentNullException("Title cannot be empty");
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentNullException("Content cannot be empty");

        return new JournalEntry(Guid.NewGuid(), title, content);
    }

    public void Update(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("title cannot be empty");

        Title = title;
        Content= content;
    }
}
