using System;

namespace AjiyaSAP_AAS_CM
{
    public class IRM
    {
        public int id { get; set; }
        public int coilID { get; set; }
        public string coilNo { get; set; }
        public string supplierID { get; set; }
        public string color { get; set; }
        public float thickness { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public string grade { get; set; }
        public string branch { get; set; }
        public float qty { get; set; }
        public float balance { get; set; }
        public string itemDescription { get; set; }
        public string ncR_Remark { get; set; }
        public string reservation_by_who { get; set; }
        public DateTime date_Reservation { get; set; }
        public int confirmation { get; set; }
        public string confirmationBy { get; set; }
        public DateTime? confirmationDate { get; set; }
        public DateTime createDate { get; set; }
        public DateTime doDate { get; set; }
        public string doNo { get; set; }
        public string motherCoilNo { get; set; }
        public string itemName { get; set; }
        public bool postCheck { get; set; }
        public DateTime? updateTime { get; set; }
        public bool frontendReturn { get; set; }
        public DateTime? frontendReturnDate { get; set; }
    }
}