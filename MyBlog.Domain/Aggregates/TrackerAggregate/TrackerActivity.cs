using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Domain.Aggregates.TrackerAggregate;

public sealed class TrackerActivity : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private TrackerActivity() { }
    private TrackerActivity(Guid id, string name) : base(id)
    {
        Name = name;
        IsCompleted = false;
        CreatedAt = DateTime.UtcNow;
    }
    public static TrackerActivity Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Activity name cannot be null or empty.");

        return new TrackerActivity(Guid.NewGuid(),name);
    }
    public void Complete() => IsCompleted = true;
    public void Uncomplete() => IsCompleted = false;

}
