using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace POS_Project
{
    public partial class nTabControl : TabControl
    {
        public nTabControl()
        {
            InitializeComponent();
        }
        // custome function
        protected override void WndProc(ref Message m)
        {
            try {
                // trapping the Tcm-adjustract message for hide the tabs from tab control
                if (m.Msg == 0x1328 && !DesignMode)
                {
                    m.Result = (IntPtr)1;
                }

                else
                {
                    base.WndProc(ref m);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public nTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
