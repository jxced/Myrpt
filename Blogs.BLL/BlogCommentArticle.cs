﻿/**  版本信息模板在安装目录下，可自行修改。
* BlogCommentArticle.cs
*
* 功 能： N/A
* 类 名： BlogCommentArticle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/2 22:21:06   N/A    初版
*
* Copyright (c) 2012 Blogs Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Blogs.Common;
using Blogs.Model;
namespace Blogs.BLL
{
	/// <summary>
	/// BlogCommentArticle
	/// </summary>
	public partial class BlogCommentArticle
	{
		private readonly Blogs.DAL.BlogCommentArticle dal=new Blogs.DAL.BlogCommentArticle();
		public BlogCommentArticle()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cmaid)
		{
			return dal.Exists(cmaid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Blogs.Model.BlogCommentArticle model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Blogs.Model.BlogCommentArticle model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cmaid)
		{
			
			return dal.Delete(cmaid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cmaidlist )
		{
			return dal.DeleteList(Blogs.Common.PageValidate.SafeLongFilter(cmaidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blogs.Model.BlogCommentArticle GetModel(int cmaid)
		{
			
			return dal.GetModel(cmaid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Blogs.Model.BlogCommentArticle GetModelByCache(int cmaid)
		{
			
			string CacheKey = "BlogCommentArticleModel-" + cmaid;
			object objModel = Blogs.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(cmaid);
					if (objModel != null)
					{
						int ModelCache = Blogs.Common.ConfigHelper.GetConfigInt("ModelCache");
						Blogs.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Blogs.Model.BlogCommentArticle)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Blogs.Model.BlogCommentArticle> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Blogs.Model.BlogCommentArticle> DataTableToList(DataTable dt)
		{
			List<Blogs.Model.BlogCommentArticle> modelList = new List<Blogs.Model.BlogCommentArticle>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Blogs.Model.BlogCommentArticle model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

