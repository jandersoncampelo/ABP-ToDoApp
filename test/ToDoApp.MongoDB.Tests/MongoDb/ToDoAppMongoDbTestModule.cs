using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ToDoApp.MongoDB;

[DependsOn(
    typeof(ToDoAppTestBaseModule),
    typeof(ToDoAppMongoDbModule)
    )]
public class ToDoAppMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = ToDoAppMongoDbFixture.GetRandomConnectionString();
        });
    }
}
