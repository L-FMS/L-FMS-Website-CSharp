using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace L_FMS
{
    public partial class Detail : System.Web.UI.Page
    {

        protected PersonAllMessage person_message;
        protected ITEM item_message;
        protected PUBLISHMENT publishment_message;
        protected User_Comment[] UserComment;
        protected void Page_Load(object sender, EventArgs e)
        {
            int item_id = int.Parse(Session["ItemId"].ToString());
            //根据item_id 获得人物信息
            person_message = DBModel.GetInstance().GetUserMessageByItemID(item_id);
            //获得物品信息
            item_message = DBModel.GetInstance().GetItemByItemID(item_id);
            //获得物品图片
            int filelength = item_message.IMAGE.Length;
            string myUrl = HttpContext.Current.Server.MapPath(this.Request.ApplicationPath) + "TempDownLoad.jpeg";
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("TempDownLoad.jpeg"));
            if (file.Exists)
            {
                file.Delete();
            }
            FileStream fs = new FileStream(myUrl, FileMode.OpenOrCreate);
            BinaryWriter w = new BinaryWriter(fs);
            w.BaseStream.Write(item_message.IMAGE, 0, filelength);
            w.Flush();
            w.Close();

            //获得物品提交时间信息以及发现（遗失）地点信息
            publishment_message = DBModel.GetInstance().GetPublishmentByItemID(item_id);
            //获得物品评论
            UserComment = DBModel.GetInstance().GetUserCommentByItemID(item_id);

            if (person_message == null || item_message == null || publishment_message == null)
            {
                Session["errorMessage"] = "物品不存在或已删除";
                Response.Redirect("ErrorPage.aspx");
            }
                
        }

        protected void Comment_Submit(object sender, EventArgs e)
        {
            string comment = Request.Form["comment"];
            int item_id = int.Parse(Session["ItemId"].ToString());
            COMMENTS comments = new COMMENTS
            {
                COMMENT_ID = DBModel.GetInstance().GetSeqNextVal("comment"),
                CONTENT = comment,
                TIME = DateTime.Now
            };
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    COMMENTS commentTemp = db.COMMENTS.Add(comments);
                    COMMENT_ITEM_USER comment_item_user = new COMMENT_ITEM_USER
                    {
                        ID = DBModel.GetInstance().GetSeqNextVal("com_item_user"),
                        COMMENT_ID = commentTemp.COMMENT_ID,
                        ITEM_ID = int.Parse(Session["ItemId"].ToString()), //这里需要获取物品的ID
                        USER_ID = Convert.ToDecimal( Session["userID"].ToString()) //同上
                    };
                    db.COMMENT_ITEM_USER.Add(comment_item_user);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                }
            }
            //提交评论时 先更新页面 再执行提交 所以需要在重新获取一次
            UserComment = DBModel.GetInstance().GetUserCommentByItemID(item_id);
        }
    }
}