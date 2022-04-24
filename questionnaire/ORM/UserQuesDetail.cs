namespace questionnaire.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserQuesDetail
    {
        [Key]
        public int UserQuesID { get; set; }

        public Guid UserID { get; set; }

        public int QuesID { get; set; }

        public Guid ID { get; set; }

        [Required]
        [StringLength(200)]
        public string QuesTitle { get; set; }

        [Required]
        public string QuesChoices { get; set; }

        public int QuesTypeID { get; set; }

        public bool IsEnable { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
