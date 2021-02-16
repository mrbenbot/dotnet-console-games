using Library.CardGame;

namespace Pontoon
{
    public interface IPontoonPlayer
    {
        string Name { get; }
        int Bet { get; }

        void MakeBet();

        void TakeTurn(IDeck<IPontoonCard> deck);

        void Receive(IPontoonCard card);

        string ToString();
        int CompareHand(object obj);

        void Win(int winnings);

        void GiveCardsBack(IDeck<IPontoonCard> deck);
    }
}