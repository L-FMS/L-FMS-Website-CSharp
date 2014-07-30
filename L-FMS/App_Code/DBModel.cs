using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L_FMS
{
    public class DBModel
    {
        // 单例
        private static DBModel dbModel;
        private LFMSContext db 
        {
            get 
            { 
                if(db == null) 
                {
                    db = new LFMSContext();
                } 
                return db;
            }
            set
            {
                db = value;
            }
        }

        // 私有构造函数
        private DBModel()
        {
            
        }

        public static DBModel GetInstance()
        {
            if (dbModel == null)
            {
                dbModel = new DBModel();
            }
            return dbModel;
        }

        // 操作
        // 获取序列下一个值
        public decimal GetSeqNextVal(string table)
        {
            string seq = table + "_increment_seq";
            
            var l = db.Database.SqlQuery("select {0} from dual", seq + ".nextval").ToList();


            return nextVal;
        }

    }
}