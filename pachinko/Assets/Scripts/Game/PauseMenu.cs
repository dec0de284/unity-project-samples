using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void PauseMenuShow()
    {
        gameObject.transform.Find("Pause Menu").SetParent(gameObject.transform.Find("Main Canvas"));
    }
    public void PauseMenuHide()
    {
        gameObject.transform.Find("Pause Menu").SetParent(gameObject.transform.parent);
    }
}
