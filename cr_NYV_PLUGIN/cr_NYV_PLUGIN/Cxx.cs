using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures;
using tsm = Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using g3d=Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;

namespace cr_NYV_PLUGIN
{
    public class structuredata
    {
        [StructuresField("CrankRatio")]
        public Double CrankRatio;
        [StructuresField("Distance")]
        public Double Distance;
        [StructuresField("Spacing")]
        public Double Spacing;
        [StructuresField("LapLenght")]
        public Double LapLenght;
        [StructuresField("Combo_Type")]
        public String Combo_Type;
        [StructuresField("Combo_Spacing")]
        public String Combo_Spacing;
        [StructuresField("Combo_Crank")]
        public String Combo_Crank;
    }
    [Plugin("cr_NYV_PLUGIN")]
    [PluginUserInterface("cr_NYV_PLUGIN.Frm_Main")]
    public class Cxx : PluginBase
    {
        private structuredata Data { get; set; }
        private double _CrankRatio;
        private double _Distance;
        private double _Spacing;
        private double _LapLenght;
        private String _Combo_Type;
        private String _Combo_Spacing;
        private String _Combo_Crank;
        tsm.Polygon poly0 = new tsm.Polygon();
        tsm.Polygon poly1 = new tsm.Polygon();
        Double r0, r1, r, onplan0, onplan1, onplan, maxx0, maxy0, maxz0, minx1, miny1, minz1, minx0, miny0, minz0, maxx1, maxy1, maxz1;
        tsm.Solid sol0, sol1;

        public Cxx(structuredata data)
        {
            tsm.Model M = new tsm.Model();
            Data = data;
        }
        public override List<InputDefinition> DefineInput()
        {
            Picker pickObject = new Picker();
            List<InputDefinition> RebarList = new List<InputDefinition>();
            var member1 = pickObject.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT,"pick doi tuong thu nhat");
            var member2 = pickObject.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "pick doi tuong thu hai");
            var input1 = new InputDefinition(member1.Identifier);
            var input2 = new InputDefinition(member2.Identifier);

            RebarList.Add(input1);
            RebarList.Add(input1);
            return RebarList;
        }
        private void GetvaluesFormDialog()
        {
            _CrankRatio = Data.CrankRatio;
            _Distance = Data.Distance;
            _Spacing = Data.Spacing;
            _LapLenght = Data.LapLenght;
            _Combo_Type = Data.Combo_Type;
            _Combo_Spacing = Data.Combo_Spacing;
            _Combo_Crank = Data.Combo_Crank;
        }
        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                GetvaluesFormDialog();
                var identifien1 = (Identifier)Input[0].GetInput();
                var identifien2 = (Identifier)Input[1].GetInput();
                var object1 = new tsm.Model().SelectModelObject(identifien1) as tsm.ModelObject;
                var object2 = new tsm.Model().SelectModelObject(identifien2) as tsm.ModelObject;
                //-------------------------------------------------------------------------
                tsm.RebarGroup rebargroup0 = null;
                tsm.RebarGroup rebargroup1 = null;
                while (rebargroup0==null & rebargroup1==null)
                {
                    try
                    {
                        tsm.ModelObject obj0 = object1;
                        if (obj0 as tsm.RebarGroup != null)
                        {
                            rebargroup0= obj0 as tsm.RebarGroup;
                            r0 = Double.Parse(rebargroup0.Size);
                            sol0 = rebargroup0.GetSolid();
                            maxx0 = sol0.MaximumPoint.X;
                            maxy0 = sol0.MaximumPoint.Y;
                            maxz0 = sol0.MaximumPoint.Z;
                            minx0 = sol0.MinimumPoint.X;
                            miny0 = sol0.MinimumPoint.Y;
                            minz0 = sol0.MinimumPoint.Z;
                        }
                        tsm.ModelObject obj1 = object2;
                        if (obj1 as tsm.RebarGroup != null)
                        {
                            rebargroup1 = obj1 as tsm.RebarGroup;
                            r1 = Double.Parse(rebargroup1.Size);
                            onplan0 = Double.Parse(rebargroup1.OnPlaneOffsets[0].ToString());
                            sol1 = rebargroup1.GetSolid();
                            maxx1 = sol1.MaximumPoint.X;
                            maxy1 = sol1.MaximumPoint.Y;
                            maxz1 = sol1.MaximumPoint.Z;
                            minx1 = sol1.MinimumPoint.X;
                            miny1 = sol1.MinimumPoint.Y;
                            minz1 = sol1.MinimumPoint.Z;
                        }
                        if (r0>=r1)
                        {
                            r = r1;
                        }
                        else
                        {
                            r = r0;
                        }
                        if (_Combo_Spacing == "Auto")
                        {
                            if (r==12 || r==14)
                            {
                                _Spacing = r + 2;
                            }
                            else if (r==8 || r==10 || r>14 & r<=12)
                            {
                                _Spacing = r + 3;
                            }
                            else if (r == 25)
                            {
                                _Spacing = r + 4;
                            }
                            else
                            {
                                _Spacing = r + 5;
                            }
                        }
                        //------------------------------------------------------------------
                        poly0.Points.Add(new g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2));
                        poly0.Points.Add(new g3d.Point(maxx0 - _LapLenght * r - _CrankRatio * r - 50, maxy0 - r / 2, maxz0 - r / 2));
                        poly0.Points.Add(new g3d.Point(maxx0 - _LapLenght * r - 50, maxy0 - r / 2, maxz0 - r / 2 - _Spacing));
                        poly0.Points.Add(new g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2 - _Spacing));

                        poly1.Points.Add(new g3d.Point(maxx0 - _LapLenght * r, maxy1 - r / 2, maxz1 - r / 2));
                        poly1.Points.Add(new g3d.Point(maxx1, maxy1 - r / 2, maxz1 - r / 2));
                        //-------------------------------------------------------------------
                        //end tạo điểm polygon
                        rebargroup0.Polygons.Clear();
                        rebargroup0.Polygons.Add(poly0);
                        rebargroup0.OnPlaneOffsets.Clear();
                        rebargroup0.OnPlaneOffsets.Add(0.0);

                        rebargroup0.Modify();

                        rebargroup1.Polygons.Clear();
                        rebargroup1.Polygons.Add(poly1);
                        rebargroup1.OnPlaneOffsets.Clear();
                        rebargroup1.OnPlaneOffsets.Add(0.0);
                        rebargroup1.Modify();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
