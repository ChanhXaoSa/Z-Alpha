//using ZAlpha.Application.Common.Exceptions;
//using ZAlpha.Application.Common.Security;
//using ZAlpha.Application.TodoLists.Commands.CreateTodoList;
//using ZAlpha.Application.TodoLists.Commands.PurgeTodoLists;
//using ZAlpha.Domain.Entities;
//using FluentAssertions;
//using NUnit.Framework;

//namespace ZAlpha.Application.IntegrationTests.TodoLists.Commands;

//using static Testing;

//public class PurgeTodoListsTests : BaseTestFixture
//{
//    [Test]
//    public async Task ShouldDenyAnonymousUser()
//    {
//        var command = new PurgeTodoListsCommand();

//        command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

//        var action = () => SendAsync(command);

//        await action.Should().ThrowAsync<UnauthorizedAccessException>();
//    }

//    [Test]
//    public async Task ShouldDenyNonAdministrator()
//    {
//        await RunAsDefaultUserAsync();

//        var command = new PurgeTodoListsCommand();

//        var action = () => SendAsync(command);

//        await action.Should().ThrowAsync<ForbiddenAccessException>();
//    }

//    [Test]
//    public async Task ShouldAllowAdministrator()
//    {
//        await RunAsAdministratorAsync();

//        var command = new PurgeTodoListsCommand();

//        var action = () => SendAsync(command);

//        await action.Should().NotThrowAsync<ForbiddenAccessException>();
//    }

//    [Test]
//    public async Task ShouldDeleteAllLists()
//    {
//        await RunAsAdministratorAsync();

//        await SendAsync(new CreateTodoListCommand
//        {
//            Title = "New List #1"
//        });

//        await SendAsync(new CreateTodoListCommand
//        {
//            Title = "New List #2"
//        });

//        await SendAsync(new CreateTodoListCommand
//        {
//            Title = "New List #3"
//        });

//        await SendAsync(new PurgeTodoListsCommand());

//        var count = await CountAsync<TodoList>();

//        count.Should().Be(0);
//    }
//}
