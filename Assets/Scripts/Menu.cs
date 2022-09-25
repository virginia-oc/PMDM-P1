using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public static void ShowWelcomeScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    public static void LaunchGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public static void ShowWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }

    public static void QuitGame()
    {

    }
}
