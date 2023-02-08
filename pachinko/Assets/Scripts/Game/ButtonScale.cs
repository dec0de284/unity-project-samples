using UnityEngine;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour
{

    private Button button;

    [Header("Animation")]
    [SerializeField] bool enlarge = true;
    [SerializeField] float boundScaleMax = 1.5f;
    [SerializeField] float boundScaleMin = 1f;
    [SerializeField] float enlargeSpeed = 0.005f;
    void Awake()
    {
        button = GetComponent<Button>();
    }
    void FixedUpdate()
    {
        if (!button.IsDestroyed() && !PauseButton.gamePaused)
        {
            if (enlarge)
            {
                EnlargeButton();
            }
            else
            {
                ShrinkButton();
            }
            if (button.transform.localScale.x >= boundScaleMax)
            {
                enlarge = false;
            }
            else if (button.transform.localScale.x <= boundScaleMin)
            {
                enlarge = true;
            }
        }
    }
    void EnlargeButton()
    {
        button.transform.localScale = new Vector3(button.transform.localScale.x + enlargeSpeed, button.transform.localScale.y + enlargeSpeed);

    }
    void ShrinkButton()
    {
        button.transform.localScale = new Vector3(button.transform.localScale.x - enlargeSpeed, button.transform.localScale.y - enlargeSpeed);
    }
    public void DestroyButton()
    {
        Destroy(button);
    }
    public void DisablePlayButton()
    {
        button.interactable = false;
    }
    public void ChangePlayButtonEnableState()
    {
        if (!button.IsDestroyed())
        {
            if (button.interactable)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}
