using System.Collections;
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
            var symbol = TicTacToeHandler.instance.cellsHolder.transform.GetChild(index).transform.GetChild(0);
            symbol.gameObject.SetActive(true);
            StartCoroutine(Shake(symbol));
            TicTacToeHandler.instance.isPlayer1Turn = false;
            TicTacToeHandler.instance.isPlayer2Turn = true;
            TicTacToeHandler.instance.player1Text.text = "Please Wait";
        }
        else 
        {
            transform.GetChild(0).GetComponent<Image>().sprite = OSprite;
            TicTacToeHandler.instance.player2Moves.Add(index);
            var symbol =  TicTacToeHandler.instance.cellsHolder.transform.GetChild(index).transform.GetChild(0);
            symbol.gameObject.SetActive(true);
            StartCoroutine(Shake(symbol));
            TicTacToeHandler.instance.isPlayer1Turn = true;
            TicTacToeHandler.instance.isPlayer2Turn = false;
            TicTacToeHandler.instance.player1Text.text = "Your Turn";
        }
        TicTacToeHandler.instance.CheckWinner();
    }
    public IEnumerator Shake(Transform target, float duration = 0.3f, float magnitude = 10f)
    {
        Vector3 originalPos = target.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            target.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        target.localPosition = originalPos;
    }
}
