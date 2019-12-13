using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExchangeApp.Entity;

namespace ExchangeApp.View
{
    public interface IAdminView
    {
        void SetUp(object sender, EventArgs e);

        event ViewDelegates.GetCurrencies GetCurrencies;
        event ViewDelegates.AddCurrency AddCurrency;

        event ViewDelegates.FilterOperations FilterOperations;

        void UpdateCurrencies(List<Currency> Currencies);

        void UpdateOperations(List<Operation> operations);

        void ChangeCurrency(object sender, DataGridViewCellEventArgs e);

        void AddNewCurrency(object sender, EventArgs e);

        void Filter(object sender, EventArgs e);

        void showMessageBox(string message);
    }
}