using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Settings : Form
    {
        // Listbox indexes
        int outlinePenColourIdx;
        int fillColourIdx;
        int penWidthIdx;
        public Settings()
        {
            InitializeComponent();
            
            // Zero out all of the indexes
            listBoxOutlinePenC.SelectedIndex = listBoxFillC.SelectedIndex = listBoxPenWidth.SelectedIndex = 0;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Save the state of the listboxes
            outlinePenColourIdx = listBoxOutlinePenC.SelectedIndex;
            fillColourIdx = listBoxFillC.SelectedIndex;
            penWidthIdx = listBoxPenWidth.SelectedIndex;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            // Return the last state of the listboxes
            listBoxOutlinePenC.SelectedIndex = outlinePenColourIdx;
            listBoxFillC.SelectedIndex = fillColourIdx;
            listBoxPenWidth.SelectedIndex = penWidthIdx;
        }
    }
}
