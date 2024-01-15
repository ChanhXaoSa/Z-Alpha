//using ZAlpha.Application.Common.Exceptions;
//using ZAlpha.Application.TodoItems.Commands.CreateTodoItem;
//using ZAlpha.Application.TodoItems.Commands.DeleteTodoItem;
//using ZAlpha.Application.TodoLists.Commands.CreateTodoList;
//using ZAlpha.Domain.Entities;
//using FluentAssertions;
//using NUnit.Framework;

//namespace ZAlpha.Application.IntegrationTests.TodoItems.Commands;

//using static Testing;

//public class DeleteTodoItemTests : BaseTestFixture
//{
//    [Test]
//    public async Task ShouldRequireValidTodoItemId()
//    {
//        var command = new DeleteTodoItemCommand(99);

//        await FluentActions.Invoking(() =>
//            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
//    }

//    [Test]
//    public async Task ShouldDeleteTodoItem()
//    {
//        var listId = await SendAsync(new CreateTodoListCommand
//        {
//            Title = "New List"
//        });

//        var itemId = await SendAsync(new CreateTodoItemCommand
//        {
//            ListId = listId,
//            Title = "New Item"
//        });

//        await SendAsync(new DeleteTodoItemCommand(itemId));

//        var item = await FindAsync<TodoItem>(itemId);

//        item.Should().BeNull();
//    }
//}
