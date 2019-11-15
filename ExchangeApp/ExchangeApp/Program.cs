using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeApp.Model;
using ExchangeApp.Model.Implementations;
using ExchangeApp.Presenter;
using ExchangeApp.Presenter.Implementations;
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
            kernel.Bind<ICashierService>()
                .ToConstant(new CashierService())
                .InSingletonScope();
            kernel.Bind<ICashierView>()
                .ToConstant(new CashierView())
                .InSingletonScope();
            kernel.Bind<IAdminView>()
                .ToConstant(new AdminView())
                .InSingletonScope();
            kernel.Bind<ICurrencyService>()
                .ToConstant(new CurrencyService())
                .InSingletonScope();
            kernel.Bind<IOperationService>()
                .ToConstant(new OperationService())
                .InSingletonScope();
            kernel.Bind<ICashierPresenter>()
                .ToConstant(new CashierPresenter(
                    kernel.Get<ICashierService>(),
                    kernel.Get<ICashierView>(),
                    kernel.Get<ICurrencyService>(),
                    kernel.Get<IOperationService>()))
                .InSingletonScope();
            kernel.Bind<IAdminPresenter>()
                .ToConstant(new AdminPresenter(
                    kernel.Get<IAdminView>(),
                    kernel.Get<ICurrencyService>(),
                    kernel.Get<IOperationService>()))
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
                var f1 = (Form) kernel.Get<ICashierView>();
                f1.FormClosed += onFormClosed;
                f1.Show();
                var f2 = (Form) kernel.Get<IAdminView>();
                f2.FormClosed += onFormClosed;
                f2.Show();
            }
        }
    }
}