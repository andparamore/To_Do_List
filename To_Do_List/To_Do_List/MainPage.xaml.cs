using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace To_Do_List
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection <ToDo> ToDos { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ToDos = new ObservableCollection <ToDo>{};
            this.BindingContext = this;
        }

        private void AddItem(object sender, EventArgs e)
        {
            if (do_entry.Text != "")
            {
                ToDos.Add(new ToDo { Title = do_entry.Text, Date_Create = datePicker.Date.ToString("dd/MM/yyyy") });
                do_entry.Text = "";
            }
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            bool result;
            ToDo selected = e.Item as ToDo;
            if (selected != null)
            {
                result = await DisplayAlert($"{selected.Title}", "Задача назначена на " + $"{selected.Date_Create}", "Удалить", "OK");
                if (result == true)
                    Remove();
            }
        }

        public void Remove()
        {
            ToDo toDo = toDoList.SelectedItem as ToDo;
            if (toDo != null)
            {
                ToDos.Remove(toDo);
                toDoList.SelectedItem = null;
            }
        }
    }
    
}
