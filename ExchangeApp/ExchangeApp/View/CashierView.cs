using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using ExchangeApp.Entity;
using ExchangeApp.View;

namespace ExchangeApp
{
    public partial class CashierView : Form, ICashierView
    {
        public List<Currency> targetCurrencies = new List<Currency>();
        public List<Currency> userCurrencies = new List<Currency>();

        public CashierView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCurrencies?.Invoke();
            targetCurrency.DataSource = targetCurrencies;
            targetCurrency.DisplayMember = "CurrencyName";
            userCurrency.DataSource = userCurrencies;
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
        public event Delegates.BuyCurrency BuyCurrency;
        public event Delegates.SellCurrency SellCurrency;

        private void button1_Click(object sender, EventArgs e)
        {
            SetCashier?.Invoke(new User(nameBox.Text, surnameBox.Text));
        }

        public void UpdateCurrencies(List<Currency> Currencies)
        {
            userCurrencies.AddRange(Currencies);
            targetCurrencies.AddRange(Currencies);
        }

        public void SetTargetCurrency(BigInteger targetCurrency)
        {
            targetCurrencyBox.Text = targetCurrency.ToString();
        }

        private void userCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuyCurrency?.Invoke((Currency)userCurrency.SelectedItem, (Currency)targetCurrency.SelectedItem, BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text));
        }


        private void userCurrency_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}
