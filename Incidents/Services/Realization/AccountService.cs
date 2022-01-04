using Incidents.DataAccess.Entities;
using Incidents.DataAccess.Repositories.Interfaces;
using Incidents.Services.Interfaces;

namespace Incidents.Services.Realization;

public class AccountService:IAccountService
{
    private IRepositoryWrapper _wrapper;

    public AccountService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
    public async Task CreateAsync(Accounts accounts, string mail)
    {
        var contact = await _wrapper.Contact.GetFirstOrDefaultAsync(x => x.Email == mail);
        if (contact.AccountsId != null)
            throw new Exception();
        contact.AccountsId = accounts.AccountId;
        accounts.Contacts = new List<Contacts>() { contact };
        await _wrapper.Account.CreateAsync(accounts);
        _wrapper.Contact.Update(contact);
        await _wrapper.SaveAsync();
    }
    
    public void Create(Accounts entity)
    {
        _wrapper.Account.Create(entity);
        _wrapper.Save();
    }

    public async Task Update(Accounts entity)
    {
        var account = entity;
        account.AccountId = _wrapper.Account.GetFirstAsync(x => x.Name == entity.Name).Result.AccountId;
        _wrapper.Account.Update(entity);
        await _wrapper.SaveAsync();
    }

    public async Task Delete(string name)
    {
        var entity = await _wrapper.Account.GetFirstAsync(x => x.Name == name);
        _wrapper.Account.Delete(entity);
        await _wrapper.SaveAsync();
    }

    public async Task<Accounts> GetFirstAsync(string name)
    {
        return await _wrapper.Account.GetFirstAsync(x => x.Name == name);
    }
    
    public async Task<IEnumerable<Accounts>> GetAllAsync()
    {
        return await _wrapper.Account.GetAllAsync();
    }
}