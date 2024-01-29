using System;
using System.Collections.Generic;

/*
 * Note, this game doesnt properly use the server client model for validation.
 * As such it is vulnerable.
 * 
 * Note to self. Comparing the the player input to the master game state should really be handled on the
 * server and NOT the client. 
 * 
 * For the moment, this solution is fine. But, it may be worth relooking at this in the near future.
 * 
 */
public class DrawingGame {

    Random random = new Random();
    private LinkedList<Guid> masterState = new LinkedList<Guid>();
    private Grid gameGrid = new Grid(5, 5);
    private uint turnsRemaining = 5;
    private bool isGameOver = false;

    public DrawingGame(float difficulty) {
        masterState.AddFirst(gameGrid.GetGridCoordinante(
            (uint)random.Next(0, 4),
            (uint)random.Next(0, 4)
        ));
    }

    public void PlayTurn(LinkedList<Guid> playerInput) {

        // Compare input to master
        if (this.CompareInputToMasterState(playerInput) == false) isGameOver = true;   

        this.StepGame();
    }

    private void StepGame() {

        if (turnsRemaining <= 0 || isGameOver == true) return;  // Handle win lose condition

        turnsRemaining -= 1;
        masterState.AddLast(gameGrid.GetGridCoordinante(
            (uint)random.Next(0, 4),
            (uint)random.Next(0, 4)
        ));
    }

    private bool CompareInputToMasterState(LinkedList<Guid> playerInput) {

        LinkedList<Guid>.Enumerator masterEnumerator = masterState.GetEnumerator();
        LinkedList<Guid>.Enumerator inputEnumerator = playerInput.GetEnumerator();

        do {
            if (masterEnumerator.Current.Equals(inputEnumerator.Current) == false) return false;
            masterEnumerator.MoveNext();
        } while (inputEnumerator.MoveNext());

        return true;
    }

    public Grid GetGrid() {
        return gameGrid;
    }
}
