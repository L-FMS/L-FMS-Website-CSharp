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
    public partial class PostFoundInfo : System.Web.UI.Page
    {
        protected void postButton(object sender, EventArgs e)
        {
            string name = Request.Form["item-name"];
            string description = Request.Form["item-description"];
            string tagString = Request.Form["item-tags"];
            string place = Request.Form["item-place"];
            var image = Request.Files["item-image"];
            string[] tag = tagString.Split(new char[] { ',' });

            byte[] buffer = new byte[image.ContentLength];
            image.InputStream.Read(buffer, 0, buffer.Length);

            /*************************************************************************
                添加ITEM到数据库，ID是利用DBModel的方法得到的，后面的ID类似
             *************************************************************************/
            ITEM item = new ITEM
            {
                ITEM_ID = DBModel.GetInstance().GetSeqNextVal("item"),
                ITEM_NAME = name,
                ITEM_DESCRIPTION = description,
                IMAGE = buffer
            };

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    ITEM itemTemp = db.ITEM.Add(item);

                    /*************************************************************************
                                 添加PUBLISHMENT到数据库，注意里面涉及到USER_ID
                    *************************************************************************/
                    PUBLISHMENT publish = new PUBLISHMENT
                    {
                        ID = DBModel.GetInstance().GetSeqNextVal("publishment"),
                        ITEM_ID = itemTemp.ITEM_ID,
                        PLACE = place,
                        // PUBLISHER_ID=USER_ID,      这里是预留接口，获得当前操作的用户ID再写入
                        PUBLISHER_ID = int.Parse(Session["userID"].ToString()),
                        PUBLISH_DATE = DateTime.Now,
                        //下面是固定输入当前操作产生的类型
                        TYPE = "found",
                        IS_END = 0,
                        END_TIME = null
                    };
                    db.PUBLISHMENT.Add(publish);

                    /*************************************************************************
                              添加TAG到数据库，TAG与ITEM为多对一的关系
                   *************************************************************************/
                    foreach (string s in tag)
                    {
                        var tags = from p in db.TAG where p.TAG_TEXT == s select p;
                        int count = 0;
                        foreach (var currentTag in tags)
                        {
                            count++;
                        }
                        if (count != 0)
                        {
                            foreach (var currentTag in tags)
                            {
                                //建立多对一的关系
                                ITEM_TAG itemTag = new ITEM_TAG
                                {
                                    ID = DBModel.GetInstance().GetSeqNextVal("item_tag"),
                                    ITEM_ID = itemTemp.ITEM_ID,
                                    TAG_ID = currentTag.TAG_ID,
                                };
                                db.ITEM_TAG.Add(itemTag);
                            }
                        }
                        else
                        {
                            //将TAG内容添加到数据库
                            TAG tagDB = new TAG
                            {
                                TAG_ID = DBModel.GetInstance().GetSeqNextVal("tag"),
                                TAG_TEXT = s,
                            };
                            TAG tt = db.TAG.Add(tagDB);
                            ITEM_TAG itemTag = new ITEM_TAG
                            {
                                ID = DBModel.GetInstance().GetSeqNextVal("item_tag"),
                                ITEM_ID = itemTemp.ITEM_ID,
                                TAG_ID = tt.TAG_ID,
                            };
                            db.ITEM_TAG.Add(itemTag);
                        }
                    }

                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                }
            }
            Response.Redirect("Default.aspx");
        }
    }
}