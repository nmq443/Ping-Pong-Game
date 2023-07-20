using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
        gameOverPanel.SetActive(false);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
        gameOverPanel.SetActive(false);
    }
}
