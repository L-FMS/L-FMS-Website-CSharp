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
    
    public partial class USER_QUESTION
    {
        public decimal ID { get; set; }
        public decimal USER_ID { get; set; }
        public decimal QUESTION_ID { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual QUESTION QUESTION { get; set; }
    }
}
