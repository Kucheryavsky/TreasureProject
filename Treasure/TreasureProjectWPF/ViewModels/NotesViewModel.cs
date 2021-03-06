﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using DataModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows;
using System.Runtime.CompilerServices;

namespace TreasureProjectWPF.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Note> notes;

        public ICommand Remove { get; private set; }
        public ICommand Update { get; private set; }

        //Note[] notes;
        public ObservableCollection<Note> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
                OnPropertyChanged("notes");

            }
        }

     

        public NotesViewModel()
        {
            Notes = NotesLoader.GetNotes();
            Update = new DelegateCommand(EditNote);
            Remove = new DelegateCommand(DeleteNote, CanRemoveNote);
        }

        bool CanRemoveNote(object arg)
        {
            return (arg as Note) != null;
        }

        void DeleteNote(object obj)
        {
            var selectedNote = CollectionViewSource.GetDefaultView(notes).CurrentItem as Note;
            Notes.Remove((Note)obj);
            if (NotesLoader.DeleteItem((obj as Note).NoteId))
            {
                //сервер вернул true - элемент удален
            }
            else
            {
                //false - такой элемент не найден
            }

        }

            

        void EditNote(object obj)
        {
           // var selectedNote = CollectionViewSource.GetDefaultView(notes).CurrentItem as Note;
            var selectedNote = (Note)obj;
            NotesLoader.EditItem(selectedNote);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
    }

}
