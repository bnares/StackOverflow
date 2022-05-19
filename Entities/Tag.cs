namespace StackOverflowCopy.Entities
{
    public class Tag : GenericStructure
    {

        public IEnumerable<Question> Tags { get; set; } = new List<Question>();
        


    }
}
