using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookSystemkendo.Models
{
    public class BookData
    { /// <summary>
      /// 書籍ID
      /// </summary>
      ///[MaxLength(5)]
        [DisplayName("圖書編號")]
        public int BookID { get; set; }

        /// <summary>
        /// 圖書類別
        /// </summary>
        ///[MaxLength(5)]
        [DisplayName("圖書類別")]
        public string BookClassName { get; set; }

        /// <summary>
        /// 圖書類別ID
        /// </summary>
        [DisplayName("圖書類別ID")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookClassID { get; set; }

        /// <summary>
        /// 書名
        /// </summary> 
        [DisplayName("書名")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookName { get; set; }

        /// <summary>
        /// 購買日期
        /// </summary>
        [DisplayName("購買日期")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookBoughtDate { get; set; }

        /// <summary>
        /// 借閱人
        /// </summary>
        [DisplayName("借閱人")]
        public string UserName { get; set; }

        /// <summary>
        /// 借閱人ID
        /// </summary>
        [DisplayName("借閱人ID")]
        public string UserID { get; set; }

        /// <summary>
        /// 借閱狀態
        /// </summary>
        [DisplayName("借閱狀態")]
        public string CodeName { get; set; }


        /// <summary>
        /// 借閱狀態ID
        /// </summary>
        [DisplayName("借閱狀態ID")]
        public string CodeID { get; set; }


        /// <summary>
        /// 作者
        /// </summary>
        [DisplayName("作者")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookAuthor { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        [DisplayName("出版社")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookPublisher { get; set; }

        /// <summary>
        /// 內容簡介
        /// </summary>
        [DisplayName("內容簡介")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookNote { get; set; }

        /// <summary>
        /// 借閱日期
        /// </summary>
        [DisplayName("借閱日期")]
        public string LendDate { get; set; }
    }
}
