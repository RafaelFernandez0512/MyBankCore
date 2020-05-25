using CoreApp.Helpers;
using CoreApp.Models;
using CoreApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class EmployeesPageViewModel : BaseViewModel
    {
        ClsEmployee selectedEmployee;
        public ObservableCollection<ClsEmployee> Employees { get; set; }
        public DelegateCommand LoadEmployeeList { get; set; }
        public DelegateCommand GoToRegisterEmployeePageCommand { get; set; }

        public ClsEmployee SelectedEmployee 
        {
            get { return selectedEmployee; }
            set 
            { 
                selectedEmployee = value;
                if (selectedEmployee != null)
                    DisplaySelectedEmployee();
            }
        }


        public EmployeesPageViewModel(INavigationService navigationServices, IPageDialogService dialogService, IApiCore apiCore) : base(navigationServices, dialogService, apiCore)
        {
            LoadEmployeeList = new DelegateCommand(async () =>
            {
                await LoadEmployees();
            });
            LoadEmployeeList.Execute();

            GoToRegisterEmployeePageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(ConfigPage.RegisterEmployeePage);
            });
        }

        public async void DisplaySelectedEmployee()
        {
            string answer = await dialogService.DisplayActionSheetAsync($"{TextConstants.TitleText}",$"{TextConstants.SeeInfo}",$"{TextConstants.EditOptionText}");

            if (answer == TextConstants.SeeInfo)
            {
                await dialogService.DisplayAlertAsync("Empleado:", $"Nombre: {SelectedEmployee.Name} \nApellidos: {SelectedEmployee.LastName} \nPuesto: {SelectedEmployee.Position} \nEmail: {SelectedEmployee.Email}", "OK");
            }

            else if (answer == TextConstants.EditOptionText)
            {
                await navigationService.NavigateAsync($"{ConfigPage.NavigationPage}{ConfigPage.RegisterEmployeePage}");
            }
            

        }

        async Task LoadEmployees()
        {
            var employee = await apiCore.GetEmployee();
            Employees = new ObservableCollection<ClsEmployee>(employee);
        }
    }
}
