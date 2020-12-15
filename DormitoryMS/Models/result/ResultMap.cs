using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 * 自定义响应结果集
 */
namespace DormitoryMS.Models.result
{
    public class ResultMap
    {
        public int status { get; set; }

        
        public  String msg { get; set; }


        public Object data { get; set; }

        public String ok { get; set; }

        public static ResultMap build(int status, String msg, Object data)
        {
            return new ResultMap(status, msg, data);
        }

        //正确且返回数据
        public static ResultMap OK(Object data)
        {
            return new ResultMap(data);
        }

        //正确不返回数据
        public static ResultMap OK()
        {
            return new ResultMap(null);
        }

        public static ResultMap errorMsg(String msg)
        {
            return new ResultMap(500, msg, null);
        }

        public static ResultMap errorMap(Object data)
        {
            return new ResultMap(501, "error", data);
        }

        public static ResultMap errorTokenMsg(String msg)
        {
            return new ResultMap(502, msg, null);
        }

        public static ResultMap errorException(String msg)
        {
            return new ResultMap(555, msg, null);
        }

        public ResultMap()
        {

        }

        public ResultMap(int status, String msg, Object data)
        {
            this.status = status;
            this.msg = msg;
            this.data = data;
        }

        public ResultMap(Object data)
        {
            this.status = 200;
            this.msg = "OK";
            this.data = data;
        }

        public Boolean isOK()
        {
            return this.status == 200;
        }

    }
}