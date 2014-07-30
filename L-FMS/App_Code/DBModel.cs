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
            decimal result = 0;
            using(LFMSContext db = new LFMSContext())
            {
                string seq = table + "_increment_seq.nextval";

                var l = db.Database.SqlQuery<decimal>("select " + seq + " from dual").ToList();

                foreach (var n in l)
                {
                    result = n;
                    break;
                }
            }
            return result;
        }

    }
}