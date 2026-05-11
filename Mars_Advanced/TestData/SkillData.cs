
namespace Mars_Advanced.TestData
{
    public class SkillData
    {
        public string Skill { get; set; }
        public string Level { get; set; }
    }


    public class SkillEditData
    {
        public SkillData Original { get; set; }
        public SkillData Updated { get; set; }
    }

}
