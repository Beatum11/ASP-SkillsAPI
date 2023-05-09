namespace SkillsAPI.Data.Models
{
    public class Skill
    {
        #region Fields

        private int _id;
        private string? _name;
        private string? _description;

        #endregion

        #region Properties

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }

        #endregion

        #region Constructor

        public Skill (int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        #endregion
    }
}
