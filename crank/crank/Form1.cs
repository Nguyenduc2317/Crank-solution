using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using tsm = Tekla.Structures.Model;
using mui = Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;
using g3d = Tekla.Structures.Geometry3d;
namespace crank
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_action_Click(object sender, EventArgs e)
        {
            // kết nối với model đang hiện hành.
            tsm.Model model = new tsm.Model();
            if (!model.GetConnectionStatus())
            {
                MessageBox.Show("Tekla is not connected!! @@");
                return;
            }
            // kiểm tra xem đã kết nối được với model chưa.
            //--------------------------------
            // Nhặt 2 đối tượng Rebar group
            tsm.RebarGroup rebargroup0 = null;
            tsm.RebarGroup rebargroup1 = null;
            // Khởi tạo picker
            mui.Picker picker = new mui.Picker();
            string mess = "";
            while (rebargroup0 == null & rebargroup1 == null)
            {
                try
                {
                    tsm.ModelObject obj0 = picker.PickObject(mui.Picker.PickObjectEnum.PICK_ONE_OBJECT, mess + "pick a group Rebar 0");
                    if (obj0 as tsm.RebarGroup != null)
                    {
                        rebargroup0 = obj0 as tsm.RebarGroup;
                        mess = "";
                    }
                    else
                    {
                        mess = "Object is not a Rebar group. ";
                    }
                    tsm.ModelObject obj1 = picker.PickObject(mui.Picker.PickObjectEnum.PICK_ONE_OBJECT, mess + "pick a group Rebar 1");
                    if (obj1 as tsm.RebarGroup != null)
                    {
                        rebargroup1 = obj1 as tsm.RebarGroup;
                        mess = "";
                    }
                    else
                    {
                        mess = "Object is not a Rebar group. ";
                    }
                }
                catch
                {
                    Operation.DisplayPrompt("not select");
                    return;
                }
            }
        }
    }
}
