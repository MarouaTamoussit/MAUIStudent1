﻿
using MAUIStudent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIStudent.ViewModel
{
    public class AccueilViewModel
    {
        
            public ICommand StudentCommand { private set; get; }
            public ICommand AbsenceCommand { private set; get; }
            private INavigation Navigation;

            public AccueilViewModel(INavigation navigation)
            {
                Navigation = navigation;
                StudentCommand = new Command(OnStudentCommand);
                AbsenceCommand = new Command(OnAbsenceCommand);
            }

            private async void OnStudentCommand(object obj)
            {
                await Navigation.PushModalAsync(new AddStudentDetail());
            }

            private async void OnAbsenceCommand(object obj)
            {
                await Navigation.PushModalAsync(new AbsenceStudent());
            }
        }
    }

