using System; 

public class User{

public string Name {get; set;}
public string Email {get; set;}

public int id {get; set;}
    
public string TypeOfUser {get; set;}

public User(string name, string email, int id, string typeOfUser){
    this.Name = name;
    this.Email = email;
    this.id = id;
    this.TypeOfUser = typeOfUser;
}




}