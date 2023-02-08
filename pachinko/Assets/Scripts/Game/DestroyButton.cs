using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    Canvas canvas;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    public void DestroyChildrenButton()
    {
        if (!PauseButton.gamePaused)
        {
            canvas.transform.Find("Play Button").SetParent(null);
        }
    }
}
