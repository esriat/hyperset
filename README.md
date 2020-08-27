# HyperSet

### Project presentation

`This project was made in 2 months in a group of 2. This is a school project, but we were not the ones who chose the concept. </br>
This concept was chosen by our teacher and tutor, [Mr. LAFOURCADE Pascal](https://www.linkedin.com/in/pascal-lafourcade-bb19863/). It comes from a real card-game called SET, in which you have to find groups of 3 cards that follow specific rules. Our goal here was to create a mobile version of Set, and to add a new gamemode, called Hyperset.</br>
This application is available on the Google Play Store [here](https://play.google.com/store/apps/details?id=iut.setthegame.setthegame&hl=fr).

### Game rules

#### Presentation of the game

This game is a card game. The deck is composed of 81 cards, that are identified by a symbol that has 4 criteria :
- **The shape of the symbol** : The card can present 3 different symbols : a wave, an oval or a diamond;
- **The number of symbols** : The symbol can appear 1, 2 or 3 times on each card;
- **The color of the symbols** : Green, blue or red;
- **The filling of the symbol** : The symbol can be emfty, filled, or hatched.

#### Game rules : SET

12 cards are shown. The goal of the SET gamemode is to find 3 cards that, for each criteria, are either different or either identical. To be clear :
- The 3 cards must ALL have the same shape, or the three cards must have different shape;
- The 3 cards must ALL have the same number of symbols, or the three cards must have different number of symbols;
- The 3 cards must ALL have the same color, or the three cards must have different color;
- The 3 cards must ALL have the same filling, or the three cards must have different filling.

A group of 3 cards that follow these rules is called a SET. The goal is to find SETs as fast as possible. When playing alone, you have to use all the cards in the deck in the shortest amount of time. When playing in group, you can cooperate, and empty the deck as fast as possible, or you can try to get more SETs than other players.

The drawback of the SET game is that there's a chance of not having any SET in 12 cards. If that's the case, you need to add a new card on the board. To avoid this, a new (but harder) gamemode was created : HyperSET.

#### Game rules : HyperSET

The goal of HyperSET is to find 2 groups of 2 cards that each form a SET when combined by the same 5th card. The 5th card does not have to be on the board. With 12 cards, there's a 100% chance that at least 1 HyperSET exists.
Those rules are hard to explain, and hard to understand.

#### Other informations..

The application has tutorials for both gamemodes. You can also customize the colors of the cards in the options of the game.

I've personnaly been in charge of the back-end of this application, and all data-things, like saving the changes of colors, while my parter was in charge of the front-end.