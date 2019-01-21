using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures;
using tsm=Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;

namespace CreatBeam
{
    public class structuredata
    {
        [StructuresField("Lenght")]
        public double Lenght;
        [StructuresField("Profile")]
        public String Profile;
    }
    [Plugin("CreatBeam")]
    [PluginUserInterface("CreatBeam.Frm_Main")]
    public class Creat_Beams : PluginBase
    {
        private structuredata Data { get; set; }
        private double _Lenght;
        private String _Profile;
        public Creat_Beams(structuredata data)
        {
            tsm.Model M = new tsm.Model();
            Data = data;
        }
        //-----------------------------------------------------------------------
        public override List<InputDefinition> DefineInput()
        {
            Picker picbeam = new Picker();
            List<InputDefinition> Poinlist = new List<InputDefinition>();
            Point point1 = picbeam.PickPoint();
            Point point2 = picbeam.PickPoint();
            var member = picbeam.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            InputDefinition input1 = new InputDefinition(point1);
            InputDefinition input2 = new InputDefinition(point2);
            var input3 = new InputDefinition(member.Identifier);

            Poinlist.Add(input1);
            Poinlist.Add(input2);
            Poinlist.Add(input3);

            return Poinlist;
        }
        private void CreatBeams(Point Point1,Point Point2,String Profile)
        {
            tsm.Beam mybeams = new tsm.Beam(Point1,Point2);
            mybeams.Profile.ProfileString = Profile;
            mybeams.Finish = "Paint";
            mybeams.Insert();
        }
        private void GetvaluesFormDialog()
        {
            _Lenght = Data.Lenght;
            _Profile = Data.Profile;
            if (IsDefaultValue(_Lenght))
            {
                _Lenght = 2;
            }
            if (IsDefaultValue(_Profile))
            {
                _Profile = "HEA300";
            }
        }
        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                GetvaluesFormDialog();
                Point point1 = (Point)(Input[0]).GetInput();
                Point point2 = (Point)(Input[1]).GetInput();
                Point lengthvt = new Point(point2.X-point1.X,point2.Y-point1.Y,point2.Z-point1.Z);
                if (_Lenght>0)
                {
                    point2.X = _Lenght * lengthvt.X + point1.X;
                    point2.Y = _Lenght * lengthvt.Y + point1.Y;
                    point2.Z = _Lenght * lengthvt.Z + point1.Z;
                }
                var identifien = (Identifier)Input[2].GetInput();
                var part = new tsm.Model().SelectModelObject(identifien) as tsm.Part;
                CreatBeams(point1, point2, _Profile);
            }
            catch (Exception)
            {
            }
            return true;
        }
    }
}
