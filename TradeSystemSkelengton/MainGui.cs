using System.Windows.Forms;

namespace TradeSystemSkelengton
{
    public partial class MainGui : Form
    {
        TradeSystem myTradeSystem;
        public MainGui()
        {
            InitializeComponent();
            myTradeSystem = new TradeSystem();


        }

        /// <summary>
        /// test bt that poplates the the listbox with a dummy city
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestPopulatebt_Click(object sender, System.EventArgs e)
        {
            this.citieslb.Items.Clear();
            foreach (City x in myTradeSystem.giveCitiesList())
            {
                this.citieslb.Items.Add(x.giveName() + "XPOS:  " + x.givexLoc() + "   " + "YPOS:   " + x.giveyLoc());
            }
        }
    }
}