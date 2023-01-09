using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Login;

namespace Service.Login
{
    public interface ILoginService
    {
        Task<ApiResult<string>> Authencate(LoginModel request);

        Task<User> CheckActive(string name, bool showHidden = true);
    }
}