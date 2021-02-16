using Library.CardGame;

namespace Pontoon
{
    public interface IPontoonCard : ICard
    {
        int MinValue { get; }
        int MaxValue { get; }
    }
}