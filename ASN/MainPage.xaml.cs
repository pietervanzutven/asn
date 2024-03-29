﻿using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace ASN
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            webview.Navigate(new Uri("https://www.asnbank.nl/online/web/onlinebankieren/inloggen"));

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void Webview_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            args.Handled = true;
            webview.Navigate(args.Uri);
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (webview.CanGoBack)
            {
                e.Handled = true;
                webview.GoBack();
            }
        }
    }
}
