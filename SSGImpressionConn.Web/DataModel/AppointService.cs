//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSGImpressionConn.Web.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppointService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppointService()
        {
            this.AppointmentDetails = new HashSet<AppointmentDetail>();
        }
    
        public int ID { get; set; }
        public Nullable<int> AppoinmentID { get; set; }
        public string ApointServiceIDs { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
        public virtual AppointmentDetail AppointmentDetail { get; set; }
    }
}
