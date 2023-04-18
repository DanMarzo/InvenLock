using InvenLock.Dto;

namespace InvenLock.Repository.Interfaces;

public interface IFuncionarioRepository
{
    Task<bool> LogIn(LoginFuncionarioDto login);
}
