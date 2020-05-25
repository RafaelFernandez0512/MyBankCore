using CoreApp.Models;
using CoreApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoreApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Data> Datas { get; set; }
        public ObservableCollection<Data> DataTransaction { get; set; }
        public HomePageViewModel(INavigationService navigationServices, IPageDialogService dialogService, IApiCore apiCore) : base(navigationServices, dialogService, apiCore)
        {
            Datas = new ObservableCollection<Data>()
            {

                new Data
                {
                    Name = "Clientes",
                    Quantity = 200
                },
                new Data
                {
                    Name = "Empleados",
                    Quantity = 100
                },
                new Data
                {
                    Name = "Transaciones",
                    Quantity = 2000
                },
            };
            DataTransaction = new ObservableCollection<Data>()
            {

                new Data
                {
                    Date_Time = DateTime.Now,
                    Quantity = 200
                },
                new Data
                {
                   Date_Time = DateTime.Now,
                    Quantity = 100
                },
                new Data
                {
                   Date_Time = DateTime.Now,
                    Quantity = 2000
                },
            };
        }
    }
}
