using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void start_Game()
    {
        SceneManager.LoadScene("Select_Stage");
    }

    public void go_option()
    {
        SceneManager.LoadScene("Option");
    }
    public void game_quit()
    {
        print("quit");
        Application.Quit(
           );
    }
}