using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("org_registration_info")]
    public class OrganizationRegistryInfo
    {
        [Key]
        public int organization_id { get; set; }

        public string organization_name { get; set; }
        public string abbr_name { get; set; }
        public bool registration_type { get; set; }
        public int? parent_org_id { get; set; }

        public int org_type_id_m { get; set; }
        public int org_type_id_d { get; set; }
        public string business_address { get; set; }
        public string ba_phone { get; set; }
        public string ba_email { get; set; }
        public string ba_fax { get; set; }
        public string factory_address { get; set; }
        public string fa_phone { get; set; }
        public string fa_email { get; set; }
        public string fa_fax { get; set; }
        public string head_office_address { get; set; }
        public string ho_phone { get; set; }
        public string ho_email { get; set; }
        public string ho_fax { get; set; }
        public string tin_company { get; set; }
        public string previous_registration_no { get; set; }
        public bool tc_is_vat { get; set; }
        public bool tc_is_cottage_industry { get; set; }
        public bool tc_is_other { get; set; }
        public bool tc_is_supplier_manufacturer { get; set; }
        public bool tc_is_supplier_trader { get; set; }
        public bool tc_is_service_renderer { get; set; }
        public bool tc_is_importer { get; set; }
        public bool tc_is_exporter { get; set; }
        public string tc_trade_license_no { get; set; }
        public string tc_authority { get; set; }
        public DateTime tc_fiscal_year_from { get; set; }
        public DateTime tc_fiscal_year_to { get; set; }
        public string tc_import_reg_no { get; set; }
        public string tc_export_reg_no { get; set; }
        public bool is_deleted { get; set; }
        public string owner_permanent_address { get; set; }
        public string ow_phone { get; set; }
        public string ow_email { get; set; }
        public string ow_fax { get; set; }
        public bool tc_is_trnovr_tax_yrly { get; set; }
        public bool tc_is_trnovr_tax_qrtrly { get; set; }
        public bool tc_is_trnovr_tax_mnthly { get; set; }
        public DateTime? reg_effictive_date { get; set; }
        public Int64 circle_id { get; set; }
        public string tin_chairman { get; set; }
        public string national_id_of_chairman { get; set; }
        public string registration_no { get; set; }
        public string business_activity { get; set; }
        public string register_persoon_name { get; set; }
        public int? registration_type_n { get; set; }
        public Double? amount { get; set; }
        public string amount_in_word { get; set; }
        public DateTime? registration_date { get; set; }
        public string business_type { get; set; }
        public string business_type_name { get; set; }
        public string vat_deducted_at_source { get; set; }
        public string vat_deducted_at_source_name { get; set; }
        public string other_tax_collection { get; set; }
        public string other_tax_collection_name { get; set; }
        public string application_nature { get; set; }
        public string application_nature_name { get; set; }
        public string business_process_activity { get; set; }
        public string business_process_activity_name { get; set; }
        public string economic_process_activity { get; set; }
        public string economic_process_activity_name { get; set; }
        public bool is_vat_deduct { get; set; }
        public int? commissionarate_id { get; set; }
        public bool is_withholding_entity { get; set; }
        public string trade_license_no { get; set; }
        public DateTime? trade_license_issue_date { get; set; }
        public string rjsc_incorporation_num { get; set; }
        public DateTime? rjsc_incorporation_issue_date { get; set; }
        public string company_name_diff_etin { get; set; }
        public string vat_turnover { get; set; }
        public string trading_brand { get; set; }
        public string bida_reg_num { get; set; }
        public DateTime? bida_reg_issue_date { get; set; }
        public string manufacturing_name { get; set; }
        public string service_name { get; set; }
        public string e_tin { get; set; }
        public bool is_manufacturing { get; set; }
        public bool is_service { get; set; }
        public bool is_imports { get; set; }
        public bool is_exports { get; set; }
        public bool is_other { get; set; }
        public string other_specification { get; set; }
        public DateTime? irc_issue_date { get; set; }
        public DateTime? erc_issue_date { get; set; }
        public string irc_no { get; set; }
        public string erc_no { get; set; }
        public int? reg_person_desig_id { get; set; }
        public int no_of_user { get; set; }
    }
}