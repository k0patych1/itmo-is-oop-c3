namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminPasswordRepository
{
    ValueTask<string?> GetAdminPassword();
}