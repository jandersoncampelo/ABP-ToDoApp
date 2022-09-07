using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ToDoApp.Pages;

public class Index_Tests : ToDoAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
