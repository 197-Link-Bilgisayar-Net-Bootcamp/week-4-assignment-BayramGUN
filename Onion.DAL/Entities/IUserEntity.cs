namespace Onion.DAL.Entities;

public interface IUserEntity
{
    string Name { get; set; }
    string SurName { get; set; }
    string UserName { get; set; }
    string Email { get; set; } 
    string Password { get; set; }  
}