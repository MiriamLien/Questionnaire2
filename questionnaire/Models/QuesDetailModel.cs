﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Models
{
    public class QuesDetailModel
    {
        public int QuesID { get; set; }

        public Guid ID { get; set; }

        public string QuesTitle { get; set; }

        public string QuesChoices { get; set; }   // (答案)選項

        public int QuesTypeID { get; set; }

        public bool IsEnable { get; set; }
    }
}