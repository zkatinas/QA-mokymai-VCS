using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class PageFactory
    {
        public static LoginModal LoginModal => new LoginModal();
        public static PopUpModal PopUpModal => new PopUpModal();
        public static KikaHeaderSection KikaHeaderSection => new KikaHeaderSection();
        public static PageMenuSection PageMenuSection => new PageMenuSection();
        public static Cart Cart => new Cart();
        public static Item Item => new Item();
        public static KikaHomePage KikaHomePage => new KikaHomePage();
        public static SearchPage SearchPage => new SearchPage();

    }
}
