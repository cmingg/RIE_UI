namespace RIE_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double thickness;


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("두께 입력");
                }
                else
                {
                    Form2 F2 = new Form2(this);
                    F2.ShowDialog();

                    thickness = Convert.ToDouble(textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }
    }
}