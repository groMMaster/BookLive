using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using BookLive.Application.Services;
using BookLive.Application.Services.Interfaces;
using BookLive.Application.Utils;
using BookLive.Core;
using BookLive.Persistent.Context;
using BookLive.Persistent.Repository;
using BookLive.UI.ViewModels;

namespace BookLive.UI.Views;

public partial class AddBookWindow : ReactiveWindow<AddBookViewModel>
{
    public AddBookWindow()
    {
        InitializeComponent();
    }

    private void Close(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        var readBook = ViewModel!.ReadBook;
        readBook.Validate();
        ViewModel!.ReadBookService.AddReadBook(readBook);
        this.Close();
    }

    private async void SaveImage_OnClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        // Start async operation to open the dialog.
        var path = await topLevel.StorageProvider.
        var file = await topLevel.StorageProvider.TryGetFileFromPathAsync()


    }
}