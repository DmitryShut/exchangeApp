using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
using ExchangeApp.Entity;
using ExchangeApp.View;

namespace ExchangeApp
{
    public partial class CashierView : Form, ICashierView
    {
        public BindingList<Currency> targetCurrencies = new BindingList<Currency>();
        public BindingList<Currency> userCurrencies = new BindingList<Currency>();
        public User cashier = new User();
        public OperationType lastOperationType;

        public CashierView()
        {
            InitializeComponent();
        }

        public void SetupForm(object sender, EventArgs e)
        {
            GetCurrencies?.Invoke();
            targetCurrency.DataSource = targetCurrencies;
            targetCurrency.DisplayMember = "CurrencyName";
            userCurrency.DataSource = userCurrencies;
            userCurrency.DisplayMember = "CurrencyName";
        }

        public event ViewDelegates.GetCurrencies GetCurrencies;
        public event ViewDelegates.PerformOperation PerformOperation;

        public void InputCashier(object sender, EventArgs e)
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

        public void Buy(object sender, EventArgs e)
        {
            try
            {
                if (BigInteger.Parse(userCurrencyBox.Text) < 0)
                {
                    showMessageBox("Wrong format");
                }

                PerformOperation?.Invoke((Currency) userCurrency.SelectedItem, (Currency) targetCurrency.SelectedItem,
                    BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text),
                    OperationType.Purchase, new User(nameBox.Text, surnameBox.Text));
                lastOperationType = OperationType.Purchase;
            }
            catch (Exception exception)
            {
                showMessageBox("Wrong format");
            }
        }

        public void Sell(object sender, EventArgs e)
        {
            try
            {
                if (BigInteger.Parse(userCurrencyBox.Text) < 0)
                {
                    showMessageBox("Wrong format");
                }

                PerformOperation?.Invoke((Currency) userCurrency.SelectedItem, (Currency) targetCurrency.SelectedItem,
                    BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text),
                    OperationType.Selling, new User(nameBox.Text, surnameBox.Text));
                lastOperationType = OperationType.Selling;
            }
            catch (Exception exception)
            {
                showMessageBox("Wrong format");
            }
        }

        public void showMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        }

        public void GetBill(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine($"Кассир {cashier.ToString()}");
                    sw.WriteLine($"Покупатель {userNameBox.Text} {userSurnameBox.Text}");
                    sw.WriteLine($"Покупатель {userNameBox.Text} {userSurnameBox.Text}");
                    string action = lastOperationType.Equals(OperationType.Purchase) ? "Купил" : "Продал";
                    string firstAmount = lastOperationType.Equals(OperationType.Purchase) ? targetCurrencyBox.Text : userCurrencyBox.Text;
                    string firstCurrency = lastOperationType.Equals(OperationType.Purchase) ? ((Currency) targetCurrency.SelectedItem).CurrencyName : ((Currency) userCurrency.SelectedItem).CurrencyName;
                    string secondAmount = lastOperationType.Equals(OperationType.Selling) ? targetCurrencyBox.Text : userCurrencyBox.Text;
                    string secondCurrency = lastOperationType.Equals(OperationType.Selling) ? ((Currency) targetCurrency.SelectedItem).CurrencyName : ((Currency) userCurrency.SelectedItem).CurrencyName;
                    sw.WriteLine($"{action} {firstAmount} {firstCurrency} за {secondAmount} {secondCurrency}");
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }
    }
}