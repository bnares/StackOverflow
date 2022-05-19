namespace StackOverflowCopy.Entities
{
    public class Question : GenericStructure
    {
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
        public IEnumerable<Answear> Answears { get; set; } = new List<Answear>();

    }
}
