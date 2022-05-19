using Microsoft.EntityFrameworkCore;

namespace StackOverflowCopy.Entities
{
    public class StackOverflowContext : DbContext
    {
        public StackOverflowContext(DbContextOptions<StackOverflowContext> options)
            :base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Answear> Answears { get; set; }
        public DbSet<CommentAnswear> CommentAnswears { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Question>(x =>
            {
                x.HasMany(y => y.Comments).WithOne(z => z.Question).HasForeignKey(z => z.QuestionId);
                x.HasMany(y => y.Tags).WithMany(z => z.Tags);
                x.HasMany(y=>y.Answears).WithOne(z=>z.AnswearToQuestion).HasForeignKey(z => z.AnswearToQuestionId);
                x.Property(x => x.Content).HasMaxLength(500);
            });


            modelBuilder.Entity<Comment>(x =>
            {
                x.HasOne(y => y.Question).WithMany(z => z.Comments).HasForeignKey(z => z.QuestionId);

                x.Property(x => x.Content).HasMaxLength(500);
            });


            modelBuilder.Entity<Answear>(x=>{
                x.Property(x=>x.Content).HasMaxLength(500);
                //x.Property(x=>x.AnswearToQuestion).IsRequired();  DO NOT USE THE ENTITY AS A PROPERTY It Causes an ERROR 
               // x.Property(x=>x.AnswearToQuestionId).IsRequired();
                x.Property(x=>x.Content).IsRequired();
                x.HasMany(x => x.CommentAnswears).WithOne(x => x.Answear).HasForeignKey(x => x.AnswearId);
            });

            modelBuilder.Entity<Tag>(x => {
                x.Property(y => y.Content).HasMaxLength(100);
            });

            modelBuilder.Entity<CommentAnswear>();
        }
    }
}
