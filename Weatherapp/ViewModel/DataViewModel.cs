using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Weatherapp.Models;
using Weatherapp.Services;
using Weatherapp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Views;

namespace Weatherapp.ViewModel
{
    public partial class DataViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        [ObservableProperty]
        List<ToDoModel> toDolist;

        [ObservableProperty]
        ToDoModel todo2;

        [ObservableProperty]
        ToDoModel toSaveOnDB;
        [ObservableProperty]
        ToDoModel toDeleteOnDB;

        private readonly DbConnection _dbConnection;
        private readonly ObservableCollection<ToDoModel> models;
        //public ICommand DeleteCommand { get; }


        public DataViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            toDolist = new List<ToDoModel>();
            toSaveOnDB = new ToDoModel();
            todo2 = new ToDoModel();
            //models = new ObservableCollection<ToDoModel>();
            //DeleteCommand = new AsyncRelayCommand(DeleteModelAsync);
            GetInitalDataCommand.Execute(null);

        }

        [RelayCommand]
        private async void GetInitalData()
        {
            ToDolist = await _dbConnection.GetItemsAsync();
        }

        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;

        

        [RelayCommand]
        private async void GoToMoreInfo(ToDoModel todo)
        {
            var popup = new EditItems(todo);

            var element = await Shell.Current.ShowPopupAsync(popup);
            Console.WriteLine(element);
            if (element is int res2)
            {
                Console.WriteLine("#$$:");
                if (element is not 0)
                {

                    Console.WriteLine("###@@");
                    Console.WriteLine(res2);
                    //var id = (int)query["IdUser"];
                    // Console.WriteLine(id);
                    var todoItem = ToDolist.Where(x => x.Id == res2).FirstOrDefault();
                    Console.WriteLine(todoItem);

                    ToDolist.Remove(todoItem);
                    todoItem.Name = null;
                    await _dbConnection.DeleteItemAsync(Todo2);
                    Console.WriteLine("1");


                }
            }
        }
        [RelayCommand]
        public async Task DeleteOnDb(ToDoModel todo)
        {
            ToDolist.Remove(todo);
            await _dbConnection.DeleteItemAsync(todo);
        }
        [RelayCommand]
        private async void SaveOnDb()
        {

            await _dbConnection.SaveItemAsync(ToSaveOnDB);


        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Todo2 = query["Todo"] as ToDoModel;
            OnPropertyChanged("Todo");

            if (query.ContainsKey("IdUser") && Todo2.Id == -3)
            {
                Console.WriteLine(Todo2.Ok);
                var id = (int)query["IdUser"];
                var todoItem = ToDolist.Where(x => x.Id == id).FirstOrDefault();
                ToDolist.Remove(todoItem);
                Console.WriteLine("1");
                //el=Preferences.Default.Get("huh", 2);
                Console.WriteLine("Before " + query);
                //query = null;
                query = new Dictionary<string, object>();
                Console.WriteLine("After " + query);

            }
            if (query.ContainsKey("NameUser") && Todo2.Id == -5)
            {

                Console.WriteLine(Todo2.Ok);

                var element = (ToDoModel)query["NameUser"];

                if (element == null)
                    return;
                ToSaveOnDB = element;

                Console.WriteLine("2");
                Console.WriteLine("Before " + query);

                //SaveOnDbCommand.Execute(null);
                ToDolist.Add(element);
                //query = null;
                query = new Dictionary<string, object>();
                Console.WriteLine("After " + query);
                ToSaveOnDB = null;
                //element.Name = null;
                //await _dbConnection.SaveItemAsync(element);


                //ToDolist.Add(element);
            }



        }
       

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

}
