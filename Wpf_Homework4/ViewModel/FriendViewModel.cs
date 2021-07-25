using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Homework4.Model;
using Wpf_Homework4.Services;

namespace Wpf_Homework4.ViewModel
{
    class FriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IFileService _fileService;

        public ObservableCollection<Friend> Friends { get; set; }


        public FriendViewModel(IFileService fileService)
        {
            _fileService = fileService;

            Friends = new ObservableCollection<Friend>();
        }




        private Friend selectedFriend;
        public Friend SelectedFriend
        {
            get => selectedFriend;
            set 
            { 
                selectedFriend = value;
                OnPropertyChanged(nameof(SelectedFriend));
            }
        }



        #region Commands


        private Command _saveCommand;
        public Command SaveCommand
        {
            get 
            {
                return _saveCommand ?? (_saveCommand = new Command(obj => _fileService.SaveFriendsFile("friends.xml", Friends.Select(f => new Friend { FriendName = f.FriendName, TrustRating = f.TrustRating }).ToList()))); 
            }
        }



        private Command _loadCommand;
        public Command LoadCommand
        {
            get 
            { 
                return _loadCommand ?? (_loadCommand = new Command(obj =>
                {
                    var friends = _fileService.LoadFriendsFile("friends.xml");
                    Friends.Clear();
                    foreach (var f in friends)
                    {
                        Friends.Add(f);
                    }
                })); 
            }
        }



        private Command _addCommand;
        public Command AddCommand
        {
            get 
            {
                return _addCommand ?? (_addCommand = new Command(obj =>
                {
                    Friend f = new Friend();
                    Friends.Add(f);
                    SelectedFriend = f;
                }));
            }
        }


        #endregion



        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
