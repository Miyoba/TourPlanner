﻿using System;
using System.Windows;
using System.Windows.Input;
using TourPlanner.BusinessLayer;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    class EditTourViewModel : ViewModelBase
    {

        private Window _window;
        private ITourPlannerFactory _tourPlannerFactory;

        private string _tourName;
        private string _tourDescription;
        private string _tourFromLocation;
        private string _tourToLocation;
        private int _tourDistance;

        private ICommand _editTourCommand;
        private ICommand _cancelTourCommand;
        

        public ICommand EditTourCommand => _editTourCommand ??= new RelayCommand(EditTour);
        public ICommand CancelTourCommand => _cancelTourCommand ??= new RelayCommand(CancelTour);

        public String TourName
        {
            get => _tourName;
            set{
                if (_tourName != value) {
                    _tourName = value;
                    RaisePropertyChangedEvent(nameof(TourName));
                }
            }
        }

        public String TourDescription
        {
            get => _tourDescription;
            set{
                if (_tourDescription != value) {
                    _tourDescription = value;
                    RaisePropertyChangedEvent(nameof(TourDescription));
                }
            }
        }

        public String TourFromLocation
        {
            get => _tourFromLocation;
            set{
                if (_tourFromLocation != value) {
                    _tourFromLocation = value;
                    RaisePropertyChangedEvent(nameof(TourFromLocation));
                }
            }
        }

        public String TourToLocation
        {
            get => _tourToLocation;
            set{
                if (_tourToLocation != value) {
                    _tourToLocation = value;
                    RaisePropertyChangedEvent(nameof(TourToLocation));
                }
            }
        }

        public int TourDistance
        {
            get => _tourDistance;
            set{
                if (_tourDistance != value) {
                    _tourDistance = value;
                    RaisePropertyChangedEvent(nameof(TourDistance));
                }
            }
        }

        public EditTourViewModel(Window window, Tour tour)
        {
            _window = window;
            _tourName = tour.Name;
            _tourDescription = tour.Description;
            _tourFromLocation = tour.FromLocation;
            _tourToLocation = tour.ToLocation;
            _tourDistance = tour.Distance;

            this._tourPlannerFactory = TourPlannerFactory.GetInstance();
        }

        private void EditTour(object commandParameter)
        {
            //TODO Edit Tour Information to DAO
            _window.Close();
        }

        private void CancelTour(object commandParameter)
        {
            _window.Close();
        }
    }
}
