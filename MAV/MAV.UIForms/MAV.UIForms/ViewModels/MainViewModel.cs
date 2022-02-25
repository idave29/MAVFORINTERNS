﻿namespace MAV.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using MAV.Common.Models;
    using MAV.UIForms.Views;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel
    {
        private static MainViewModel instance;
        public TokenResponse Token { get; set; }
        public LoginViewModel Login { get; set; }
        public StatusesViewModel Statuses { get; set; }
        public OwnersViewModel Owners { get; set; }
        public MaterialTypesViewModel MaterialTypes { get; set; }
        public ApplicantTypesViewModel ApplicantTypes { get; set; }
        public InternsViewModel Interns { get; set; }
        public ApplicantsViewModel Applicants { get; set; }
        public AdministratorsViewModel Administrators { get; set; }
        public MaterialsViewModel Materials { get; set; }
        public LoansViewModel Loans { get; set; }
        public LoanDetailsViewModel LoanDetails { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public AddStatusViewModel AddStatus { get; set; }
        public ICommand AddStatusCommand { get { return new RelayCommand(GoStatusCommand); } }

        private async void GoStatusCommand()
        {
            this.AddStatus = new AddStatusViewModel();
            await App.Navigator.PushAsync(new AddStatusPage());
        }

        public MainViewModel()
        {
            instance = this;
            //this.Login = new LoginViewModel();
            LoadMenu();
        }

        private void LoadMenu()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "admin",
                    PageName = "AdministratorsPage",
                    Title = "Administrators"
                },
                new Menu
                {
                    Icon = "applicant",
                    PageName = "ApplicantPage",
                    Title = "Applicants"
                },
                new Menu
                {
                    Icon = "applicantType",
                    PageName = "ApplicantTypesPage",
                    Title = "Applicant Types"
                },
                new Menu
                {
                    Icon = "internt",
                    PageName = "InternsPage",
                    Title = "Interns"
                },
                new Menu
                {
                    Icon = "loans",
                    PageName = "LoansPage",
                    Title = "Loans"
                },
                new Menu
                {
                    Icon = "loansDetails",
                    PageName = "LoanDetailsPage",
                    Title = "Loan Details"
                },
                new Menu
                {
                    Icon = "material",
                    PageName = "MaterialsPage",
                    Title = "Materials"
                },
                new Menu
                {
                    Icon = "materialType",
                    PageName = "MaterialTypesPage",
                    Title = "Material Types"
                },
                new Menu
                {
                    Icon = "owner",
                    PageName = "OwnersPage",
                    Title = "Owners"
                },
                new Menu
                {
                    Icon = "status",
                    PageName = "StatusesPage",
                    Title = "Status"
                },
                new Menu
                {
                    Icon = "setup",
                    PageName = "SetupPage",
                    Title = "Setup"
                },
                new Menu
                {
                    Icon = "info",
                    PageName = "AboutPage",
                    Title = "About"
                },
                new Menu
                {
                    Icon = "exit",
                    PageName = "LoginPage",
                    Title = "Logout"
                }
            };
            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new
            MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
