using MongoDB.Driver;
using ToDoApp.Entities;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ToDoApp.MongoDB;

[ConnectionStringName("Default")]
public class ToDoAppMongoDbContext : AbpMongoDbContext
{
    public IMongoCollection<ToDoItem> ToDoItems => Collection<ToDoItem>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.Entity<ToDoItem>(b =>
        {
            b.CollectionName = "ToDoItems";
        });
    }
}
