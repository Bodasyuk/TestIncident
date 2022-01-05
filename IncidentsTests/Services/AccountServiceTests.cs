using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Incidents.DataAccess.Entities;
using Incidents.DataAccess.Repositories.Interfaces;
using Incidents.Services.Realization;
using Moq;
using NUnit.Framework;

namespace IncidentsTests.Services;


public class AccountServiceTests
{
    private Mock<IRepositoryWrapper> _wrapper;
    private AccountService _service;

    [SetUp]
    public void Setup()
    {
        _wrapper = new Mock<IRepositoryWrapper>();
        _service = new AccountService(_wrapper.Object);
    }

    [Test]
    public async Task CreateAsync_GetAccountAndMail()
    {
        _wrapper.Setup(x => x.Contact.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Contacts, bool>>>(), null))
            .ReturnsAsync(new Contacts() {AccountsId = 1});
        _wrapper.Setup(x => x.Account.CreateAsync(It.IsAny<Accounts>()));
        _wrapper.Setup(x => x.SaveAsync());
        _wrapper.Setup(x => x.Contact.Update(It.IsAny<Contacts>()));

        var result = _service.CreateAsync(It.IsAny<Accounts>(), It.IsAny<string>());
        
        Assert.NotNull(result);
        Assert.IsInstanceOf<Task>(result);
    }
}