﻿using System;
using Booky.Models;
using Booky.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Booky.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var selectedCover = (e.Item as BookModel).Cover;
            var colorHelper = DependencyService.Get<IColorHelper>();
            var dominantColor = colorHelper.GetColor(selectedCover);
            await Navigation.PushModalAsync(new BookDetailPage(dominantColor), true);
        }
    }
}