namespace StackOverflowEF.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Point> Points { get; set; }
    }
}
