using questionnaire.Helpers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Managers
{
    public class AccountCheckManager
    {
        /// <summary>
        /// 新增AccountCheck
        /// </summary>
        /// <param name="member"></param>
        public void CreateAccountCheck(AccountCheckModel member)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的資料
                    var newAccountCheck = new AccountCheck()
                    {
                        CheckID = member.CheckID,
                        AccountID = member.AccountID,
                        ID = member.ID,
                    };

                    //將新資料插入EF的集合中
                    contextModel.AccountChecks.Add(newAccountCheck);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountCheckManager.CreateAccountCheck", ex);
                throw;
            }
        }
    }
}