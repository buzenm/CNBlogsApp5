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

namespace CNBlogsApp5.MyPage.MyNewsPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NewsListViewPage : Page
    {
        public List<NewsEnumList> NewsEnum = new List<NewsEnumList>();
        public int pageIndex = 1;
        public ObservableCollection<Entry> entries = new ObservableCollection<Entry>();
        public NewsListViewPage()
        {
            this.InitializeComponent();
            //NewsEnum = new List<NewsEnumList>();
            foreach(NewsTitle nt in Enum.GetValues(typeof(NewsTitle)))
            {
                //NewsEnum.Add(Enum.GetName(typeof(NewsTitle), nt));
                NewsEnumList mynews = new NewsEnumList();
                mynews.Name = Enum.GetName(typeof(NewsTitle), nt);
                NewsEnum.Add(mynews);
            }
            
        }

        private void NewsTitleGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NewsTask();
        }

        private void FooterButton_Click(object sender, RoutedEventArgs e)
        {
            pageIndex++;
            NewsTask();
        }

        private void RefreshAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            entries.Clear();
            NewsTask();
        }

        private void NewsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
            OneToTwoPage.Current.RightFrame.Navigate(typeof(NewsContentPage), entries[NewsListView.SelectedIndex]);
            Canvas.SetZIndex(OneToTwoPage.Current.LeftFrame, 0);
            Canvas.SetZIndex(OneToTwoPage.Current.RightFrame, 1);
        }

        public async void NewsTask()
        {
            Uri uri = new Uri("http://wcf.open.cnblogs.com/news/recent/paged/" + pageIndex + "/15");
            Feed<Entry> feed = Function.Derserlializer<Feed<Entry>>(await Function.GetNewsListStringAsync(uri));
            for (int i = 0; i < feed.Entries.Count; i++)
            {
                entries.Add(feed.Entries[i]);
            }
        }
    }
}
