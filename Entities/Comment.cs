namespace StackOverflowCopy.Entities
{
    public class Comment : GenericStructure
    {

        public Question Question { get; set; }
        public int QuestionId { get; set; }


    }
}
