using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DasherStation.common
{

    public partial class BaseForm : Form
    {
        private long id;
        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        protected string userName = "default";
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public BaseForm()
        {
            InitializeComponent();
        }

        
    }
}
