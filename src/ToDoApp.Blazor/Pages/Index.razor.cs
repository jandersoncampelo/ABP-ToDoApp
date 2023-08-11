using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Blazor.Pages;

public partial class Index
{
    [Inject]
    private IToDoAppService ToDoAppService { get; set; }

    private List<ToDoItemDto> ToDoItems { get; set; } = new List<ToDoItemDto>();
    private string NewToDoText { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ToDoItems = await ToDoAppService.GetListAsync();
    }

    private async Task Create()
    {
        var result = await ToDoAppService.CreateAsync(NewToDoText);
        ToDoItems.Add(result);

        NewToDoText = string.Empty;
    }

    private async Task Delete(ToDoItemDto todoItem)
    {
        await ToDoAppService.DeleteAsync(todoItem.Id);
        //await Notify.Info("Deleted the To-Do item successfully.");

        ToDoItems.Remove(todoItem);
    }
}
