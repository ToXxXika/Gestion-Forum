namespace BL.Repositories;

public class PostRepository
{
    public String GenrateRandomReference()
    {
        //TODO: Generate Random Reference if u want to change it and test if it's not found
        return "REF" + new Random().Next(1, 999999).ToString();
        
    }
}