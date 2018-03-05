using System;
using System.Windows.Forms;

namespace Demo
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();

            txtNum.KeyUp += TxtNum_KeyUp;
        }

        private void TxtNum_KeyUp(object sender, EventArgs e)
        {
            lblResult.Text = $"Result:  {txtNum.MathParserResult}";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtText.Value);
            MessageBox.Show(txtNum.Value);
        }
    }
}
