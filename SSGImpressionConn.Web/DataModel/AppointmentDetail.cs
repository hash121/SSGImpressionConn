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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AppointmentDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppointmentDetail()
        {
            this.AppointServices = new HashSet<AppointService>();
        }
    
        public int ID { get; set; }
        public string AppointmentID { get; set; }
        public string Name { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public int Phone { get; set; }
        public Nullable<int> BarberDetailID { get; set; }
        public Nullable<int> ShopDetailID { get; set; }
        public Nullable<int> ServiceDetailID { get; set; }
        public string Description { get; set; }
        public string EmailID { get; set; }
        public Nullable<System.TimeSpan> AppointmentTime { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> TimeSlotID { get; set; }
        public Nullable<bool> SlotStatus { get; set; }
        public Nullable<int> AppointTime { get; set; }
        public Nullable<int> AppointServiceID { get; set; }

        [NotMapped]
        public string[] selectedArrayID { get; set; }
        [NotMapped]
        public IEnumerable<ServiceDetail> serviceDetails { get; set; }
        public virtual BarberDetail BarberDetail { get; set; }
        public virtual ServiceDetail ServiceDetail { get; set; }
        public virtual ShopDetail ShopDetail { get; set; }
        public virtual Status Status { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual AppointService AppointService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointService> AppointServices { get; set; }
    }
}
