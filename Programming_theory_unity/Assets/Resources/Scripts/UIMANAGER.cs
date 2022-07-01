using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMANAGER : MonoBehaviour
{
    //for choosing player
    [SerializeField]
    private Toggle speed_toggle;
    [SerializeField]
    private Toggle strong_toggle;

    //for choosing difficulty
    [SerializeField]
    private Slider difficulty_slider;

    //for entering name
    [SerializeField]
    private InputField player_inputName;

    //for shwoing high score
    [SerializeField]
    private TMP_Text game_highScore;

    [SerializeField]
    private GameObject game_helpPanel;


    //method gets information from choosen player and allows only one to be selected

    //method will be used by the toggles when they changed

    private void Start()
    {
        get_DataScript().LoadData();
        set_HighScore();
        first_TimePlaying();
    }
    public void get_PlayerChoice()
    {
        get_playerInGameChoice(); 

        int tempSelect = get_DataScript().selectedPlayer;
        if (tempSelect == 0)
        {
            strong_toggle.isOn = false;
            speed_toggle.isOn = true;
            get_DataScript().selectedPlayer = 0;
        }
        else 
        {
            strong_toggle.isOn = true;
            speed_toggle.isOn = false;
            get_DataScript().selectedPlayer = 1;
        }
   
    }

    private void get_playerInGameChoice()
    {
        if (speed_toggle.isOn)
        {
            get_DataScript().selectedPlayer = 0;
        }
        else { 
            get_DataScript().selectedPlayer = 1;
        }
    }

    //method returns the game data script
    private datamanager get_DataScript()
    {
        return datamanager.instance;
    }

    //get the players name and stores it
    public void name_Input()
    {
        get_DataScript().playerName = player_inputName.text;
    }

    //set the text on the UI to the player with highest score with name as well.
    private void set_HighScore()
    {
        game_highScore.text = get_DataScript().high_player + "             " + get_DataScript().highScore + "XP";
    }

    //get the difficulty level and stores it to use and optimize the game
    public void get_Difficulty()
    {
        get_DataScript().difficulty = difficulty_slider.value;
    }

    //shows the help panel the first time
    public void first_TimePlaying()
    {
        if(get_DataScript().showHelp)
        {
            game_helpPanel.SetActive(true);
        }
        else
        {
            game_helpPanel.SetActive(false);
        }
    }

    //method diactives the help panel when the close button is click;
    public void close_HelpPanel()
    {
        game_helpPanel.SetActive(false);
        get_DataScript().showHelp = false;
    }

    private void OnMouseDrag()
    {
        difficulty_slider.value = get_DataScript().difficulty;
        get_Difficulty();
    }




}
