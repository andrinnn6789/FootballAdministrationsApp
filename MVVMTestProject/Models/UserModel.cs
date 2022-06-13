namespace MVVM_Vorlage.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserModel()
        {
            FirstName = "First";
            LastName = "Last";
        }

        public UserModel(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
    }

}
