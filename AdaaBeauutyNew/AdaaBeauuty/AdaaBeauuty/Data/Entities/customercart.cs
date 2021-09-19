namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customercart")]
    public partial class customercart
    {
        [Key]
        public int CartId { get; set; }

        public int RegisterId { get; set; }

        public int PrdId { get; set; }

        public int PrdQuantity { get; set; }

        public virtual product product { get; set; }

        public virtual myregister myregister { get; set; }
    }
}
