using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Weatherapp.Models;
using Weatherapp.Services;
using Weatherapp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Views;
using System.Data.Common;
using System.Windows.Input;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using System.Linq;
using System.Collections.Generic;

namespace Weatherapp.ViewModel
{
    public partial class DataViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        [ObservableProperty]
        List<ToDoModel> toDoList;

        [ObservableProperty]
        ToDoModel todo;

        [ObservableProperty]
        ToDoModel toSaveOnDB;
        [ObservableProperty]
        ToDoModel toDeleteOnDB;

        private readonly Services.DbConnection _dbConnection;
        private readonly ObservableCollection<ToDoModel> models;
        //public ICommand DeleteCommand { get; }


        public DataViewModel(Services.DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            toDoList = new List<ToDoModel>();
            toSaveOnDB = new ToDoModel();
            todo = new ToDoModel();
            //Todo.Id = 0;
            //models = new ObservableCollection<ToDoModel>();
            //DeleteCommand = new AsyncRelayCommand(DeleteModelAsync);
            GetInitalDataCommand.Execute(null);

        }

        [RelayCommand]
        private async void GetInitalData()
        {

            var toDoListBase = await _dbConnection.GetItemsAsync();
            ToDoList = new List<ToDoModel>(toDoListBase);
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
                    var todoItem = ToDoList.Where(x => x.Id == res2).FirstOrDefault();
                    Console.WriteLine(todoItem);

                    ToDoList.Remove(todoItem);
                    todoItem.Name = null;
                    await _dbConnection.DeleteItemAsync(Todo);
                    Console.WriteLine("1");


                }
            }
        }
        [RelayCommand]
        public async Task DeleteOnDb(ToDoModel todo)
        {
            ToDoList.Remove(todo);
            await _dbConnection.DeleteItemAsync(todo);
        }
        [RelayCommand]
        private async void SaveOnDb()
        {

            if (ToSaveOnDB.Name == null)
                return;
            Console.WriteLine(ToSaveOnDB.Name);
            ToDoList.Add(ToSaveOnDB);

            await _dbConnection.SaveItemAsync(ToSaveOnDB);


        }
       
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

            Todo = query["Todo"] as ToDoModel;
            OnPropertyChanged("Todo");
            if (query.ContainsKey("IdUser") && Todo.Id == -3)
            {
                Console.WriteLine(Todo.Ok);
                var id = (int)query["IdUser"];
                var todoItem = ToDoList.Where(x => x.Id == id).FirstOrDefault();
                ToDoList.Remove(todoItem);
                Console.WriteLine("1");
                //el=Preferences.Default.Get("huh", 2);
                Console.WriteLine("Before " + query);
                //query = null;
                query = new Dictionary<string, object>();
                Console.WriteLine("After " + query);

            }
            if (query.ContainsKey("NameUser") && Todo.Id == -5)
            {

                Console.WriteLine(Todo.Ok);

                var element = (ToDoModel)query["NameUser"];

                if (element == null)
                    return;
                ToSaveOnDB = element;

                Console.WriteLine("2");
                Console.WriteLine("Before " + query);

                //SaveOnDbCommand.Execute(null);
                ToDoList.Add(element);
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
