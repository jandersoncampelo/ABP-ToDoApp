using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ToDoApp.Services
{
    public class ToDoAppService : ApplicationService, IToDoAppService
    {
        private readonly IRepository<ToDoItem, Guid> _repository;

        public ToDoAppService(IRepository<ToDoItem, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItemDto> CreateAsync(string text)
        {
            var toDoItem = await _repository.InsertAsync(
                new ToDoItem
                {
                    Text = text
                },
                autoSave: true
            );

            return new ToDoItemDto
            {
                Id = toDoItem.Id,
                Text = toDoItem.Text
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ToDoItemDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            return items.Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Text = item.Text
            }).ToList();
        }
    }
}
