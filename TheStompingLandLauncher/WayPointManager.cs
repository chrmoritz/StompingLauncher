using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TheStompingLandLauncher
{
    public partial class WayPointManager : Form
    {
        private mainForm mf = new mainForm();
        
        public WayPointManager()
        {
            InitializeComponent();
        }

        private void BWayPointAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TBwayPointName.Text) || TBwayPointName.Text.Length < 5)
            {
                MessageBox.Show(GlobalStrings.InvalidWayPointNameBody, GlobalStrings.InvalidWayPointNameHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double x, y, z;
            int yaw;
            if (!Double.TryParse(TBwayPointX.Text, out x) || !Double.TryParse(TBwayPointY.Text, out y) || !Double.TryParse(TBwayPointZ.Text, out z) || !int.TryParse(TBwayPointYaw.Text, out yaw))
            {
                MessageBox.Show(GlobalStrings.InvalidPositionBody, GlobalStrings.InvalidPositionHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<WayPoint> wps = (List<WayPoint>)DGVwayPoints.DataSource;
            wps.Add(new WayPoint(TBwayPointName.Text, x, y, z, yaw));
            DGVwayPoints.DataSource = null;
            DGVwayPoints.DataSource = wps;
        }

        private void BwayPointRemove_Click(object sender, EventArgs e)
        {
            List<WayPoint> wps = (List<WayPoint>)DGVwayPoints.DataSource;
            wps.RemoveAt(DGVwayPoints.CurrentRow.Index);
            DGVwayPoints.DataSource = null;
            DGVwayPoints.DataSource = wps;
        }

        private void BwayPointsRestore_Click(object sender, EventArgs e)
        {
            List<WayPoint> wps = (List<WayPoint>)DGVwayPoints.DataSource;
            bool german = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "de";
            wps.Add(new WayPoint(german ? "Wasserfallhöhle" : "Waterfall cave", 89.725906, -34004.398438, 113.925491, 10833));
            wps.Add(new WayPoint(german ? "Große Wasserhöhle Eingang" : "big water cave entrance", -48754.703125, -8867.308594, 1724.750244, 17271));
            wps.Add(new WayPoint(german ? "Große Wasserhöhle Ausgang" : "big water cave exit", -35461.242188, -21397.582031, 918.003479, 10137));
            wps.Add(new WayPoint(german ? "Vulkan" : "vulcano", -19371.386719, 21350.605469, 5841.007813, -19733));
            wps.Add(new WayPoint(german ? "Vulkanhöhle Eingang" : "vulcano cave entrance", -22653.009766, 23101.542969, 3110.780518, 17315));
            wps.Add(new WayPoint(german ? "Südlicher See" : "southern lake", 21226.568359, 28516.144531, 913.588501, 14213));
            wps.Add(new WayPoint(german ? "Westliche Flussmündung" : "western river mouth", 46529.703125, -19490.609375, 151.390274, 5135));
            DGVwayPoints.DataSource = null;
            DGVwayPoints.DataSource = wps;
        }

        private void validateDouble(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void validateNegNumberInput(object sender, KeyPressEventArgs e)
        {
            int i;
            TextBox tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar) && !int.TryParse(tb.Text + e.KeyChar, out i))
            {
                e.Handled = true;
            }
        }
    }
}
