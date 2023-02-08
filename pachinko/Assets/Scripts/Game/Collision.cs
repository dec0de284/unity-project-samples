using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private TextMeshProUGUI resultMenuText;
    private TextMeshProUGUI ribbonText;
    private Transform resultMenuParent;
    private PauseButton pauseButton;
    private string[] currentPair = new string[] { "", "" };
    private bool winStatus;
    private bool isTriggered = true;
    private readonly string[,] items = new string[,] { { "Hearts", "<sprite=21><sprite=21><sprite=21>" }, { "Gold Coins", "<sprite=22><sprite=22><sprite=22>" }, { "Diamonds", "<sprite=23><sprite=23><sprite=23>" }, { "None", "<sprite=10><sprite=10><sprite=10>" } };

    private void Awake()
    {
        resultMenuParent = gameObject.transform.parent;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered)
        {
            isTriggered = false;
            switch (collision.tag)
            {
                case "Hearts":
                    {
                        currentPair[0] = items[0, 0];
                        currentPair[1] = items[0, 1];
                        winStatus = true;
                        StartCoroutine(ShowResultMenu());
                        break;
                    }
                case "Gold Coins":
                    {
                        currentPair[0] = items[1, 0];
                        currentPair[1] = items[1, 1];
                        winStatus = true;
                        StartCoroutine(ShowResultMenu());
                        break;
                    }
                case "Diamonds":
                    {
                        currentPair[0] = items[2, 0];
                        currentPair[1] = items[2, 1];
                        winStatus = true;
                        StartCoroutine(ShowResultMenu());
                        break;
                    }
                case "None":
                    {
                        currentPair[0] = items[3, 0];
                        currentPair[1] = items[3, 1];
                        winStatus = false;
                        StartCoroutine(ShowResultMenu());
                        break;
                    }
            }
        }
        else
        {
            return;
        }
    }
    private IEnumerator ShowResultMenu()
    {
        yield return new WaitForSeconds(2);
        ChangeResultText();
        DisableAllButtons();
        ResultMenuShow();
    }
    public void ChangeResultText()
    {
        resultMenuText = resultMenuParent.Find("Result Menu").Find("Text").GetComponent<TextMeshProUGUI>();
        ribbonText = resultMenuParent.Find("Result Menu").Find("Ribbon").Find("Ribbon Text").GetComponent<TextMeshProUGUI>();

        if (winStatus)
        {
            resultMenuText.spriteAsset = resultMenuText.spriteAsset.fallbackSpriteAssets.ElementAt(1);
            resultMenuText.text = "You got " + currentPair[0] + "!\r\n" + currentPair[1];
            ribbonText.text = "You won!";
        }
        else
        {
            resultMenuText.spriteAsset = resultMenuText.spriteAsset.fallbackSpriteAssets.ElementAt(0);
            resultMenuText.text = "You didn't got anything!\r\n" + currentPair[1];
            ribbonText.text = "You lost!";
        }
    }
    private void ResultMenuShow()
    {
        gameObject.transform.parent.Find("Result Menu").SetParent(gameObject.transform.parent.Find("Main Canvas"));
        resultMenuParent = gameObject.transform.parent.Find("Main Canvas");
    }
    private void DisableAllButtons()
    {
        pauseButton = gameObject.transform.parent.Find("Main Canvas").Find("Pause Button").GetComponent<PauseButton>();
        pauseButton.DisablePauseButton();
    }
}

