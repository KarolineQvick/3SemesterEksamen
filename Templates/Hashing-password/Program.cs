public class UserManagement
{
    // Example of creating a user
    public void CreateUser(string username, string password)
    {
        // Hash and salt the password
        string hashedPassword = PasswordHasher.HashPassword(password);

        // Create a new user record and save the hashed password in the database
        User newUser = new User
        {
            Username = username,
            PasswordHash = hashedPassword
        };

        // Save the user record in the database
        // ... code to save to the database ...
    }

    // Example of changing a user's password
    public void ChangePassword(string username, string newPassword)
    {
        // Retrieve the user record from the database based on the username
        User user = GetUserByUsername(username);

        if (user != null)
        {
            // Hash and salt the new password
            string newHashedPassword = PasswordHasher.HashPassword(newPassword);

            // Update the user's password hash in the database
            user.PasswordHash = newHashedPassword;

            // Save the changes to the database
            // ... code to save to the database ...
        }
    }
}
