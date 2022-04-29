using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Models
{
    public class UserInfoAndQuesModel
    {
        public Guid UserID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Age { get; set; }

        public string Email { get; set; }

        public Guid ID { get; set; }

        public int QuesID { get; set; }

        public string QuesTitle { get; set; }

        public string QuesChoices { get; set; }   // (答案)選項

        public int QuesTypeID { get; set; }

    }
}