using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AutoCoder.Common
{
    class DBHelper
    {
        #region 判断DataSet是否有数据
        /// <summary>
        /// 判断DataSet是否有数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool IsEmptyDS(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        
    }
}
