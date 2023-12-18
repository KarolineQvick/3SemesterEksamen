using System;
namespace Model
{
    public class User
    {

        public User(string userName)
        {

            this.UserName = userName;


        }

        public long UserId { get; set; }
        public string UserName { get; set; }


    }
}

