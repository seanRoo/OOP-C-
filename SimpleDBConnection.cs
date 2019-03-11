/*
Exercise 1:

To access a database, we need to open a connection to it first and close it once our job is done.
Connecting to a database depends on the type of the target database and the database
management system (DBMS). For example, connecting to a SQL Server database is different
from connecting to an Oracle database. But both these connections have a few things in
common:
• They have a connection string
• They can be opened
• They can be closed
• They may have a timeout attribute (so if the connection could not be opened within the
timeout, an exception will be thrown).

Exercise 2:

Design a class called DbCommand for executing an instruction against the database. A
DbCommand cannot be in a valid state without having a connection. So in the constructor of
this class, pass a DbConnection. Don’t forget to cater for the null.
Each DbCommand should also have the instruction to be sent to the database. In case of SQL
Server, this instruction is expressed in T-SQL language. Use a string to represent this instruction.
Again, a command cannot be in a valid state without this instruction. So make sure to receive it
in the constructor and cater for the null reference or an empty string.
Each command should be executable. So we need to create a method called Execute(). In this
method, we need a simple implementation as follows:
Open the connection
Run the instruction
Close the connection

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*initialize DB objects */
            DB sql = new SqlConn("SQL Connection Message!");
            DB oracle = new OracleConn(""); //test to make sure exception is thrown

            /* pass DB object and command string to DBCommand constructor */
            DBCommand sqlCmd = new DBCommand(sql, "SELECT * FROM sqlTable;");
            DBCommand oracleCmd = new DBCommand(oracle, ""); //test to make sure exception is thrown

            Console.ReadKey();
        }
    }
}
class DB
{
    /* Make connection string private to prevent outside modification */
    private string conn;

    /* DB Constructor taking in a connection string */
    public DB(string connStr)
    {
        if(connStr != "") //checks against empty strings
        {
                this.conn = connStr;
            /* Execute methods */

                //Message(conn);
                //Open();
                //Close();
        }
        else //throw exception if null connection string
        {
            Console.WriteLine(new ArgumentNullException());
        }
    }
    /* default method implementations to be overridden */
    public virtual void Open()
    {
        Console.WriteLine("Opening Connection....");
    }
    public virtual void Close()
    {
        Console.WriteLine("Closing Connection...");
    }
    void Message(string str)
    {
        Console.WriteLine(str);
    }
}

/* derived class */
class SqlConn: DB
{
    /* constuctor taking in connection string and reusing the constructor of the base class through inheritance */
    public SqlConn(string connStr) : base(connStr)
    {

    }

    /* overriding base class methods */
    public override void Open()
    {
        Console.WriteLine("Opening the SQL Connection at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss."));
    }
    public override void Close()
    {
        Console.WriteLine("Closing the SQL Connection " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss."));
    }

}
/* second derived class */
class OracleConn : DB
{
    public OracleConn(string connStr) : base(connStr)
    {

    }
    public override void Open()
    {
        Console.WriteLine("Opening the Oracle Connection " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss."));
    }
    public override void Close()
    {
        Console.WriteLine("Closing the Oracle Connection " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss."));
    }

}
/* class concerned with executing DB commands */
class DBCommand
{
    private DB db; //declare private DB variable to protect from outside modification

    /* constructor takes in DB object and a command string*/
    public DBCommand(DB dbConn, string dbCommand)
    {
        if(dbConn != null && dbCommand !="") //check against null arguments
        {
            this.db = dbConn;
            /* execute db methods and command */
            this.db.Open();
            Execute(dbCommand);
            this.db.Close();
        }
        else //if null arguments
        {
            Console.WriteLine(new ArgumentNullException());
        }
        
    }
    /* execute method */
    public void Execute(string command)
    {
        Console.WriteLine(command);
    }
}

