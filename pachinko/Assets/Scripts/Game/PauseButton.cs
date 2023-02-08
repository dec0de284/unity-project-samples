using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public static bool gamePaused;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        gamePaused = false;
    }
    public void ChangeGameState()
    {
        if (gamePaused)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
    }
    private void PauseGame()
    {
        SetGamePauseState(true);
        Time.timeScale = 0;
    }
    private void UnPauseGame()
    {
        SetGamePauseState(false);
        Time.timeScale = 1f;
    }

    private void SetGamePauseState(bool gameState)
    {
        gamePaused = gameState;
    }
    public void DisablePauseButton()
    {
        button.interactable = false;
    }
    public void EnablePauseButton()
    {
        button.interactable = true;
    }
}
