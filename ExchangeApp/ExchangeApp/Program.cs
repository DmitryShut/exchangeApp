using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeApp.Entity;
using ExchangeApp.Model;
using ExchangeApp.Model.Implementations;
using ExchangeApp.Presenter;
using ExchangeApp.Presenter.Implementations;
using ExchangeApp.Repository;
using ExchangeApp.View;
using Ninject;

namespace ExchangeApp
{
    static class Program
    {
        static Ninject.StandardKernel kernel = new StandardKernel();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            kernel.Bind<CashierView>()
                .ToConstant(new CashierView())
                .InSingletonScope();
            kernel.Bind<AdminView>()
                .ToConstant(new AdminView())
                .InSingletonScope();
            kernel.Bind<IRepository<Operation, DateTime>>()
                .ToConstant(new Repository<Operation, DateTime>())
                .InSingletonScope();
            kernel.Bind<IRepository<Currency, string>>()
                .ToConstant(new Repository<Currency,string>())
                .InSingletonScope();
            kernel.Bind<CurrencyService>()
                .ToConstant(new CurrencyService(kernel.Get<IRepository<Currency, string>>()))
                .InSingletonScope();
            kernel.Bind<OperationService>()
                .ToConstant(new OperationService(kernel.Get<IRepository<Operation, DateTime>>()))
                .InSingletonScope();
            kernel.Bind<CashierPresenter>()
                .ToConstant(new CashierPresenter(
                    kernel.Get<CashierView>(),
                    kernel.Get<CurrencyService>(),
                    kernel.Get<OperationService>()))
                .InSingletonScope();
            kernel.Bind<AdminPresenter>()
                .ToConstant(new AdminPresenter(
                    kernel.Get<AdminView>(),
                    kernel.Get<CurrencyService>(),
                    kernel.Get<OperationService>()))
                .InSingletonScope();
            Application.Run(FormManager.Current);
        }

        class FormManager : ApplicationContext
        {
            private static Lazy<FormManager> _current = new Lazy<FormManager>();
            public static FormManager Current => _current.Value;

            private void onFormClosed(object sender, EventArgs e)
            {
                if (Application.OpenForms.Count == 0)
                {
                    ExitThread();
                }
            }

            public FormManager()
            {
                var f1 = (Form) kernel.Get<CashierView>();
                f1.FormClosed += onFormClosed;
                f1.Show();
                var f2 = (Form) kernel.Get<AdminView>();
                f2.FormClosed += onFormClosed;
                f2.Show();
            }
        }
    }
}