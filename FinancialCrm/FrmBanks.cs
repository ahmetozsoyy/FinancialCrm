using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            var ziraatBalance = db.TblBank.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBalance = db.TblBank.Where(x => x.BankTitle == "Vakıfbank").Select(y => y.BankBalance).FirstOrDefault();
            var isBalance = db.TblBank.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBalance.Text = ziraatBalance.ToString() + "₺";
            lblVakifBalance.Text = vakifBalance.ToString() + "₺";
            lblIsBalance.Text = isBalance.ToString() + "₺";

            var process1 = db.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = process1.Description + " " + process1.ProcessType + " " + process1.ProcessDate;
            var process2 = db.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = process2.Description + " " + process2.ProcessType + " " + process2.ProcessDate;
            var process3 = db.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = process3.Description + " " + process3.ProcessType + " " + process3.ProcessDate;
            var process4 = db.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = process1.Description + " " + process4.ProcessType + " " + process4.ProcessDate;
            var process5 = db.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = process5.Description + " " + process5.ProcessType + " " + process5.ProcessDate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }
    }
}
