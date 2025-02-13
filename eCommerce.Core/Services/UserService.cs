using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;
internal class UserService : IUserService
{
    private readonly IusersRepository _UserRepo;

    public UserService(IusersRepository userRepo)
    {
        _UserRepo = userRepo;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequestDTO loginRequest)
    {
        ApplicationUser? User = await _UserRepo.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (User == null)
        {
            return null;
        }

        return new AuthenticationResponse(User.UserID, User.Email, User.PersonName, User.Gender, "token", success: true);

    }

    public async Task<AuthenticationResponse?> Register(RegistorRequestDTO registor)
    {
        ApplicationUser User = new ApplicationUser()
        {
            Email = registor.Email,
            Password = registor.Password,
            PersonName = registor.PersonName,
            Gender = registor.Gender.ToString()
        };
        ApplicationUser? RegistorUser = await _UserRepo.AddUser(User);

        if (RegistorUser == null)
        {
            return null;
        }

        return new AuthenticationResponse(
                UserID: RegistorUser.UserID,
                Email: RegistorUser.Email,
                PersonName: RegistorUser.PersonName,
                Gender: RegistorUser.Gender,
                Token: "Token",
                success: true
        );

    }
}

