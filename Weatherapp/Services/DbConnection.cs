using Weatherapp.Models;
using SQLite;
namespace Weatherapp.Services;

public class DbConnection
{
    SQLiteAsyncConnection Database;

    public const SQLite.SQLiteOpenFlags Flags =
      // open the database in read/write mode
      SQLite.SQLiteOpenFlags.ReadWrite |
      // create the database if it doesn't exist
      SQLite.SQLiteOpenFlags.Create |
      // enable multi-threaded database access
      SQLite.SQLiteOpenFlags.SharedCache;

    public DbConnection()
    {
    }
    static SQLiteAsyncConnection db;
    static async Task Init2()
    {
        if (db != null)
            return;

        // Get an absolute path to the database file
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDoDb.db");

        db = new SQLiteAsyncConnection(databasePath);
        Console.WriteLine(db + "hfhf");

        await db.CreateTableAsync<ToDoModel>();
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDoDb.db");

        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Flags);
            Console.WriteLine(Database + "hfhf");

        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                var innerExceptionMessage = ex.InnerException.Message;
                // Handle or log the inner exception message
            }
            else
            { Console.WriteLine(ex.Message); }
        }

        await Database.CreateTableAsync<ToDoModel>();
    }

    public async Task<List<ToDoModel>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<ToDoModel>().ToListAsync();
    }

    public async Task<ToDoModel> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<ToDoModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(ToDoModel item)
    {
        await Init();
        Console.WriteLine("###" + item.Name);
        return await Database.InsertAsync(item);
    }

    public async Task<int> UpdateItemAsync(ToDoModel item)
    {
        await Init();
        return await Database.UpdateAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<ToDoModel> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(ToDoModel item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllItemsAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<ToDoModel>();
    }
    public static async Task<IEnumerable<ToDoModel>> GetCoffee()
    {
        await Init2();

        var todo = await db.Table<ToDoModel>().ToListAsync();
        return todo;
    }

    public static async Task<ToDoModel> GetToDo(int id)
    {
        await Init2();

        var todo = await db.Table<ToDoModel>()
            .FirstOrDefaultAsync(c => c.Id == id);

        return todo;
    }
}
