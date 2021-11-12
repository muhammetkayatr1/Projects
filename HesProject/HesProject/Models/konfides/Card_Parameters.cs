namespace HesProject.Models
{
    using System;

    public  class Card_Parameters
    {
        public decimal Card_Id { get; set; }
        public decimal daily_limit { get; set; }
        public string pin { get; set; }
        public DateTime insertion_date { get; set; }
        public string status { get; set; }
        public DateTime operation_date { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public byte id_document_type { get; set; }
        public byte CardMealTypefoID { get; set; }
        public byte application_code { get; set; }
        public byte daily_max_transaction_count { get; set; }
        public bool black_list_flag { get; set; }
        public bool PIN_flag { get; set; }
        public bool allow_purse_for_meal_purchase { get; set; }
        public bool allow_purse_for_general_usage { get; set; }
        public string school_no { get; set; }
        public string employee_id { get; set; }
        public string token_params { get; set; }
        public string id_document_no { get; set; }
    }
}
