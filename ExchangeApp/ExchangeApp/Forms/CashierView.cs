using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeApp.Entity;
using ExchangeApp.Presenter;
using ExchangeApp.View;

namespace ExchangeApp
{
    public partial class CashierView : Form, ICashierView
    {
        private List<Currency> currencies = new List<Currency>();

        public CashierView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCurrencies?.Invoke();
            targetCurrency.DataSource = currencies;
            targetCurrency.DisplayMember = "CurrencyName";
            userCurrency.DataSource = currencies;
            userCurrency.DisplayMember = "CurrencyName";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public User GetCashier()
        {
            throw new NotImplementedException();
        }

        public event Delegates.SetCashier SetCashier;
        public event Delegates.GetCurrencies GetCurrencies;

        private void button1_Click(object sender, EventArgs e)
        {
            SetCashier?.Invoke(new User(nameBox.Text, surnameBox.Text));
        }

        public void UpdateCurrencies(List<Currency> Currencies)
        {
            currencies.AddRange(Currencies);
        }

        private void userCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
