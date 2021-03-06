﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using BaiRong.Core;
using BaiRong.Core.Model.Enumerations;
using SiteServer.CMS.Core;

namespace SiteServer.BackgroundPages.Cms
{
	public class PageTemplateCss : BasePageCms
    {
		public Repeater RptContents;
        public Button BtnAdd;

        private string _directoryPath;

        public static string GetRedirectUrl(int publishmentSystemId)
        {
            return PageUtils.GetCmsUrl(nameof(PageTemplateCss), new NameValueCollection
            {
                {"PublishmentSystemID", publishmentSystemId.ToString()}
            });
        }

        public void Page_Load(object sender, EventArgs e)
        {
            if (IsForbidden) return;

            PageUtils.CheckRequestParameter("PublishmentSystemID");

            _directoryPath = PathUtility.MapPath(PublishmentSystemInfo, "@/css");

            if (Body.IsQueryExists("Delete"))
            {
                var fileName = Body.GetQueryString("FileName");

                try
                {
                    FileUtils.DeleteFileIfExists(PathUtils.Combine(_directoryPath, fileName));
                    Body.AddSiteLog(PublishmentSystemId, "删除样式文件", $"样式文件:{fileName}");
                    SuccessDeleteMessage();
                }
                catch (Exception ex)
                {
                    FailDeleteMessage(ex);
                }
            }

            if (IsPostBack) return;

            VerifySitePermissions(AppManager.Permissions.WebSite.Template);

            DirectoryUtils.CreateDirectoryIfNotExists(_directoryPath);
            var fileNames = DirectoryUtils.GetFileNames(_directoryPath);
            var fileNameList = new List<string>();
            foreach (var fileName in fileNames)
            {
                if (EFileSystemTypeUtils.IsTextEditable(EFileSystemTypeUtils.GetEnumType(PathUtils.GetExtension(fileName))))
                {
                    if (!fileName.Contains("_parsed"))
                    {
                        fileNameList.Add(fileName);
                    }
                }
            }

            RptContents.DataSource = fileNameList;
            RptContents.ItemDataBound += RptContents_ItemDataBound;
            RptContents.DataBind();

            BtnAdd.Attributes.Add("onclick", $"location.href='{PageTemplateCssAdd.GetRedirectUrl(PublishmentSystemId)}';return false");
        }

        private void RptContents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var fileName = (string) e.Item.DataItem;

            var ltlFileName = (Literal)e.Item.FindControl("ltlFileName");
            var ltlCharset = (Literal)e.Item.FindControl("ltlCharset");
            var ltlView = (Literal)e.Item.FindControl("ltlView");
            var ltlEdit = (Literal)e.Item.FindControl("ltlEdit");
            var ltlDelete = (Literal)e.Item.FindControl("ltlDelete");

            ltlFileName.Text = fileName;

            var charset = FileUtils.GetFileCharset(PathUtils.Combine(_directoryPath, fileName));
            ltlCharset.Text = ECharsetUtils.GetText(charset);

            ltlView.Text = $@"<a href=""{PublishmentSystemInfo.Additional.WebUrl}/css/{fileName}"" target=""_blank"">查看</a>";
            ltlEdit.Text =
                $@"<a href=""{PageTemplateCssAdd.GetRedirectUrl(PublishmentSystemId, fileName)}"">编辑</a>";
            ltlDelete.Text =
                $@"<a href=""javascript:;"" onclick=""{AlertUtils.ConfirmDelete("删除文件", "此操作将删除样式文件，确认吗", $"{GetRedirectUrl(PublishmentSystemId)}&Delete={true}&FileName={fileName}")}"">删除</a>";
        }
	}
}
