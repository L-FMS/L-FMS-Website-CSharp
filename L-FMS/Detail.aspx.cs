using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;

namespace L_FMS
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Comment_Submit(object sender, EventArgs e)
        {
            string comment = Request.Form["comment"];
            COMMENTS comments = new COMMENTS
            {
                COMMENT_ID = DBModel.GetInstance().GetSeqNextVal("comments"),
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
                        ID = DBModel.GetInstance().GetSeqNextVal("comment_item_user"),
                        COMMENT_ID = commentTemp.COMMENT_ID,
                        ITEM_ID = 0, //这里需要获取物品的ID
                        USER_ID = 0 //同上
                    };
                    db.COMMENT_ITEM_USER.Add(comment_item_user);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                }
            }           
        }
    }
}