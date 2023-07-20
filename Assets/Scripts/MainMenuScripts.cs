using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;
    
    private void Start()
    {
        creditPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

    public void Credit()
    {
        creditPanel.SetActive(true);
    }

    public void Return()
    {
        creditPanel.SetActive(false);
    }
}
