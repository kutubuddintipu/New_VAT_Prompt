using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("admn_employee")]
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }

        public string employee_name { get; set; }
        public bool is_system_user { get; set; }
        public string login_id { get; set; }
        public string login_password { get; set; }
        public int? organization_id { get; set; }
        public int department_id { get; set; }
        public int designation_id { get; set; }
        public int? user_level { get; set; } //  -- Super Admin = 1...
        public int emplyee_status { get; set; }
        public DateTime date_join { get; set; }
        public DateTime? date_retirement { get; set; }
        public DateTime date_insert { get; set; }
        public DateTime? date_update { get; set; }
        public bool is_deleted { get; set; }
        public string mobile_no { get; set; }
        public string email { get; set; }
        public int? org_branch_reg_id { get; set; }
        public string user_status { get; set; }
        public string api_password { get; set; }

        [ForeignKey("organization_id")]
        public OrganizationRegistryInfo Organization { get; set; }

        [ForeignKey("org_branch_reg_id")]
        public OrganizationBranchRegistryInfo OrganizationBranch { get; set; }

        [ForeignKey("department_id ")]
        public AdminDepartment Department { get; set; }

        [ForeignKey("designation_id ")]
        public AdminDesignation Designation { get; set; }
    }
}