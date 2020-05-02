using QA_Mokymai_VCS_Pamoka_0409.Pages;


namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class Navigation
    {        
        public static Item GoToDogToysPage()
        {
            Driver.Current.Url = "https://www.kika.lt/katalogas/sunims/zaislai/";            
            return new Item();
        }
    }
}
