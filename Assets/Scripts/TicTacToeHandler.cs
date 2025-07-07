using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeHandler : MonoBehaviour
{
    public static TicTacToeHandler Instance;
    public bool isPlayer1Turn = false;
    public bool isPlayer2Turn = false;
    public bool isGameOver = false;
    public bool isDraw = false;
    public bool isPlayer1Win = false;
    public bool isPlayer2Win = false;
    public List<int> player1Moves = new List<int>();
    public List<int> player2Moves = new List<int>();
    public GameObject cellsHolder;
    public GameObject xoSpriteObject;
    public Text player1Text, player2Text;

    private void Start(){
        Instance = this;
        ResetGame();
    }
    
    public void ResetGame(){
        foreach (Transform cell in cellsHolder.transform){
            Destroy(cell.gameObject);
        }
        for(int i = 0; i < 9; i++){
            var newCell = Instantiate(xoSpriteObject.transform, cellsHolder.transform);
            newCell.transform.GetChild(0).gameObject.SetActive(false);
            newCell.GetComponent<TicTacToeBtnScript>().index = i;
            newCell.gameObject.SetActive(true);
        }
        isPlayer1Turn = true;
        isPlayer2Turn = false;
        isGameOver = false;
        isDraw = false;
        isPlayer1Win = false;
        isPlayer2Win = false;
        player1Moves.Clear();
        player2Moves.Clear();
        player1Text.color = Color.green;
        player2Text.color = Color.white;
    }
    
    public void CheckWinner(){
        int[][] winningCombinations = new int[][]
        {
            new int[] {0, 1, 2},
            new int[] {3, 4, 5},
            new int[] {6, 7, 8},
            new int[] {0, 3, 6},
            new int[] {1, 4, 7},
            new int[] {2, 5, 8},
            new int[] {0, 4, 8},
            new int[] {2, 4, 6}
        };

        foreach (var combination in winningCombinations)
        {
            if (player1Moves.Contains(combination[0]) && player1Moves.Contains(combination[1]) && player1Moves.Contains(combination[2]))
            {
                isPlayer2Win = true;
                Debug.Log("Player 1 Wins!");
                Invoke(nameof(ResetGame), 3f);
                print("Game Reset Successfully!");
                // ResetGame();
                return;
            }
            if (player2Moves.Contains(combination[0]) && player2Moves.Contains(combination[1]) && player2Moves.Contains(combination[2]))
            {
                Debug.Log("Player 2 Wins!");
                isPlayer2Win = true;
                Invoke(nameof(ResetGame), 3f);
                // Invoke(nameof(() => { 
                //     Debug.Log("Resetting the game..."); 
                //     ResetGame(); 
                // }), 3f);
                print("Game Reset Successfully!!");
                // ResetGame();
                return;
            }
        }

        if (player1Moves.Count + player2Moves.Count == 9)
        {
            Debug.Log("It's a Draw!");
            isDraw = true;
            Invoke(nameof(ResetGame), 3f);
            print("Game Reset Successfully!!!");
            // ResetGame();
        }
    }
}
