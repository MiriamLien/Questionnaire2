namespace questionnaire.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommonQue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CQID { get; set; }

        [Required]
        [StringLength(200)]
        public string CQTitle { get; set; }

        public int QuesTypeID { get; set; }

        public string CQChoices { get; set; }

        public bool CQIsEnable { get; set; }

        public virtual QuesType QuesType { get; set; }
    }
}
