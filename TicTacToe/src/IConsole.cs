namespace TicTacToe
{
    public interface IConsole
    {
        void Print(string message);
        string GetString();
        int GetInt();
        void Clear();
    }
}