using questionnaire.Helpers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Managers
{
    public class QuesDetailManager
    {
        /// <summary>
        /// 輸入問卷id取得問題清單
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<QuesAndTypeModel> GetQuesDetailList(Guid id)
        {
            string idText = id.ToString();

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得加查詢條件的問題
                    IQueryable<QuesAndTypeModel> query;
                    if (!string.IsNullOrWhiteSpace(idText))
                    {
                        query =
                        from item in contextModel.QuesDetails
                        join item2 in contextModel.QuesTypes
                        on item.QuesTypeID equals item2.QuesTypeID
                        where item.ID == id
                        select new QuesAndTypeModel
                        {
                            QuesTitle = item.QuesTitle,
                            QuesType1 = item2.QuesType1,
                            IsEnable = item.IsEnable
                        };
                    }
                    else
                    {
                        query =
                            from item in contextModel.QuesDetails
                            join item2 in contextModel.QuesTypes
                            on item.QuesTypeID equals item2.QuesTypeID
                            select new QuesAndTypeModel
                            {
                                QuesTitle = item.QuesTitle,
                                QuesType1 = item2.QuesType1,
                                IsEnable = item.IsEnable
                            };
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesDetailManager.GetQuesDetailList", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入問題ID取得問題內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QuesDetail GetQuesDetail(int id)
        {
            string idText = id.ToString();

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                    from item in contextModel.QuesDetails
                    where item.QuesID == id
                    select item;

                    var QuesDetail = query.FirstOrDefault();

                    //檢查是否存在
                    if (QuesDetail != null)
                        return QuesDetail;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesDetailManager.GetQuesDetail", ex);
                throw;
            }
        }

        #region "增刪修"
        /// <summary>
        /// 新增問題
        /// </summary>
        /// <param name="ques"></param>
        public void CreateQuesDetail(QuesDetailModel ques)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新問題
                    var newQuesDetail = new QuesDetail
                    {
                        QuesID = ques.QuesID,
                        ID = ques.ID,
                        QuesTitle = ques.QuesTitle,
                        QuesTypeID = ques.QuesTypeID,
                        IsEnable = ques.IsEnable
                    };

                    //將新資料插入EF的集合中
                    contextModel.QuesDetails.Add(newQuesDetail);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesDetailManager.CreateQuesDetail", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改問題
        /// </summary>
        /// <param name="ques"></param>
        public void UpdateQuesDetail(QuesDetailModel ques)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.QuesDetails.Where(item => item.ID == ques.ID);

                    //取得資料
                    var updateQues = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateQues != null)
                    {
                        updateQues.QuesID = ques.QuesID;
                        updateQues.ID = ques.ID;
                        updateQues.QuesTitle = ques.QuesTitle;
                        updateQues.QuesTypeID = ques.QuesTypeID;
                        updateQues.IsEnable = ques.IsEnable;
                    }
                    else
                        throw new Exception("此問題不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesDetailManager.UpdateQuesDetail", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除問題
        /// </summary>
        /// <param name="id"></param>
        public void DeleteQuesDetail(Guid id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.QuesDetails.Where(item => item.ID == id);

                    //取得資料
                    var deleteQues = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteQues != null)
                        contextModel.QuesDetails.Remove(deleteQues);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesDetailManager.DeleteQuesDetail", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 做字串切割，並取得問題列表
        /// </summary>
        /// <param name="ques"></param>
        /// <returns></returns>
        public List<QuesAndTypeModel> GetQuestionList(string ques)
        {
            ques = ques.TrimEnd('$');
            string[] question = ques.Split('$');

            List<QuesAndTypeModel> quesList = new List<QuesAndTypeModel>();
            foreach (string item in question)
            {
                string[] questDetail = item.Split('&');

                QuesAndTypeModel Ques = new QuesAndTypeModel();
                Ques.QuesTitle = questDetail[0];
                Ques.QuesChoices = questDetail[1];
                Ques.QuesTypeID = Convert.ToInt32(questDetail[2]);
                Ques.QuesType1 = questDetail[3];
                Ques.IsEnable = Convert.ToBoolean(questDetail[4]);

                quesList.Add(Ques);
            }
            return quesList;
        }
    }
}