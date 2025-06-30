using Calculator;
using Calculator.Node;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/calculate", ([FromBody] string expression) =>
{
    var tokens = Tokenizer.Default.Tokenize(expression);

    var rootNode = NodeFactory.CreateNode(tokens);

    return rootNode.Calculate();
})
.WithName("CalculateExpression");

app.Run();