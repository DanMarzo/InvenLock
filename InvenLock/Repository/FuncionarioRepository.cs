using InvenLock.Data;
using InvenLock.Dto;
using InvenLock.Models;
using InvenLock.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Repository;

public class FuncionarioRepository : IFuncionarioRepository
{
	private readonly DataContext _context;
	public FuncionarioRepository(DataContext context)
	{
		_context = context;
	}
    public async Task<bool> LogIn(LoginFuncionarioDto login)
    {
		try
		{
			Funcionario f = await _context
				.Funcionarios
				.Include(c => c.ContatoFuncionario)
				.FirstOrDefaultAsync(s => s.ContatoFuncionario.Email.ToUpper() == login.Email.ToUpper());

			if (!CR)
			{

			}
		}
		catch (Exception ex)
		{
			throw ex.InnerException;
		}
    }
}
