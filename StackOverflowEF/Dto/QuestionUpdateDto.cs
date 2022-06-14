namespace StackOverflowEF.Dto
{
    public class QuestionUpdateDto
    {
        public QuestionDto? QuestionDto { get; set; }
        public List<TagDto>? Tags { get; set; }
    }
}
