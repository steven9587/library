using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookSystemkendo.Models
{
    public class LoginData
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required(ErrorMessage = "Please enter your Username.")]
        [DisplayName("使用者帳號")]
        public string Username { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required(ErrorMessage = "Please enter your Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 使用者身分
        /// </summary>
        [DisplayName("使用者身分")]
        public string User { get; set; }
    }
}