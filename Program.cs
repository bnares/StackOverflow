using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using StackOverflowCopy.Entities;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options => {

    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

builder.Services.AddDbContext<StackOverflowContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("StackConnectionString"))
    );




var app = builder.Build();


using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<StackOverflowContext>();

var pendingMIgrations = dbContext.Database.GetPendingMigrations();
if (pendingMIgrations.Any())
{
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("newQuestion", (StackOverflowContext db) => {

    var data = new Question() { Content = "To be or not to be that is the Question" };
    var question = db.Questions.Add(data);
    db.SaveChanges();
    
});


app.MapPost("addQuestionAnswear", (StackOverflowContext db) => {

    var questionId = 2; //dane od klienta
    var searchingQuestion = db.Questions.First(x=>x.Id == questionId);
    var answearContent = "This is the answear to question of id ="+questionId; //dane od klienta
    var answear = new Answear() { Content = answearContent, AnswearToQuestion=searchingQuestion, AnswearToQuestionId=searchingQuestion.Id};
    db.Answears.Add(answear);
    db.SaveChanges();
    return answear;
});



app.MapPost("PointToQuestionAnswear",(StackOverflowContext db) =>
{
    var answearId = 2; //dane od klienta
    var searchingAnswear = db.Answears.First(x => x.Id == answearId);
    var currentPoints = searchingAnswear.PointsRankOfAnswear;
    int newNumberOfPoints = currentPoints+1;
    searchingAnswear.PointsRankOfAnswear= newNumberOfPoints;
    db.SaveChanges();
    return searchingAnswear;
});


app.MapPost("SubtractPointToQuestionAnswear", (StackOverflowContext db) =>
{
    var answearId = 1; //dane od klienta
    var searchingAnswear = db.Answears.First(x => x.Id == answearId);
    var currentPoints = searchingAnswear.PointsRankOfAnswear;
    int newNumberOfPoints = 0;
    newNumberOfPoints= currentPoints > 0 ?  currentPoints - 1 :0;
    searchingAnswear.PointsRankOfAnswear = newNumberOfPoints;
    db.SaveChanges();
    return searchingAnswear;
});





app.MapPost("MarkAsBestAnswear", (StackOverflowContext db) => {

    var answearId = 1; //dane od klienta
    var searchingAnswear = db.Answears.First(x => x.Id == answearId);
    var scaningDataToFindOtherTrue = db.Answears.Where(x => x.BestAnswear).ToList();
    foreach (var answear in scaningDataToFindOtherTrue)
    {
        if (answear.BestAnswear == true)
        {
            answear.BestAnswear= false;
        }
    }
    searchingAnswear.BestAnswear = !searchingAnswear.BestAnswear;
    db.SaveChanges();
    return searchingAnswear;

});

app.MapPost("CommentQuestion", (StackOverflowContext db) => {

    var questionID = 2; //dane od klienta
    var question = db.Questions.First(x => x.Id == questionID);
    var commenst = "Comment question number of id =" + questionID; //dane od klienta
    var addCommentQuestion = new Comment() { Question = question, QuestionId = questionID, Content = commenst };
    db.Comments.Add(addCommentQuestion);
    db.SaveChanges();
});


app.MapPost("CommentAnswear", (StackOverflowContext db) => {

    var answearID = 1; //dane od klienta
    var answear = db.Answears.First(x => x.Id == answearID);
    var commenst = "Comment answear of id =" + answearID; //dane od klienta
    var addCommentAnswear = new CommentAnswear() { Answear = answear, AnswearId = answearID, Content = commenst };
    db.CommentAnswears.Add(addCommentAnswear);
    db.SaveChanges();
});

app.MapGet("GetQuestionWithAnswears", (StackOverflowContext db) => {

    var question = db.Questions.Include(x => x.Answears).Where(x => x.Answears.Any()).ToList(); //testowe filtrowanie
    return question;

});


app.Run();


