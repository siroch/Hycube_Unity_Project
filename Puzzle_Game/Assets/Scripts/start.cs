using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    //public void start_button()
    //{
    //    Invoke("start_Game", .3f);
    //}

    //public void option_button()
    //{
    //    Invoke("go_option", .3f);
    //}

    // Update is called once per frame
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