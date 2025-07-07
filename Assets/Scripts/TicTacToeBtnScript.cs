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
        if( TicTacToeHandler.instance.isWonOrLost == true) return;
        isClicked = true;
        print($"TicTacToeHandler.Instance.isPlayer1Turn == true: {TicTacToeHandler.instance.isPlayer1Turn == true}");
        print($"TicTacToeHandler.Instance.isPlayer2Turn == false: {TicTacToeHandler.instance.isPlayer2Turn == false}");
        print($"!TicTacToeHandler.Instance.isGameOver: {!TicTacToeHandler.instance.isGameOver}");
        print($"!TicTacToeHandler.Instance.isDraw: {!TicTacToeHandler.instance.isDraw}");
        print($"!TicTacToeHandler.Instance.isPlayer1Win: {!TicTacToeHandler.instance.isPlayer1Win}");
        print($"!TicTacToeHandler.Instance.isPlayer2Win: {!TicTacToeHandler.instance.isPlayer2Win}");
        print($"TicTacToeHandler.Instance.player1Moves.Count < 5: {TicTacToeHandler.instance.player1Moves.Count < 5}");
        print($"TicTacToeHandler.Instance.player2Moves.Count < 5: {TicTacToeHandler.instance.player2Moves.Count < 5}");
        print($"!TicTacToeHandler.Instance.player1Moves.Contains(index): {!TicTacToeHandler.instance.player1Moves.Contains(index)}");
        print($"!TicTacToeHandler.Instance.player2Moves.Contains(index): {!TicTacToeHandler.instance.player2Moves.Contains(index)}");
        print($"Index: {index}");
        if (TicTacToeHandler.instance.isPlayer1Turn)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = XSprite;
            TicTacToeHandler.instance.player1Moves.Add(index);
            TicTacToeHandler.instance.cellsHolder.transform.GetChild(index).transform.GetChild(0).gameObject.SetActive(true);
            TicTacToeHandler.instance.isPlayer1Turn = false;
            TicTacToeHandler.instance.isPlayer2Turn = true;
            TicTacToeHandler.instance.player1Text.text = "Your Turn";
        }
        else 
        {
            transform.GetChild(0).GetComponent<Image>().sprite = OSprite;
            TicTacToeHandler.instance.player2Moves.Add(index);
            TicTacToeHandler.instance.cellsHolder.transform.GetChild(index).transform.GetChild(0).gameObject.SetActive(true);
            TicTacToeHandler.instance.isPlayer1Turn = true;
            TicTacToeHandler.instance.isPlayer2Turn = false;
            TicTacToeHandler.instance.player1Text.text = "Please Wait";
        }
        TicTacToeHandler.instance.CheckWinner();
    }
}
