//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace L_FMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class PUBLISHMENT
    {
        public decimal ID { get; set; }
        public decimal ITEM_ID { get; set; }
        public decimal PUBLISHER_ID { get; set; }
        public System.DateTime PUBLISH_DATE { get; set; }
        public string TYPE { get; set; }
        public decimal IS_END { get; set; }
        public Nullable<System.DateTime> END_TIME { get; set; }
        public string PLACE { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual ITEM ITEM { get; set; }
    }
}
