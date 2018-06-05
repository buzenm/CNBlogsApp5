using CNBlogsApp5.MyClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CNBlogsApp5.MyPage.MyBlogPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BlogListViewPage : Page
    {
        public int pageIndex = 1;
        public ObservableCollection<BlogEntry> blogEntries = new ObservableCollection<BlogEntry>();
        public BlogListViewPage()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //BlogEntries.Add((BlogEntry)(Function.Derserlializer<BlogEntry>(await Function.GetNewsListStringAsync(new Uri("http://wcf.open.cnblogs.com/blog/sitehome/paged/" + pageIndex+"/15")))));
            BlogTaskAsync();
        }

        private void RefreshAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            blogEntries.Clear();
            BlogTaskAsync();
        }

        public async void BlogTaskAsync()
        {
            Uri uri = new Uri("http://wcf.open.cnblogs.com/blog/sitehome/paged/" + pageIndex + "/15");
            Feed<BlogEntry> feed = Function.Derserlializer<Feed<BlogEntry>>(await Function.GetNewsListStringAsync(uri));
            foreach (var item in feed.Entries)
            {
                blogEntries.Add(item);
            }
        }

        private void BlogListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OneToTwoPage.Current.RightFrame.
                Navigate(typeof(BlogContentPage), 
                blogEntries[BlogListView.SelectedIndex]);

            Canvas.SetZIndex(OneToTwoPage.Current.LeftFrame, 0);
            Canvas.SetZIndex(OneToTwoPage.Current.RightFrame, 1);
        }

        private void BlogAddButton_Click(object sender, RoutedEventArgs e)
        {
            pageIndex++;
            BlogTaskAsync();
        }
    }
}
