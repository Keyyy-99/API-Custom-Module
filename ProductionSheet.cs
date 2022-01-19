using System;

namespace AjiyaSAP_AAS_CM
{
    public class ProductionSheet
    {
        public int id { get; set; }
        public string product { get; set; }
        public string customer { get; set; }
        public string issuedBy { get; set; }
        public string production_No { get; set; }
        public DateTime date_of_Issue { get; set; }
        public string attention { get; set; }
        public string pO_No { get; set; }
        public int confirmation { get; set; }
        public string confirmationBy { get; set; }
        public DateTime? confirmationDate { get; set; }
        public string checked_By { get; set; }
        public string color { get; set; }
        public float thickness { get; set; }
        public float width { get; set; }
        public float weight { get; set; }
        public float length { get; set; }
        public int total_sf_in_order { get; set; }
        public string grade { get; set; }
        public float quantity { get; set; }
        public int psid { get; set; }
        public DateTime createDate { get; set; }
        public string project { get; set; }
        public string deliveryAddress { get; set; }
        public string customerContact { get; set; }
        public string customerContactPerson { get; set; }
        public string productName { get; set; }
        public string productFamily { get; set; }
        public string additionalDescription { get; set; }
        public float extraLength { get; set; }
        public float totalSOM { get; set; }
        public bool postCheck { get; set; }
        public DateTime updateTime { get; set; }
    }
}