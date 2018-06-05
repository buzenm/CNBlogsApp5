using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace CNBlogsApp5.MyPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PanePage : Page
    {
        public int i = 0;
        public PanePage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Current.MainSplitView.IsPaneOpen = !MainPage.Current.MainSplitView.IsPaneOpen;
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListView.SelectedItem == BlogListViewItem)
            {

                OneToTwoPage.Current.LeftFrame.Navigate(typeof(MyBlogPage.BlogListViewPage));
                OneToTwoPage.Current.RightFrame.Navigate(typeof(MyBlogPage.BlogContentPage),i);
                Canvas.SetZIndex(OneToTwoPage.Current.RightFrame, 0);
                Canvas.SetZIndex(OneToTwoPage.Current.LeftFrame, 1);

            }
            else if (MainListView.SelectedItem == NewsListViewItem)
            {
                if (i == 1)
                {
                    OneToTwoPage.Current.LeftFrame.Navigate(typeof(MyNewsPage.NewsListViewPage));
                    OneToTwoPage.Current.RightFrame.Navigate(typeof(MyNewsPage.NewsContentPage), i);
                    Canvas.SetZIndex(OneToTwoPage.Current.RightFrame, 0);
                    Canvas.SetZIndex(OneToTwoPage.Current.LeftFrame, 1);
                }
                i = 1;
                
            }
            else if (MainListView.SelectedItem == MineListViewItem)
            {


            }
            else if (MainListView.SelectedItem == SettingListViewItem)
            {


            }
        }

        private void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MainPage.Current.MainSplitView.IsPaneOpen)
            {
                MainPage.Current.MainSplitView.IsPaneOpen = !MainPage.Current.MainSplitView.IsPaneOpen;
            }
            else
            {
                MainPage.Current.MainSplitView.IsPaneOpen = MainPage.Current.MainSplitView.IsPaneOpen;
            }
        }
    }
}
