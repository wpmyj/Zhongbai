/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmPaySearch.cs
* 文件功能描述：人力资源工资查询窗体
*
* 创建人： 杨林
* 创建时间：2009-03-05
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.HumanResource
{
    public partial class FrmPaySearch : DasherStation.common.BaseForm
    {
        public FrmPaySearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            DataSet dtsResult = new PayOffLogic().GetPay(this.datePayOff.Value.Year, this.datePayOff.Value.Month, this.txtPayoffName.Text.Trim());

            dtgList.DataSource = dtsResult.Tables[0];

            
        }
    }
}
