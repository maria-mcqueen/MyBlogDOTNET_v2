namespace MyBlog.Domain.Aggregates.HabitAggregate;

    public sealed class HabitLog : BaseEntity, IAggregateRoot
    {
        public string HabitType { get; private set; } = string.Empty;
        public DateOnly Date { get; private set; }
        public bool IsCompleted { get; private set; }
        private HabitLog() { }
        private HabitLog(Guid id, string habitType, DateOnly date) : base(id)
        {
            HabitType = habitType;
            Date = date;
            IsCompleted = true;
        }

        public static HabitLog Create(string habitType, DateOnly date)
        {
            if (string.IsNullOrWhiteSpace(habitType))
                throw new ArgumentException("Habit type cannot be empty.");

            return new HabitLog(Guid.NewGuid(), habitType, date);
        }
        public void Undo() => IsCompleted = false;
    }
