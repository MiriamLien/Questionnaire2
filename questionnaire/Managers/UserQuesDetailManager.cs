using questionnaire.Helpers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Managers
{
    public class UserQuesDetailManager
    {
        /// <summary>
        /// 取得指定UserID的問卷回答，及其所有資料 一筆
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<UserQuesDetail> GetUserInfoList(Guid userID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var userIDText = userID.ToString();

                    //取得所有或加查詢條件的帳戶
                    var query =
                           from item in contextModel.UserQuesDetails
                           where item.UserID == userID
                           select item;

                    //組合，並取回結果
                    var list = query.ToList();

                    //檢查是否存在
                    if (list != null)
                        return list;

                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("UserQuesDetailManager.GetUserInfoList", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增新的問卷回答
        /// </summary>
        /// <param name="model"></param>
        public void CreateUserQuesDetail(UserQuesDetailModel model)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新的用戶資料及回答
                    var newUserQuesDetail = new UserQuesDetail()
                    {
                        AnsID = model.AnsID,
                        ID = model.ID,
                        UserID = model.UserID,
                        QuesID = model.QuesID,
                        Answer = model.Answer,
                        AccountID = model.AccountID,
                    };

                    //將新資料插入EF的集合中
                    contextModel.UserQuesDetails.Add(newUserQuesDetail);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("UserQuesDetailManager.CreateUserQuesDetail", ex);
                throw;
            }
        }

    }
}