namespace MVCCharacterCreator.Models
{
    public class AccessToken
    {
        DataDomain.User _legacyUser;
        List<string> _roles;

        public AccessToken(string email)
        {
            if (email == "" || email == null)
            {
                _legacyUser = new DataDomain.User()
                {
                    Username = "",
                    Email = "",
                    AccountBio = ""
                };
                return;
            }

            LogicLayer.UserManager employeeManager = new LogicLayer.UserManager();
            _legacyUser = employeeManager.SelectUserByEmail(email);
            //_roles = employeeManager.GetRolesForEmployee(_legacyUser.EmployeeID);
        }

        public bool IsSet { get { return _legacyUser.Username != ""; } }
        public string Username { get { return _legacyUser.Username; } }
        public string Email { get { return _legacyUser.Email; } }
        public List<String> Roles { get { return _roles; } }



    }
}
