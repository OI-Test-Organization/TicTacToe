using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TicTacToeBtnScript : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public bool isClicked;
    public Sprite XSprite;
    public Sprite OSprite;

    private void Start()
    {
        isClicked = false;
    }

    public void OnPointerDown(PointerEventData  pointerEventData){
        print($"isClicked: {isClicked}");
        if (isClicked) return;
        isClicked = true;
        print($"TicTacToeHandler.Instance.isPlayer1Turn == true: {TicTacToeHandler.Instance.isPlayer1Turn == true}");
        print($"TicTacToeHandler.Instance.isPlayer2Turn == false: {TicTacToeHandler.Instance.isPlayer2Turn == false}");
        print($"!TicTacToeHandler.Instance.isGameOver: {!TicTacToeHandler.Instance.isGameOver}");
        print($"!TicTacToeHandler.Instance.isDraw: {!TicTacToeHandler.Instance.isDraw}");
        print($"!TicTacToeHandler.Instance.isPlayer1Win: {!TicTacToeHandler.Instance.isPlayer1Win}");
        print($"!TicTacToeHandler.Instance.isPlayer2Win: {!TicTacToeHandler.Instance.isPlayer2Win}");
        print($"TicTacToeHandler.Instance.player1Moves.Count < 5: {TicTacToeHandler.Instance.player1Moves.Count < 5}");
        print($"TicTacToeHandler.Instance.player2Moves.Count < 5: {TicTacToeHandler.Instance.player2Moves.Count < 5}");
        print($"!TicTacToeHandler.Instance.player1Moves.Contains(index): {!TicTacToeHandler.Instance.player1Moves.Contains(index)}");
        print($"!TicTacToeHandler.Instance.player2Moves.Contains(index): {!TicTacToeHandler.Instance.player2Moves.Contains(index)}");
        print($"Index: {index}");
        if (TicTacToeHandler.Instance.isPlayer1Turn)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = XSprite;
            TicTacToeHandler.Instance.player1Moves.Add(index);
            TicTacToeHandler.Instance.cellsHolder.transform.GetChild(index).transform.GetChild(0).gameObject.SetActive(true);
            TicTacToeHandler.Instance.isPlayer1Turn = false;
            TicTacToeHandler.Instance.isPlayer2Turn = true;
            TicTacToeHandler.Instance.player2Text.color = Color.green;
            TicTacToeHandler.Instance.player1Text.color = Color.white;
        }
        else 
        {
            transform.GetChild(0).GetComponent<Image>().sprite = OSprite;
            TicTacToeHandler.Instance.player2Moves.Add(index);
            TicTacToeHandler.Instance.cellsHolder.transform.GetChild(index).transform.GetChild(0).gameObject.SetActive(true);
            TicTacToeHandler.Instance.isPlayer1Turn = true;
            TicTacToeHandler.Instance.isPlayer2Turn = false;
            TicTacToeHandler.Instance.player1Text.color = Color.green;
            TicTacToeHandler.Instance.player2Text.color = Color.white;
        }
        TicTacToeHandler.Instance.CheckWinner();
    }
}
