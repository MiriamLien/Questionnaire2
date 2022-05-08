using questionnaire.Helpers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Managers
{
    public class StatisticManager
    {
        public List<StatisticModel> GetStatisticList(Guid id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var idText = id.ToString();

                    //取得所有或加查詢條件的帳戶
                    var query =
                           from item in contextModel.UserQuesDetails
                           where item.ID == id
                           select new StatisticModel
                           {
                               ID = item.ID,
                               QuesID = item.QuesID,
                               Answer = item.Answer,
                           };

                    //組合，並取回結果
                    var list = query.ToList();

                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("StatisticManager.GetStatisticList", ex);
                throw;
            }
        }
    }
}