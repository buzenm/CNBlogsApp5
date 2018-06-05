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
    public sealed partial class BlogCommentPage : Page
    {
        public ObservableCollection<Post> posts = new ObservableCollection<Post>();
        public BlogCommentPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var entry = (BlogEntry)e.Parameter;
            var post = Function.Derserlializer<Feed<Post>>(await Function.GetNewsListStringAsync(new Uri("http://wcf.open.cnblogs.com/blog/post/" + entry.Id + "/comments/1/15")));
            foreach (var item in post.Entries)
            {
                posts.Add(item);
            }
        }
    }
}
