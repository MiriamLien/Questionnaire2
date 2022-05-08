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
        /// 使用問卷ID取得使用者填寫的內容的清單
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserQuesDetail> GetUserQuesDetailList(Guid id)
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
                Logger.WriteLog("UserQuesDetailManager.GetUserQuesDetailList", ex);
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


        /// <summary>
        /// 輸入問卷ID取得使用者資訊以及問題內容(題目)的清單
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserInfoAndQuesModel> GetUserInfoAndQuesList(Guid id)
        {
            string idText = id.ToString();

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    // 取得加查詢條件的問題
                    IQueryable<UserInfoAndQuesModel> query;
                    if (!string.IsNullOrWhiteSpace(idText))
                    {
                        query =
                            from item in contextModel.QuesDetails
                            join item2 in contextModel.UserInfos
                            on item.ID equals item2.ID
                            where item.ID == id
                            select new UserInfoAndQuesModel
                            {
                                UserID = item2.UserID,
                                ID = item.ID,
                                Name = item2.Name,
                                Phone = item2.Phone,
                                Age = item2.Age,
                                Email = item2.Phone,
                                QuesID = item.QuesID,
                                QuesTitle = item.QuesTitle,
                                QuesChoices = item.QuesChoices,
                            };
                    }
                    else
                    {
                        query =
                            from item in contextModel.QuesDetails
                            join item2 in contextModel.UserInfos
                            on item.ID equals item2.ID
                            select new UserInfoAndQuesModel
                            {
                                UserID = item2.UserID,
                                ID = item.ID,
                                Name = item2.Name,
                                Phone = item2.Phone,
                                Age = item2.Age,
                                Email = item2.Phone,
                                QuesID = item.QuesID,
                                QuesTitle = item.QuesTitle,
                                QuesChoices = item.QuesChoices,
                            };
                    }

                    // 組合，並取回結果
                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("UserQuesDetailManager.GetUserInfoAndQuesList", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入問卷ID取得使用者資訊及問題內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public UserInfoAndQuesModel GetUserInfoAndQues(Guid id)
        //{
        //    string idText = id.ToString();

        //    try
        //    {
        //        using (ContextModel contextModel = new ContextModel())
        //            {
        //            var query =
        //                from item in contextModel.QuesDetails
        //                join item2 in contextModel.UserInfos
        //                on item.ID equals item2.ID
        //                where item.ID == id
        //                select new UserInfoAndQuesModel
        //                {
        //                    UserID = item2.UserID,
        //                    ID = item.ID,
        //                    Name = item2.Name,
        //                    Phone = item2.Phone,
        //                    Age = item2.Age,
        //                    Email = item2.Phone,
        //                    QuesID = item.QuesID,
        //                    QuesTitle = item.QuesTitle,
        //                    QuesChoices = item.QuesChoices,
        //                };

        //            var userInfoAndQues = query.FirstOrDefault();

        //            //檢查是否存在
        //            if (userInfoAndQues != null)
        //                return userInfoAndQues;

        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog("UserQuesDetailManager.GetUserInfoAndQues", ex);
        //        throw;
        //    }
        //}
    }
}