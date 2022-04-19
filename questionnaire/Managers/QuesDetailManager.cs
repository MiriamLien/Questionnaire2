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
                        deleteQues.IsEnable = false;
                    //contextModel.Contents.Remove(deleteQues);

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
    }
}