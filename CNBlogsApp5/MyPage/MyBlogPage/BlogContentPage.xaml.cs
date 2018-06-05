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

namespace CNBlogsApp5.MyPage.MyBlogPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BlogContentPage : Page
    {
        public BlogEntry blogEntry = new BlogEntry();
        public BlogContentPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                if ((e.Parameter) is BlogEntry)
                {
                    blogEntry = (BlogEntry)(e.Parameter);
                    if (blogEntry != null)
                    {
                        //BlogBody blogBody = Function.
                        //    Derserlializer<BlogBody>
                        //    (await Function.
                        //    GetNewsListStringAsync
                        //    (new Uri("http://wcf.open.cnblogs.com/blog/post/body/" + blogEntry.Id)));
                        //BlogWebView.NavigateToString(BlogBody.content.Replace("<img", "<img style=\"max-width: 100%\""));
                        string blogBody=Function.Derserlializer<string>(await Function.
                            GetNewsListStringAsync
                            (new Uri("http://wcf.open.cnblogs.com/blog/post/body/" + blogEntry.Id)));
                        //BlogWebView.NavigateToString(blogBody.
                        //    BlogContent.
                        //    Replace("<img", "<img style=\"max-width: 100%\""));
                        BlogWebView.NavigateToString(blogBody.Replace("<img", "<img style=\"max-width: 100%\""));
                        
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
                SystemNavigationManager.GetForCurrentView().BackRequested += BlogContentPage_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void BlogContentPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (OneToTwoPage.Current.RightFrame.CanGoBack)
            {
                OneToTwoPage.Current.RightFrame.GoBack();
                Canvas.SetZIndex(OneToTwoPage.Current.RightFrame, 0);
                Canvas.SetZIndex(OneToTwoPage.Current.LeftFrame, 1);
                SystemNavigationManager.GetForCurrentView().BackRequested -= BlogContentPage_BackRequested;
                //OneToTwoPage.Current.RightFrame.BackStack.Clear();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (OneToTwoPage.Current.RightFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().BackRequested -= BlogContentPage_BackRequested;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                

            }
        }

        private void CommentAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            OneToTwoPage.Current.RightFrame.Navigate(typeof(BlogCommentPage), blogEntry);
        }
    }
}
