﻿using System.Collections.Generic;
using System.Linq;
using TourPlanner.DataAccessLayer.Common;
using TourPlanner.DataAccessLayer.DAO;
using TourPlanner.Models;

namespace TourPlanner.BusinessLayer
{
    internal class TourPlannerFactoryImpl : ITourPlannerFactory
    {
        public IEnumerable<Tour> GetTours()
        {
            ITourDAO tourDAO = DALFactory.CreateTourDAO();
            return tourDAO.GetTours();
        }

        public IEnumerable<TourLog> GetTourLogs(Tour tour)
        {
            ITourLogDAO tourLogDAO = DALFactory.CreateTourLogDAO();
            return tourLogDAO.GetTourLogs(tour);
        }

        public IEnumerable<Tour> FindTour(IEnumerable<Tour> tours, IEnumerable<Tour> found, string fieldName, string searchArg, bool caseSensitive = false)
        {
            searchArg = caseSensitive ? searchArg : searchArg.ToLower();
            return found.Concat(tours.Where(x => x.GetFieldValue(fieldName, caseSensitive).Contains(searchArg)));
        }

        public IEnumerable<TourLog> FindTourLog(IEnumerable<TourLog> tourLogs, IEnumerable<TourLog> found, string fieldName, string searchArg, bool caseSensitive = false)
        {
            searchArg = caseSensitive ? searchArg : searchArg.ToLower();
            return found.Concat(tourLogs.Where(x => x.GetFieldValue(fieldName, caseSensitive).Contains(searchArg)));
        }

        public IEnumerable<Tour> Search(string searchArg, bool caseSensitive = false) {
            IEnumerable<Tour> tours = GetTours();
            IEnumerable<Tour> found = new List<Tour>();

            if (searchArg != null)
            {
                found = FindTour(tours, found, "Name", searchArg, caseSensitive);
                found = FindTour(tours, found, "FromLocation", searchArg, caseSensitive);
                found = FindTour(tours, found, "ToLocation", searchArg, caseSensitive);
                found = FindTour(tours, found, "Description", searchArg, caseSensitive);
                found = FindTour(tours, found, "Distance", searchArg, caseSensitive);
            }

            return found.Distinct();

        }

        public IEnumerable<TourLog> SearchTourLog(Tour tour, string searchArg, bool caseSensitive = false)
        {
            IEnumerable<TourLog> tourLogs = GetTourLogs(tour);
            IEnumerable<TourLog> found = new List<TourLog>();
            if (searchArg != null)
            {
                found = FindTourLog(tourLogs, found, "DateTime", searchArg, caseSensitive);
                found = FindTourLog(tourLogs, found, "Report", searchArg, caseSensitive);
                found = FindTourLog(tourLogs, found, "Distance", searchArg, caseSensitive);
                found = FindTourLog(tourLogs, found, "TotalTime", searchArg, caseSensitive);
                found = FindTourLog(tourLogs, found, "Rating", searchArg, caseSensitive);
            }

            return found.Distinct();
            }

        public Tour AddTour(string tourName, string tourDescription, string tourFromLocation, string tourToLocation, int tourDistance)
        {
            ITourDAO tourDao = DALFactory.CreateTourDAO();
            return tourDao.AddNewTour(tourName, tourFromLocation, tourToLocation, tourDescription, tourDistance);
        }

        public TourLog AddTourLog(Tour tour, string dateTime, string report, int distance, string totalTime, int rating)
        {
            ITourLogDAO tourLogDao = DALFactory.CreateTourLogDAO();
            return tourLogDao.AddNewTourLog(tour, dateTime, report, distance, totalTime, rating);
        }

        public void DeleteTour(Tour tour)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTourLog(TourLog tourLog)
        {
            throw new System.NotImplementedException();
        }

        public Tour EditTour(Tour tour, string tourName, string tourDescription, string tourFromLocation, string tourToLocation,
            int tourDistance)
        {
            throw new System.NotImplementedException();
        }

        public TourLog EditTourLog(TourLog tourLog, string dateTime, string report, int distance, string totalTime, int rating)
        {
            throw new System.NotImplementedException();
        }
    }
}
