using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("org_branch_reg_info")]
    public class OrganizationBranchRegistryInfo
    {
        [Key]
        public int org_branch_reg_id { get; set; }

        public int organization_id { get; set; }
        public string central_bin { get; set; }
        public string branch_unit_bin { get; set; }
        public string branch_unit_name { get; set; }
        public Double? amount { get; set; }
        public DateTime? date_of_registration { get; set; }
        public bool is_deleted { get; set; }
        public string amount_in_word { get; set; }
        public string old_bin { get; set; }
        public string org_branch_address { get; set; }
        public string org_branch_category { get; set; }
        public Double? annual_turnover { get; set; }

        [ForeignKey("organization_id")]
        public OrganizationRegistryInfo Organization { get; set; }
    }
}