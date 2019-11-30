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
    public partial class CashierView : Form
    {
        public BindingList<Currency> targetCurrencies = new BindingList<Currency>();
        public BindingList<Currency> userCurrencies = new BindingList<Currency>();
        public User cashier = new User();
        public OperationType lastOperationType;

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
                if (BigInteger.Parse(userCurrencyBox.Text) < 0)
                {
                    showMessageBox("Wrong format");
                }

                PerformOperation?.Invoke((Currency) userCurrency.SelectedItem, (Currency) targetCurrency.SelectedItem,
                    BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text),
                    OperationType.Purchase, cashier);
                lastOperationType = OperationType.Purchase;
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
            try
            {
                if (BigInteger.Parse(userCurrencyBox.Text) < 0)
                {
                    showMessageBox("Wrong format");
                }

                PerformOperation?.Invoke((Currency) userCurrency.SelectedItem, (Currency) targetCurrency.SelectedItem,
                    BigInteger.Parse(userCurrencyBox.Text), new User(userNameBox.Text, userSurnameBox.Text),
                    OperationType.Selling, cashier);
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

        private void button3_Click(object sender, EventArgs e)
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
    }
}