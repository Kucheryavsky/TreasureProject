﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureProjectMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreasureProjectMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public Add()
        {
            InitializeComponent();
            BindingContext = new AddNoteViewModel(4);
        }
    }
}