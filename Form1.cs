namespace RIE_UI
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double thickness;


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2(this);
            F2.ShowDialog();
            this.Close();
        }
    }
}