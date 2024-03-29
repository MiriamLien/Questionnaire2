﻿using questionnaire.Helpers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Managers
{
    public class QuesContentsManager
    {
        /// <summary>
        /// 取得所有或附加查詢條件的問卷，及其所有資料
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<QuesContentsModel> GetQuesContentsList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的問卷
                    IQueryable<Content> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.Contents
                            where item.Title.Contains(keyword)
                            orderby item.TitleID descending
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Contents
                            orderby item.TitleID descending
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    var QuestionnaireList = new List<QuesContentsModel>();
                    foreach (var item in list)
                    {
                        var questionnaire = new QuesContentsModel()
                        {
                            ID = item.ID,
                            TitleID = item.TitleID,
                            Title = item.Title,
                            Body = item.Body,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsEnable = item.IsEnable,
                            strIsEnable = item.IsEnable ? "開放中" : "已關閉"
                        };
                        QuestionnaireList.Add(questionnaire);
                    }
                    return QuestionnaireList;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.GetQuesContentsList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得所有或起始日的問卷清單
        /// </summary>
        /// <param name="startDT"></param>
        /// <returns></returns>
        public List<QuesContentsModel> GetStartDateQuesContentsList(DateTime startDT)
        {
            var startDTString = startDT.ToString();

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得加查詢條件的問卷
                    IQueryable<Content> query;
                    if (!string.IsNullOrWhiteSpace(startDTString))
                    {
                        query =
                        from item in contextModel.Contents
                        where item.StartDate >= startDT
                        orderby item.TitleID descending
                        select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Contents
                            orderby item.TitleID descending
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    var QuestionnaireList = new List<QuesContentsModel>();
                    foreach (var item in list)
                    {
                        var questionnaire = new QuesContentsModel()
                        {
                            ID = item.ID,
                            TitleID = item.TitleID,
                            Title = item.Title,
                            Body = item.Body,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsEnable = item.IsEnable,
                            strIsEnable = item.IsEnable ? "開放中" : "已關閉"
                        };
                        QuestionnaireList.Add(questionnaire);
                    }
                    return QuestionnaireList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.GetStartDateQuesContentsList", ex);
                throw;
            }
        }
        /// <summary>
        /// 取得所有或搜尋結束日的問卷清單
        /// </summary>
        /// <param name="endDT"></param>
        /// <returns></returns>
        public List<QuesContentsModel> GetEndDateQuesContentsList(DateTime endDT)
        {
            var endDTString = endDT.ToString();

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得加查詢條件的問卷
                    IQueryable<Content> query;
                    if (!string.IsNullOrWhiteSpace(endDTString))
                    {
                        query =
                        from item in contextModel.Contents
                        where item.EndDate <= endDT
                        orderby item.TitleID descending
                        select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Contents
                            orderby item.TitleID descending
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    var QuestionnaireList = new List<QuesContentsModel>();
                    foreach (var item in list)
                    {
                        var questionnaire = new QuesContentsModel()
                        {
                            ID = item.ID,
                            TitleID = item.TitleID,
                            Title = item.Title,
                            Body = item.Body,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsEnable = item.IsEnable,
                            strIsEnable = item.IsEnable ? "開放中" : "已關閉"
                        };
                        QuestionnaireList.Add(questionnaire);
                    }
                    return QuestionnaireList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.GetEndDateQuesContentsList", ex);
                throw;
            }
        }
        /// <summary>
        /// 取得所有或搜尋結束日的問卷清單
        /// </summary>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <returns></returns>
        public List<QuesContentsModel> GetDateQuesContentsList(DateTime startDT, DateTime endDT)
        {
            var startDTString = startDT.ToString();
            var endDTString = endDT.ToString();

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得加查詢條件的問卷
                    IQueryable<Content> query;
                    if (!string.IsNullOrWhiteSpace(startDTString) &&
                        !string.IsNullOrWhiteSpace(endDTString))
                    {
                        query =
                        from item in contextModel.Contents
                        where item.StartDate >= startDT
                        where item.EndDate <= endDT
                        orderby item.TitleID descending
                        select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Contents
                            orderby item.TitleID descending
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    var QuestionnaireList = new List<QuesContentsModel>();
                    foreach (var item in list)
                    {
                        var questionnaire = new QuesContentsModel()
                        {
                            ID = item.ID,
                            TitleID = item.TitleID,
                            Title = item.Title,
                            Body = item.Body,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsEnable = item.IsEnable,
                            strIsEnable = item.IsEnable ? "開放中" : "已關閉"
                        };
                        QuestionnaireList.Add(questionnaire);
                    }
                    return QuestionnaireList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.GetDateQuesContentsList", ex);
                throw;
            }
        }

        /// <summary>
        /// 使用TitleID取得問卷
        /// </summary>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public Content GetQuesContent(int titleID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Contents
                        where item.TitleID == titleID
                        select item;

                    //取得問卷所有資料
                    var Ques = query.FirstOrDefault();

                    //檢查是否存在
                    if (Ques != null)
                        return Ques;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.GetQuesContent", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入ID取得問卷所有資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Content GetQuesContent(Guid id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Contents
                        where item.ID == id
                        select item;

                    //取得問卷所有資料
                    var QuesContent = query.FirstOrDefault();

                    //檢查是否存在
                    if (QuesContent != null)
                        return QuesContent;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.GetQuesContent", ex);
                throw;
            }
        }

        #region "增刪修"
        /// <summary>
        /// 新增問卷
        /// </summary>
        /// <param name="ques"></param>
        public void CreateQues(QuesContentsModel ques)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {

                    //建立新問卷
                    var newQues = new Content
                    {
                        ID = ques.ID,
                        Title = ques.Title,
                        Body = ques.Body,
                        StartDate = ques.StartDate,
                        EndDate = ques.EndDate,
                        IsEnable = ques.IsEnable
                    };

                    //將新資料插入EF的集合中
                    contextModel.Contents.Add(newQues);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.CreateQues", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改問卷內容
        /// </summary>
        /// <param name="ques"></param>
        public void UpdateQues(QuesContentsModel ques)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Contents.Where(item => item.ID == ques.ID);

                    //取得資料
                    var updateQues = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateQues != null)
                    {
                        updateQues.Title = ques.Title;
                        updateQues.Body = ques.Body;
                        updateQues.StartDate = ques.StartDate;
                        updateQues.EndDate = ques.EndDate;
                        updateQues.IsEnable = ques.IsEnable;
                    }

                    else
                        throw new Exception("此問卷不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("QuesContentsManager.UpdateQues", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除問卷
        /// </summary>
        /// <param name="id"></param>
        public void DeleteQues(Guid id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Contents.Where(item => item.ID == id);

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
                Logger.WriteLog("QuesContentsManager.DeleteQues", ex);
                throw;
            }
        }
        #endregion
    }
}