﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Models
{
    public class CQAndTypeModel
    {
        public int CQID { get; set; }

        public string CQTitle { get; set; }

        public string CQChoices { get; set; }

        public int QuesTypeID { get; set; } //問題種類ID

        public string QuesType1 { get; set; } //問題種類名稱(文字、單選/複選方塊)

        public bool CQIsEnable { get; set; }
    }
}