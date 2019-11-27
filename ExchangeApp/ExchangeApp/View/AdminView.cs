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
using ExchangeApp.View;
using Ninject;

namespace ExchangeApp
{
    public partial class AdminView : Form
    {
        public BindingList<Currency> currencies = new BindingList<Currency>();
        public BindingList<Operation> Operations = new BindingList<Operation>();

        public AdminView()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            GetCurrencies?.Invoke();
            currenciesView.DataSource = typeof(List<Currency>);
            currenciesView.DataSource = currencies;
            currenciesView.CellValueChanged += currenciesView_CellValueChanged;
            operationsView.DataSource = typeof(List<Operation>);
            operationsView.DataSource = Operations;
        }

        public event ViewDelegates.GetCurrencies GetCurrencies;
        public event ViewDelegates.AddCurrency AddCurrency;

        public event ViewDelegates.FilterOperations FilterOperations;

        public void UpdateCurrencies(List<Currency> Currencies)
        {
            currencies.Clear();
            Currencies.ForEach(currency => currencies.Add(currency));
            currenciesView.Update();
            currenciesView.Refresh();
        }

        public void UpdateOperations(List<Operation> operations)
        {
            Operations.Clear();
            operations.ForEach(operation => Operations.Add(operation));
            operationsView.Update();
            operationsView.Refresh();
        }

        private void currenciesView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void currenciesView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AddCurrency?.Invoke((Currency)currenciesView.CurrentRow.DataBoundItem);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddCurrency?.Invoke(new Currency(nameBox.Text,
                    BigInteger.Parse(purchaseRateBox.Text),
                    BigInteger.Parse(sellRateBox.Text),
                    BigInteger.Parse(purchaseRateBox.Text),
                    BigInteger.Parse(sellLimitBox.Text)));
            }
            catch (Exception exception)
            {
                showMessageBox("Wrong format");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void filter_Click(object sender, EventArgs e)
        {
            FilterOperations?.Invoke(filterTextBox.Text);
        }
        
        public void showMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        }
    }
}