﻿using questionnaire.Helpers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace questionnaire.Managers
{
    public class CQManager
    {
        /// <summary>
        /// 取得所有或附加查詢條件的CQ，及其所有資料
        /// </summary>
        /// <returns></returns>
        public List<CommonQue> GetCQsList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的問卷
                    IQueryable<CommonQue> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                        from item in contextModel.CommonQues
                        where item.CQTitle.Contains(keyword)
                        orderby item.CQID descending
                        select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.CommonQues
                            orderby item.CQID descending
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CQManager.GetCQsList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得查詢條件的CQ，及其所有資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommonQue GetCQs(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的問卷

                    var query =
                        from item in contextModel.CommonQues
                        where item.CQID == id
                        select item;

                    //取得Account所有資料
                    var CQ = query.FirstOrDefault();

                    if (CQ != null)
                        return CQ;

                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CQManager.GetCQs", ex);
                throw;
            }
        }


        #region "增刪修"
        /// <summary>
        /// 新增CQ
        /// </summary>
        /// <param name="ques"></param>
        public void CreateCQ(CQModel ques)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新問卷
                    var newCQ = new CommonQue
                    {
                        CQID = ques.CQID,
                        CQTitle = ques.CQTitle,
                        QuesTypeID = ques.QuesTypeID,
                        CQChoices = ques.CQChoices,
                        CQIsEnable = ques.CQIsEnable
                    };

                    //將新資料插入EF的集合中
                    contextModel.CommonQues.Add(newCQ);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CQManager.CreateCQ", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改CQ
        /// </summary>
        /// <param name="ques"></param>
        public void UpdateCQ(CQModel ques)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CommonQues.Where(item => item.CQID == ques.CQID);

                    //取得資料
                    var updateCQ = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateCQ != null)
                    {
                        updateCQ.CQID = ques.CQID;
                        updateCQ.CQTitle = ques.CQTitle;
                        updateCQ.QuesTypeID = ques.QuesTypeID;
                        updateCQ.CQChoices = ques.CQChoices;
                        updateCQ.CQIsEnable = ques.CQIsEnable;
                    }
                    else
                        throw new Exception("此問卷不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CQManager.UpdateCQ", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除CQ
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCQ(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CommonQues.Where(item => item.CQID == id);

                    //取得資料
                    var deleteQues = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteQues != null)
                        contextModel.CommonQues.Remove(deleteQues);
                    //deleteQues.CQIsEnable = false;

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CQManager.DeleteCQ", ex);
                throw;
            }
        }
        #endregion
    }
}