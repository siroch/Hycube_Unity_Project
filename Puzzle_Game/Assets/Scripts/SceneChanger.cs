using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoSelectDifficulty()
    {
        SceneManager.LoadScene("SelectDifficulty");
    }

    public void GoEasyStages()
    {
        SceneManager.LoadScene("EasyStages");
    }

    public void GoHardStages()
    {
        SceneManager.LoadScene("HardStages");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void game_quit()
    {
        Application.Quit();
    }
}
