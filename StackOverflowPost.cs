using System;

class Program{

    static void Main(String[] args){
        Console.WriteLine("Enter name of post: ");
        Post post = new Post{
            Title = Console.ReadLine(),
            Description = "This is the task description"
            
        };
        Console.WriteLine("Use the up and down arrows to adjust votes!");

        while(true){
            if(Console.ReadKey().Key == ConsoleKey.UpArrow){
                Console.WriteLine("Upvote! " + post.UpVote() + " Votes for " + post.Title);
            }
            else if(Console.ReadKey().Key == ConsoleKey.DownArrow){
                Console.WriteLine("Downvote! " + post.DownVote() + " Votes for " + post.Title);
            }
            else if(Console.ReadKey().Key == ConsoleKey.Q){
                Console.WriteLine("Stopping....");
                break;
            }
        }
    }
}

class Post{
    private string _Title;
    private string _Description;
    private int _Votes  = 0;

    public string Title{
        set => _Title = value;
        get=>_Title;    
    }
    public string Description{
        set => _Description = value;
        get=>_Description;  
    }
    public int UpVote(){
        return _Votes+=1;
    }
    public int DownVote(){
        return _Votes-=1;
    }
}