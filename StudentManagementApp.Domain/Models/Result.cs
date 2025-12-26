using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Domain.Models
{
    public class Result
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static Result Ok(object data = null) => new Result
        {
            success = true,
            data = data
        };

        public static Result Fail(string message) => new Result
        {
            success = false,
            message = message,

        };
    }
}
