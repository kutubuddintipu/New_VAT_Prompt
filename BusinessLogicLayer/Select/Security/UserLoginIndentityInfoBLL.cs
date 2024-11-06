using DataAccessLayer.DataAccess.Select.Security;
using DataModelLayer;
using EntityLayer.AppDbContext;

namespace BusinessLogicLayer.Select.Security
{
    public class UserLoginIndentityInfoBLL
    {
        private UserLoginIndentityInfoDAL _userIdentityInfo;

        public UserLoginIndentityInfoBLL(ApplicationDbContext context)
        {
            _userIdentityInfo = new UserLoginIndentityInfoDAL(context);
        }

        public LoginRequest TryToLogin(LoginRequest login)
        {
            try
            {
                var trimmedUserName = login.UserName.Trim().ToUpper();
                var emp = _userIdentityInfo.GetByUsername(trimmedUserName);
                if (emp != null && BCrypt.Net.BCrypt.Verify(login.Password.Trim(), emp.api_password))
                {
                    return new LoginRequest()
                    {
                        UserName = emp.login_id,
                        Password = ""
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {ex.Message}\n");
                throw new ApplicationException("An error occurred during the login process.", ex);
            }
        }
    }
}