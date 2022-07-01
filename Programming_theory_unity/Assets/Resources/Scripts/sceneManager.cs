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



    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            mainMenu();
        }
    }
    //bring gameOver panel to visible.
    public void gameOver_Decide(bool decide)
    {
        gameOver_Panel.SetActive(decide);
    }

    public void mainMenu()
    {
        datamanager.instance.StoreData();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>().show_HighPlayer();
        SceneManager.LoadScene("MenuScene");
    }

    public void restartlevel()
    {
        gameOver_Decide(false);
        SceneManager.LoadScene("game_scene");
        
    }

    public void show_PointBox(bool decide)
    {
        pointBox_Panel.SetActive(decide);
    }
        
    public void exitGame()
    {
        datamanager.instance.StoreData();
        Application.Quit();
        
    }

    public void startgame()
    { 
        datamanager.instance.StoreData();
        datamanager.instance.LoadData();
        SceneManager.LoadScene("game_scene");
       
    }

   



    
}
