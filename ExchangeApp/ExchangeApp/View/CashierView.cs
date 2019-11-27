using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Windows.Forms;
using ExchangeApp.Entity;
using ExchangeApp.View;

namespace ExchangeApp
{
    public partial class CashierView : Form
    {
        public BindingList<Currency> targetCurrencies = new BindingList<Currency>();
        public BindingList<Currency> userCurrencies = new BindingList<Currency>();
        public User cashier = new User();

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

        public event ViewDelegates.GetCurrencies GetCurrencies;
        public event ViewDelegates.PerformOperation PerformOperation;

        private void button1_Click(object sender, EventArgs e)
        {
            cashier.Name = nameBox.Text;
            cashier.Surname = surnameBox.Text;
        }

        public void UpdateCurrencies(List<Currency> Currencies)
        {
            userCurrencies.Clear();
            Currencies.ForEach(currency => userCurrencies.Add(currency));
            targetCurrencies.Clear();
            Currencies.ForEach(currency => targetCurrencies.Add(currency));
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
            try
            {
                PerformOperation?.Invoke((Currency) userCurrency.SelectedItem, (Currency) targetCurrency.SelectedItem,
                    BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text),
                    OperationType.Purchase, cashier);
            }
            catch (Exception exception)
            {
                showMessageBox("Wrong format");
            }
        }


        private void userCurrency_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            PerformOperation?.Invoke((Currency) userCurrency.SelectedItem, (Currency) targetCurrency.SelectedItem,
                BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text),
                OperationType.Selling, cashier);
        }

        public void showMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        }
    }
}