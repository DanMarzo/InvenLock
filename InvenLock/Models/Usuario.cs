namespace InvenLock.Models;

public class Usuario
{
    public int UsuarioId { get; set; }
    public string UserName { get; set; }
    [NotMapped]
    public string PasswordString { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
}
