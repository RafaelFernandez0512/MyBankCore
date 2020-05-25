using CoreApp.Models;
using CoreApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
   public class RegisterEmployeePageViewModel : BaseViewModel
    {
        public ClsEmployee Employee { get; set; } = new ClsEmployee();
        public DelegateCommand SaveEmployeeCommand { get; set; }
        public List<Schedule> Schedules { get; set; }
        private Schedule selectSchedule; 
        public List<EmployeeType> EmployeeTypes { get; set; }
        private EmployeeType selectEmployeeType;
        public List<Gender> Genders { get; set; }
        private Gender selectGender;

        public Gender SelectGender
        {
            get { return selectGender; }
            set { selectGender = value; }
        }

        public Schedule SelectSchedule
        {
            get { return selectSchedule; }
            set { selectSchedule = value; }
        }

        public EmployeeType SelectEmployeeType
        {
            get { return selectEmployeeType; }
            set { selectEmployeeType = value; }
        }

        public RegisterEmployeePageViewModel(INavigationService inavigationServices, IPageDialogService dialogService, ApiCore apiCore) : base(inavigationServices, dialogService, apiCore)
        {
            Genders = new List<Gender>()
            {
                new Gender()
                {
                    Name = "Masculino"
                },

                new Gender()
                {
                    Name = "Femenino"
                },
            };

            Schedules = new List<Schedule>()
            {
                new Schedule()
                {
                    ScheduleTime = "9:00 AM a 6:00 PM"
                },

                new Schedule()
                {
                    ScheduleTime = "8:00 AM a 5:00 PM"
                },

                new Schedule()
                {
                    ScheduleTime = "8:00 AM a 1:00 PM"
                },
            };

            EmployeeTypes = new List<EmployeeType>()
            {
                new EmployeeType()
                {
                    EmployeeTypeName = "Admin"
                },
                new EmployeeType()
                {
                    EmployeeTypeName = "Gerente"
                },
                new EmployeeType()
                {
                    EmployeeTypeName = "SubGerente"
                },
                new EmployeeType()
                {
                    EmployeeTypeName = "Oficial de servicio al cliente"
                },
                new EmployeeType()
                {
                    EmployeeTypeName = "Cajero"
                },
                new EmployeeType()
                {
                    EmployeeTypeName = "Secretaria"
                },
                new EmployeeType()
                {
                    EmployeeTypeName = "Encargado administrativo"
                },
            };

            SaveEmployeeCommand = new DelegateCommand(async () =>
            {
                Employee.Sexo = SelectGender.Name;
                Employee.Horario = SelectSchedule.ScheduleTime;
                Employee.Puesto = SelectEmployeeType.EmployeeTypeName;
                await InsertEmployee(Employee);

            });
        }

        async Task InsertEmployee(ClsEmployee employee)
        {
            try
            {
                await apiCore.PostEmployee(employee);
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("There was an error", $"{ex.Message}", "Ok");
            }
        }

    }
}
