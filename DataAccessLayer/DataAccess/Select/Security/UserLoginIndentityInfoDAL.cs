using EntityLayer;
using EntityLayer.AppDbContext;

namespace DataAccessLayer.DataAccess.Select.Security
{
    public class UserLoginIndentityInfoDAL
    {
        private readonly ApplicationDbContext _context;

        public UserLoginIndentityInfoDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee GetByUsername(string username)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(i => i.login_id.ToUpper() == username);
                if (employee == null)
                {
                    return null;
                }

                return employee;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {ex.Message}\n");
                throw new ApplicationException("An error occurred while retrieving the user by username.", ex);
            }
        }
    }
}