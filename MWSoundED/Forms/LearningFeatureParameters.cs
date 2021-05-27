using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWSoundED
{
    public partial class LearningFeatureParameters : Form
    {
        public LearningFeatureParameters()
        {
            InitializeComponent();

            comboBands.SelectedIndex = 0;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
