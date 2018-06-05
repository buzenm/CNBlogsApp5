using CNBlogsApp5.MyClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace CNBlogsApp5.MyPage.MyNewsPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NewsContentPage : Page
    {
        public Entry entry = new Entry();
        public NewsContentPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            //Uri uri = new Uri(((MyClass.Entry)(e.Parameter)).Link.Href);
            if (e.Parameter != null)
            {
                if ((e.Parameter) is Entry)
                {
                    entry = (Entry)(e.Parameter);
                    if (entry != null)
                    {
                        NewsBody newsBody = Function.Derserlializer<NewsBody>(await Function.GetNewsListStringAsync(new Uri("http://wcf.open.cnblogs.com/news/item/" + entry.Id)));
                        ContentWebView.NavigateToString(newsBody.content.Replace("<img", "<img style=\"max-width: 100%\""));
                    }

                }
                else if ((e.Parameter) is int)
                {
                    OneToTwoPage.Current.RightFrame.BackStack.Clear();
                }
            }
            

            if (OneToTwoPage.Current.RightFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                SystemNavigationManager.GetForCurrentView().BackRequested += NewsContentPage_BackRequested;

            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

        }

        private void NewsContentPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (OneToTwoPage.Current.RightFrame.CanGoBack)
            {
                OneToTwoPage.Current.RightFrame.GoBack();
                Canvas.SetZIndex(OneToTwoPage.Current.RightFrame, 0);
                Canvas.SetZIndex(OneToTwoPage.Current.LeftFrame, 1);
                SystemNavigationManager.GetForCurrentView().BackRequested -= NewsContentPage_BackRequested;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (OneToTwoPage.Current.RightFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().BackRequested -= NewsContentPage_BackRequested;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            }
        }

        private void CommentAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            OneToTwoPage.Current.RightFrame.Navigate(typeof(NewsCommentsPage), entry);
        }
    }
}
