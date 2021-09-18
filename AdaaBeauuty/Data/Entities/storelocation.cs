namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("storelocation")]
    public partial class storelocation
    {
        [Key]
        public int LocId { get; set; }

        public int PrdId { get; set; }

        [Column("StoreLocation")]
        [Required]
        [StringLength(50)]
        public string StoreLocation1 { get; set; }

        public virtual product product { get; set; }
    }
}
