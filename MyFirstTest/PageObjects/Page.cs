using MyFirstTest.WrapperFactory;

namespace MyFirstTest.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static GooglePages GooglePages => GetPage<GooglePages>();
    }
}
