using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var balance = db.TblBank.Sum(x => x.BankBalance);
            lblTotalBalance.Text = balance.ToString();
            var amount = db.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault().ToString();
            lblLastProcess.Text = amount.ToString()+ "₺";

            //chart1
            var bankData = db.TblBank.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach(var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //chart2
            var billData = db.TblBill.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = SeriesChartType.Pie;
            
            foreach(var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            lblBillTitle.Text = count.ToString();
            if(count %4 == 1)
            {
                var bill = db.TblBill.Where(x => x.BillTitle == "Elektrik Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = bill.ToString() + "₺";
                lblBillTitle.Text = "Elektrik Faturası";
            }
            if (count % 4 == 2)
            {
                var bill = db.TblBill.Where(x => x.BillTitle == "Kömür Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = bill.ToString() + "₺";
                lblBillTitle.Text = "Kömür Faturası";
            }
            if (count % 4 == 3)
            {
                var bill = db.TblBill.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = bill.ToString() + "₺";
                lblBillTitle.Text = "Su Faturası";
            }
            if (count % 4 == 0)
            {
                var bill = db.TblBill.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = bill.ToString() + "₺";
                lblBillTitle.Text = "Doğalgaz Faturası";
            }
        }
    }
}
