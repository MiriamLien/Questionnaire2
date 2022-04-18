namespace questionnaire.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuesType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuesType()
        {
            CommonQues = new HashSet<CommonQue>();
            QuesDetails = new HashSet<QuesDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuesTypeID { get; set; }

        [Column("QuesType")]
        [Required]
        [StringLength(200)]
        public string QuesType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommonQue> CommonQues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuesDetail> QuesDetails { get; set; }
    }
}
