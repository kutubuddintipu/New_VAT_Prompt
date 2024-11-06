using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("admn_department")]
    public class AdminDepartment
    {
        [Key]
        public int department_id { get; set; }

        public string department_name { get; set; }
        public string department_short_name { get; set; }
        public bool is_deleted { get; set; }
        public DateTime date_insert { get; set; }
        public int? organization_id { get; set; }

        [ForeignKey("organization_id")]
        public OrganizationRegistryInfo Organization { get; set; }
    }
}