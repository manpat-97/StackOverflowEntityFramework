namespace StackOverflowEF.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
