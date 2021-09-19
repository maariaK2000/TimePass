namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("registerlocation")]
    public partial class registerlocation
    {
        [Key]
        public int LocationId { get; set; }

        public int RegisterId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserLocation { get; set; }

        public virtual myregister myregister { get; set; }
    }
}
