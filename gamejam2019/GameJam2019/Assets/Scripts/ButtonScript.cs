using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void leftButtonClick()
    {
        Debug.Log("Left button clicked"); //Put whatever values must be changed here
    }

    public void rightButtonClick() 
    {
        Debug.Log("Right button clicked"); //Put whatever values must be changed here
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
