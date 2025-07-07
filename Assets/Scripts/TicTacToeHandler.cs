using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeHandler : MonoBehaviour
{
    public static TicTacToeHandler instance;
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
    public bool isWonOrLost = false;
    public List<GameObject> winningLines;
    public Sprite redLineSprite,blueLineSprite;

    private void Start(){
        instance = this;
        ResetGame();
    }
    
    public void ResetGame(){
        foreach (Transform cell in cellsHolder.transform){
            Destroy(cell.gameObject);
        }
        for(int i = 0; i < 9; i++){
            var newCell = Instantiate(xoSpriteObject.transform, cellsHolder.transform);
           // newCell.transform.GetChild(0).gameObject.SetActive(false);
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
        player1Text.color = Color.gray;
        player1Text.text = "Your Turn";
        isWonOrLost = false;
        winningLines.ForEach(line => {
            line.SetActive(false);
            line.GetComponent<Image>().DOFillAmount(0f, 0f);
        });
    }
    
    public void CheckWinner(){
        var winningCombinations = new int[][] {
            new int[] {0, 1, 2},
            new int[] {3, 4, 5},
            new int[] {6, 7, 8},
            new int[] {0, 3, 6},
            new int[] {1, 4, 7},
            new int[] {2, 5, 8},
            new int[] {0, 4, 8},
            new int[] {2, 4, 6}
        };

        for (var i = 0; i < winningCombinations.Length; i++)
        {
            var combo = winningCombinations[i];
            if (player1Moves.Contains(combo[0]) && player1Moves.Contains(combo[1]) && player1Moves.Contains(combo[2]))
            {
                isPlayer1Win = true;
                player1Text.text = "You Won!";
                player1Text.color = Color.blue;
                
                isWonOrLost = true;
                winningLines[i].GetComponent<Image>().sprite = blueLineSprite; 
                winningLines[i].SetActive(true);
                winningLines[i].GetComponent<Image>().DOFillAmount(1f, 1f);
                return;
            }
            if (player2Moves.Contains(combo[0]) && player2Moves.Contains(combo[1]) && player2Moves.Contains(combo[2]))
            {
                isPlayer2Win = true;
                player1Text.text = "You Lost!";
                player1Text.color = Color.red;
                isWonOrLost = true;
                winningLines[i].GetComponent<Image>().sprite = redLineSprite; 
                winningLines[i].SetActive(true); 
                winningLines[i].GetComponent<Image>().DOFillAmount(1f, 1f);
                return;
            }
        }

        if (player1Moves.Count + player2Moves.Count == 9)
        {
            player1Text.text = "DRAW!";
            isDraw = true;
            isWonOrLost = true;
        }
    }

}
