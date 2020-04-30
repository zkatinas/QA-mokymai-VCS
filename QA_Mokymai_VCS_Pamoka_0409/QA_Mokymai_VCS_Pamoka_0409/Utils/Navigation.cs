using QA_Mokymai_VCS_Pamoka_0409.Pages;


namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    class Navigation
    {

        // Vietoj "Item" reikia klases "ProductListing", kurioje apsirasyti kintamjam karuseles produktus.
        // Tada sita kintamaji paduoti kitiems kintamiesiems/metodams "pavadinimas", "kaina", "kiekis".
        // Ir sukurti metodus "GetTitle" ir pan.; assert'inimui naudoti laikina vietini kintamaji = "GetTitle"
        public static Item GoToDogToysPage()
        {
            Driver.Current.Url = "https://www.kika.lt/katalogas/sunims/zaislai/";            
            return new Item();
        }

    }
}
