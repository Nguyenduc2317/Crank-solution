using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Dialog;

namespace cr_NYV_PLUGIN
{
    public partial class Frm_Main : PluginFormBase
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbb_Type.SelectedIndex = 0;
            txt_CrankRatio.Text = "10";
            txt_Distance.Text = "200";
            txt_Distance.Enabled =false;
            txt_Spacing.Enabled = false;
            txt_LapLenght.Text = "45";
            cbb_CrankOrientation.SelectedIndex = 0;
            cbb_Spaccing.SelectedIndex = 0;
        }

        private void cbb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Type.SelectedIndex==0)
            {
                txt_CrankRatio.Enabled = true;
                txt_Distance.Enabled = false;
                txt_CrankRatio.Focus();
            }
            else
            {
                txt_CrankRatio.Enabled = false;
                txt_Distance.Enabled = true;
                txt_Distance.Focus();
            }
        }

        private void cbb_Spaccing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Spaccing.SelectedIndex==0)
            {
                txt_Spacing.Enabled = false;
                txt_Spacing.Text = "";
            }
            else
            {
                txt_Spacing.Enabled = true;
                txt_Spacing.Text = "30";
            }
        }
    }
}
