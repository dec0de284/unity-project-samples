using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public void ResetCurrentLevel()
    {
        if (!PauseButton.gamePaused)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
