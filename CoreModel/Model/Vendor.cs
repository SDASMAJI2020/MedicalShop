using System;
using System.Collections.Generic;

namespace CoreModel.Model
{
    public partial class Vendor
    {
        public int Id { get; set; }
        public int Baseid { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int Age { get; set; }
        public string PerAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string PanCard { get; set; }
        public string AdhaarCard { get; set; }
        public string GstNo { get; set; }
        public string DlNo { get; set; }
        public string Station { get; set; }
        public string VehicalNo { get; set; }
        public string MedicalCenter { get; set; }
        public string GstnCn { get; set; }
    }
}
