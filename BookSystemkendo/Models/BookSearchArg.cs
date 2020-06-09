using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BookSystemkendo.Models
{
    public class BookSearchArg
    {

        [DisplayName("書名")]
        public string BookName { get; set; }
        [DisplayName("借閱人")]
        public string UserName { get; set; }
        [DisplayName("圖書類別")]
        public string ClassNameID { get; set; }
        [DisplayName("借閱狀態")]
        public string CodeID { get; set; }
    }
}