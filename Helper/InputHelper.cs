public static class InputHelper 
{
    public static string[] ReadAllLines(string filepath) 
    {
        if(File.Exists(filepath)) 
        {
            return File.ReadAllLines(filepath);
        }
        else 
        {
            throw new Exception("not found");
        }
    }
}