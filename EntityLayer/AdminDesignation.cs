using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("admn_designation")]
    public class AdminDesignation
    {
        [Key]
        public int designation_id { get; set; }

        public string designation_name { get; set; }
        public string designation_short_name { get; set; }
        public bool is_deleted { get; set; }
        public DateTime date_insert { get; set; }
        public int department_id { get; set; }
        public int? organization_id { get; set; }

        [ForeignKey("organization_id")]
        public OrganizationRegistryInfo Organization { get; set; }

        [ForeignKey("department_id ")]
        public AdminDepartment Department { get; set; }
    }
}