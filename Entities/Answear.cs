namespace StackOverflowCopy.Entities
{
    public class Answear : GenericStructure
    {
        public Question AnswearToQuestion { get; set; }
        public int AnswearToQuestionId { get; set; }
        public int PointsRankOfAnswear { get; set; } = 0;
        public bool BestAnswear { get; set; } = false;
        //public IEnumerable<Comment> CommentsAnswear { get; set; } = new List<Comment>();
        public IEnumerable<CommentAnswear> CommentAnswears { get; set; }

    }
}
