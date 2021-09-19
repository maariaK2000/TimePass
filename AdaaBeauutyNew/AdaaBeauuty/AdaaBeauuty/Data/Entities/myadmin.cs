namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("myadmin")]
    public partial class myadmin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPwd { get; set; }
    }
}
