﻿//using ZAlpha.Application.Common.Behaviours;
//using ZAlpha.Application.Common.Interfaces;
//using ZAlpha.Application.TodoItems.Commands.CreateTodoItem;
//using Microsoft.Extensions.Logging;
//using Moq;
//using NUnit.Framework;

//namespace ZAlpha.Application.UnitTests.Common.Behaviours;

//public class RequestLoggerTests
//{
   
//    private Mock<ICurrentUserService> _currentUserService = null!;
//    private Mock<IIdentityService> _identityService = null!;

//    [SetUp]
//    public void Setup()
//    {
//        _currentUserService = new Mock<ICurrentUserService>();
//        _identityService = new Mock<IIdentityService>();
//    }

//    [Test]
//    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
//    {
//        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());


//        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
//    }

//    [Test]
//    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
//    {
       

//        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
//    }
//}
