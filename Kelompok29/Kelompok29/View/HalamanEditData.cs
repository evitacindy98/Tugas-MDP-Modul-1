using Kelompok29.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok29.View
{
    public class HalamanEditData : ContentPage
    {
        private ListView _listView;
        private Entry _idUser;
        private Entry _namaUser;
        private Entry _jurusanUser;
        private Button _button_edit;

        DataMahasiswa _data = new DataMahasiswa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        public HalamanEditData()
        {
            this.Title = "Edit Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idUser = new Entry();
            _idUser.Placeholder = "ID";
            _idUser.IsVisible = false;
            stackLayout.Children.Add(_idUser);

            _namaUser = new Entry();
            _namaUser.Keyboard = Keyboard.Text;
            _namaUser.Placeholder = "Nama";
            stackLayout.Children.Add(_namaUser);

            _jurusanUser = new Entry();
            _jurusanUser.Keyboard = Keyboard.Text;
            _jurusanUser.Placeholder = "Jurusan";
            stackLayout.Children.Add(_jurusanUser);

            _button_edit = new Button();
            _button_edit.Text = "Edit Data";
            _button_edit.Clicked += _button_edit_Clicked;
            stackLayout.Children.Add(_button_edit);

            Content = stackLayout;
        }

        private async void _button_edit_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            DataMahasiswa data = new DataMahasiswa()
            {
                Id = Convert.ToInt32(_idUser.Text),
                Nama = _namaUser.Text,
                Jurusan = _jurusanUser.Text
            };
            db.Update(data);
            await Navigation.PopAsync();


        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _data = (DataMahasiswa)e.SelectedItem;
            _idUser.Text = _data.Id.ToString();
            _namaUser.Text = _data.Nama;
            _jurusanUser.Text = _data.Jurusan;

        }
    }
}