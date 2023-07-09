Battleships Game
This is a C# application that allows a single human player to play a one-sided game of Battleships against ships placed by the computer. The program creates a 10x10 grid and randomly places ships of different sizes on the grid. The objective of the game is to sink all the ships by targeting specific coordinates.

How to Play
  1. Launch the application and a 10x10 grid will be displayed.
  2. The computer will randomly place the following ships on the grid:
        1 Battleship (5 squares)
        2 Destroyers (4 squares each)
  3. The player can enter or select coordinates to target a specific square on the grid. The coordinates should be in the form of "A5", where "A" represents the column and "5" represents the row.
  4. When a shot is fired, the program will determine if it's a hit, a miss, or a sink. A hit indicates that the shot successfully hits a ship, a miss means the shot does not hit anything, and a sink means that a ship has been completely destroyed.
  5. Continue targeting squares until all the ships have been sunk.
  6. The game ends when all the ships are sunk, and the player is shown a victory message.

Prerequisites
  .NET Framework or .NET Core installed on your machine.
    
How to Run
  1. Clone the repository or download the source code.
  2. Open the project in your preferred IDE.
  3. Build the project to ensure all dependencies are resolved.
  4. Run the application.
  5. The game will start, and you can begin playing Battleships.

File Structure
  The project consists of the following files:
  Program.cs: Contains the main entry point of the application and the game logic.
  BoardService.cs: Contains the game logic and contains methods for placing ships and checking shots
  Board.cs: Represents the game grid.
  Ship.cs: Represents a ship and its properties such as size and status.
  Compartment.cs: Represents a ship Compartment and its properties such as status and coordinates.

License
  This project is licensed under the MIT License. Feel free to use, modify, and distribute the code as per the terms of the license.
