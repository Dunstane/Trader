using System.Windows.Forms;

namespace TradeSystemSkelengton
{
    public partial class Form1 : Form
    {
        TradeSystem myTradeSystem;
        public Form1()
        {
            InitializeComponent();
            myTradeSystem = new TradeSystem();

            foreach (City x in myTradeSystem.giveCitiesList())
            {
                this.citieslb.Items.Add(x.giveName() + "XPOS:  " + x.givexLoc() + "   " + "YPOS:   " + x.giveyLoc());
            }
        }
    }
}