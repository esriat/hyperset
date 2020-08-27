using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame
{
    public interface Game
    {
        bool HasToEnd();
        Deck GetOnBoard();
        void EndGame();
        int NumberOfCardsInAnswer();
        void Answer(Deck answer);
        Deck GetAnswer();
        Partie GetPartie();
    }
}
