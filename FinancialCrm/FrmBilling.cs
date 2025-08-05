using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillNew_Click(object sender, EventArgs e)
        {
            TblBill addBill = new TblBill();
            addBill.BillTitle = txtBillTitle.Text;
            addBill.BillAmount = decimal.Parse(txtBillAmount.Text);
            addBill.BillPeriod = txtBillPeriod.Text;
            db.TblBill.Add(addBill);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde eklendi","Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removedValue = db.TblBill.Find(id);
            db.TblBill.Remove(removedValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var updatedValue = db.TblBill.Find(id);
            updatedValue.BillTitle = txtBillTitle.Text;
            updatedValue.BillAmount = decimal.Parse(txtBillAmount.Text);
            updatedValue.BillPeriod = txtBillPeriod.Text;
            
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Close();
        }
    }
}
