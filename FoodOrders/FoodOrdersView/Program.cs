using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace FoodOrdersView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new UnityContainer().AddExtension(new Diagnostic());
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDishStorage, DishStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorehouseStorage, StorehouseStorage>(new HierarchicalLifetimeManager()); 
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<DishLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<StorehouseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
