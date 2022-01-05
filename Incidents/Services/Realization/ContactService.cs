using Incidents.DataAccess.Entities;
using Incidents.DataAccess.Repositories.Interfaces;
using Incidents.Services.Interfaces;

namespace Incidents.Services.Realization;

public class ContactService : IContactService
{
    private readonly IRepositoryWrapper _wrapper;

    public ContactService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
    public async Task CreateAsync(Contacts contacts)
    {
        await _wrapper.Contact.CreateAsync(contacts);
        await _wrapper.SaveAsync();
    }

    public void Create(Contacts entity)
    {
        _wrapper.Contact.Create(entity);
        _wrapper.Save();
    }

    public async Task Update(Contacts entity)
    {
        var contact = entity;
        contact.ContactId = _wrapper.Contact.GetFirstAsync(x => x.Email == entity.Email).Result.ContactId;
        _wrapper.Contact.Update(entity);
        await _wrapper.SaveAsync();
    }

    public async Task Delete(string mail)
    {
        var entity = await _wrapper.Contact.GetFirstAsync(x => x.Email == mail);
        _wrapper.Contact.Delete(entity);
        await _wrapper.SaveAsync();
    }

    public async Task<bool> CheckMail(string mail)
    {
        if (await _wrapper.Contact.GetFirstOrDefaultAsync(x => x.Email == mail) != null)
            return true;
        return false;
    }

    public async Task LinkContact(string mail, string nameAccount)
    {
        var contact = await _wrapper.Contact.GetFirstAsync(x => x.Email == mail);
        var account = await _wrapper.Account.GetFirstAsync(x => x.Name == nameAccount);
        contact.AccountsId = account.AccountId;
        Update(contact);
    }
    public async Task<bool> CheckIfNameIsExit(string nameAccount)
    {
        var account = await _wrapper.Account.GetFirstOrDefaultAsync(x => x.Name == nameAccount);
        if (account == null)
            return false;
        return true;
    }

    public async Task<Contacts> GetFirstAsync(string mail)
    {
        return await _wrapper.Contact.GetFirstAsync(x => x.Email == mail);
    }
    public async Task<IEnumerable<Contacts>> GetAllAsync()
    {
        return await _wrapper.Contact.GetAllAsync();
    }
}