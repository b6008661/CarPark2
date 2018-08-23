using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarPark
{
    public partial class Form1 : Form
    {
        private SecureMachine secureMachine;
        private PayMachine payMachine;
        private AdminMachine adminMachine;
        //private DoorMachine doorMachine;
        // private DiscountMachine discountMachine;
        private Entry entryMachine;
        private Exit exitMachine;
        private ActiveCoins activeCoins;
        private List<Bay> bays;
        private PedDoor pedDoor;
        private int coinCode;
        private int availableSpaces;
        private SeasonTickets seasonTickets;
        private int numberCars;


        public Form1()
        {
            InitializeComponent();
            activeCoins = new ActiveCoins();
            seasonTickets = new SeasonTickets();
            entryMachine = new Entry(activeCoins);
            exitMachine = new Exit(activeCoins);
            payMachine = new PayMachine(activeCoins);
            pedDoor = new PedDoor();
            bays = new List<Bay>();
            adminMachine = new AdminMachine();
            availableSpaces = bays.Count();
            lblSpaces.Text = availableSpaces.ToString();
            lblPrice.Text = payMachine.GetAmount().ToString();
            numberCars = 0;
        }

        private void btnDispenseCoin_Click(object sender, EventArgs e)
        {
            int coinID = entryMachine.DispenseCoin();
            lblEntry.Text = "Please enter the car park.";
            lblCoinCode.Text = "Your coin code is: " + coinID;
            btnEnter.Enabled = true;
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            entryMachine.RaiseEntryBarrier();
            entryMachine.LowerEntryBarrier();
            lblEntry.Text = entryMachine.ResetWelcome();
            lblCoinCode.Text = entryMachine.ResetCoinID();
            btnEnter.Enabled = false;
            numberCars = numberCars + 1;
        }

        private void btnLock1_Click(object sender, EventArgs e)
        {
            int bayNo = Int32.Parse(txtBayNo.Text);
            string password = txtPassword.Text;
            if (bays[bayNo + 1].CarIsInBay())
            {

                bays[bayNo + 1].SecureBay(password);
                lblSecureMachine.Text = "Your bay is now secure.";
                pedDoor.Open();
            }
            else
            {
                lblSecureMachine.Text = "Your car is not in the bay. Please move it before proceeding.";
            }
            txtBayNo.Text = "";
            txtPassword.Text = "";

        }

        private void btnInsertCoin2_Click(object sender, EventArgs e)
        {
            coinCode = Int32.Parse(txtCoinDoor.Text);
            if (activeCoins.IsActive(coinCode))
            {
                pedDoor.Open();
            }
            txtCoinDoor.Text = "";
        }

        private void btnInsetCoin3_Click(object sender, EventArgs e)
        {
            coinCode = Int32.Parse(txtCoinPay.Text);
            if (activeCoins.IsActive(coinCode))
            {
                int amount = payMachine.CalculateAmountToPay();
                lblPayMachine.Text = "Amount to pay: £" + amount;
            }
            else
            {
                lblPayMachine.Text = "Not a valid chip coin";
            }
            txtCoinPay.Text = "";
            btnPay.Enabled = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            payMachine.Pay(coinCode);
            lblPayMachine.Text = "Thank you. Now unlock your bay.";
            btnUnlock.Enabled = true;
            btnPay.Enabled = false;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            int bayNo = Int32.Parse(txtBayNo2.Text);
            string password = txtPassword2.Text;
            if (bays[bayNo + 1].GetPassword() == password)
            {
                bays[bayNo + 1].UnlockBay();
                lblPayMachine.Text = "Your bay is now unlocked.";
            }
            else
            {
                lblPayMachine.Text = "Wrong combination. Try again.";
            }
            txtBayNo2.Text = "";
            txtPassword2.Text = "";
            btnUnlock.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            int coinCode = Int32.Parse(txtCoinExit.Text);
            if (activeCoins.HasPaid(coinCode))
            {
                lblExit.Text = "Enjoy the rest of your day!";
                activeCoins.RemoveCoin(coinCode);
                btnExit2.Enabled = true;
            }
            else
            {
                lblExit.Text = "Please pay before leaving.";
            }
            txtCoinExit.Text = "";
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            exitMachine.RaiseExitBarrier();
            exitMachine.LowerExitBarrier();
            lblExit.Text = exitMachine.Reset();
            btnExit2.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string password = txtAdminPassword.Text;

            if (user == adminMachine.GetUser() && password == adminMachine.GetPassword())
            {
                lblAdmin.Text = "You are now logged in.";
                txtSetPrice.Enabled = true;
                btnSetPrice.Enabled = true;
                txtSetBays.Enabled = true;
                btnSetBays.Enabled = true;
                btnEntryOpen.Enabled = true;
                btnEntryClose.Enabled = true;
                btnExitOpen.Enabled = true;
                btnExitClose.Enabled = true;
                btnDoorOpen.Enabled = true;
                btnDoorClose.Enabled = true;
                txtAddSeason.Enabled = true;
                btnSeasonTicket.Enabled = true;
                txtSetDiscount.Enabled = true;
                btnSetDiscount.Enabled = true;
            }
        }

        private void btnSetPrice_Click(object sender, EventArgs e)
        {
            int amount = Int32.Parse(txtSetPrice.Text);
            payMachine.SetPrice(amount);
            lblPrice.Text = amount.ToString();
        }

        private void btnSetBays_Click(object sender, EventArgs e)
        {
            int number = Int32.Parse(txtSetBays.Text);
            for (int i = 1; i <= number; i++)
            {
                bays.Add(new Bay(i + 1));
            }
            lblAdmin.Text = "Number of bays has been set to: " + number;
            txtSetBays.Text = "";
            int spaces = number - numberCars;
            lblSpaces.Text = spaces.ToString();
            //minus the bays already in use
            lstBays.DataSource = bays;
        }

        private void btnEntryOpen_Click(object sender, EventArgs e)
        {
            entryMachine.RaiseEntryBarrier();
            lblAdmin.Text = "Entry barrier is open.";
        }

        private void btnEntryClose_Click(object sender, EventArgs e)
        {
            entryMachine.LowerEntryBarrier();
            lblAdmin.Text = "Entry barrier is closed.";
        }

        private void btnExitOpen_Click(object sender, EventArgs e)
        {
            exitMachine.RaiseExitBarrier();
            lblAdmin.Text = "Exit barrier is open.";
        }

        private void btnExitClose_Click(object sender, EventArgs e)
        {
            exitMachine.LowerExitBarrier();
            lblAdmin.Text = "Exit barrier is closed.";
        }

        private void btnDoorOpen_Click(object sender, EventArgs e)
        {
            pedDoor.Open();
            lblAdmin.Text = "Pedestrian door is open.";
        }

        private void btnDoorClose_Click(object sender, EventArgs e)
        {
            pedDoor.Close();
            lblAdmin.Text = "Pedestrian door is closed.";
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            lblEntry.Text = entryMachine.Disable();
            btnDispenseCoin.Enabled = false;

            lblExit.Text = exitMachine.Disable();
            btnExit.Enabled = false;

            txtBayNo.Enabled = false;
            txtPassword.Enabled = false;
            btnLock.Enabled = false;
            lblSecureMachine.Text = secureMachine.Disable();
        }

        private void btnFire_Click(object sender, EventArgs e)
        {
            lblEntry.Text = entryMachine.Disable();
            btnDispenseCoin.Enabled = false;

            exitMachine.RaiseExitBarrier();

            pedDoor.Open();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDispenseCoin.Enabled = true;
            btnLock.Enabled = true;
            txtBayNo.Enabled = false;
            txtPassword.Enabled = false;

            pedDoor.Close();

            lblEntry.Text = "Please dispense a coin";
            lblSecureMachine.Text = "Please enter the details below";
            lblExit.Text = "Insert your coin";



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ticketID = Int32.Parse(txtAddSeason.Text);
            seasonTickets.AddTicket(ticketID);
            lstActiveTickets.DataSource = seasonTickets.GetList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int ticketID = Int32.Parse(txtRemove.Text);
            seasonTickets.RemoveTicket(ticketID);
            lstActiveTickets.DataSource = seasonTickets.GetList();
        }

        private void btnSeasonTicket_Click(object sender, EventArgs e)
        {
            int ticketID = Int32.Parse(txtSeasonTicket.Text);
            if (seasonTickets.FindTicket(ticketID))
            {
                btnUnlock.Enabled = true;
                btnPay.Enabled = true;
            }
            lblPayMachine.Text = "Now please unlock your bay.";
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            lblAdmin.Text = "Please log in";
            txtSetPrice.Enabled = false;
            btnSetPrice.Enabled = false;
            txtSetBays.Enabled = false;
            btnSetBays.Enabled = false;
            btnEntryOpen.Enabled = false;
            btnEntryClose.Enabled = false;
            btnExitOpen.Enabled = false;
            btnExitClose.Enabled = false;
            btnDoorOpen.Enabled = false;
            btnDoorClose.Enabled = false;
            txtAddSeason.Enabled = false;
            btnSeasonTicket.Enabled = false;
            txtSetDiscount.Enabled = false;
            btnSetDiscount.Enabled = false;
        }
    }
}
