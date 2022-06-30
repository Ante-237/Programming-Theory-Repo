using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver_Panel;
    [SerializeField]
    private GameObject pointBox_Panel;


    //bring gameOver panel to visible.
    public void gameOver_Decide(bool decide)
    {
        gameOver_Panel.SetActive(decide);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void restartlevel()
    {
        SceneManager.LoadScene("game_scene");
        gameOver_Decide(false);
    }

    public void show_PointBox(bool decide)
    {
        pointBox_Panel.SetActive(decide);
    }
        
    public void exitGame()
    {
        Application.Quit();
    }

    public void startgame()
    {
        SceneManager.LoadScene("game_scene");
    }



    
}
