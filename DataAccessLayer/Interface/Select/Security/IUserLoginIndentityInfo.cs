using DataModelLayer;
using EntityLayer;

namespace DataAccessLayer.Interface.Select.Security
{
    public interface IUserLoginIndentityInfo
    {
        Employee GetUserByCredentials(UserLoginInfo loginInfo);
    }
}