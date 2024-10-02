using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Loads back the Main Menu, used only in the Game Over screen
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    // Moves scene into Scene 1 (which is the game scene)
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    // Changes scene into Scen 2 (our high score board)
    public void OnScoreButton()
    {
        SceneManager.LoadScene(2);
    }

    // Quits the game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
