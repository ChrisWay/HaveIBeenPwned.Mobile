using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Cirrious.MvvmCross.ViewModels;
using HaveIBeenPwned.Mobile.Core.Models;
using HaveIBeenPwned.Mobile.Core.Services;

namespace HaveIBeenPwned.Mobile.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IApiService _apiService;       

        public FirstViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        private IMvxCommand _searchCommand;
        public IMvxCommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new MvxCommand(
                    async () => Breaches = await _apiService.GetAllBreachesForAccount(SearchText),
                    () => !string.IsNullOrWhiteSpace(SearchText)));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if(_searchText == value)
                    return;

                _searchText = value;
                RaisePropertyChanged(() => SearchText);
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        private List<Breach> _breaches;
        public List<Breach> Breaches
        {
            get { return _breaches; }
            private set
            {
                if(_breaches == value)
                    return;

                _breaches = value;
                RaisePropertyChanged(() => Breaches);
            }
        }
    }
}
