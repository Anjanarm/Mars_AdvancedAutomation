
namespace Mars_Advanced.TestData
{
    public class LanguageData
    {
        public string Language { get; set; }
        public string Level { get; set; }
    }


    public class LanguageEditData
    {
        public LanguageData Original { get; set; }
        public LanguageData Updated { get; set; }
    }

}
