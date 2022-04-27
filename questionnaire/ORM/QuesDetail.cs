namespace questionnaire.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuesDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuesDetail()
        {
            UserQuesDetails = new HashSet<UserQuesDetail>();
        }

        [Key]
        public int QuesID { get; set; }

        public Guid ID { get; set; }

        [Required]
        [StringLength(200)]
        public string QuesTitle { get; set; }

        public string QuesChoices { get; set; }

        public int QuesTypeID { get; set; }

        public bool IsEnable { get; set; }

        public int? Count { get; set; }

        public virtual Content Content { get; set; }

        public virtual QuesType QuesType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserQuesDetail> UserQuesDetails { get; set; }
    }
}
