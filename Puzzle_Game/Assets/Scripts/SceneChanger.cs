using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static bool Difficulty; // easy면 false, hard면 true

    public void GoSelectDifficulty() // 난이도 설정창 들어가는 함수
    {
        SceneManager.LoadScene("SelectDifficulty");
    }

    public void GoEasyStages() // 쉬움 난이도를 선택했을 때
    {
        SceneManager.LoadScene("EasyStages");
        Difficulty = false;
    }

    public void GoHardStages() // 어려움 난이도를 선택했을 때
    {
        SceneManager.LoadScene("HardStages");
        Difficulty = true;
    }

    public void GoMainMenu() // 메인메뉴로 돌아가는 함수
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackStage()
    {
        if(!Difficulty)
        {
            SceneManager.LoadScene("EasyStages");
        }
        else
        {
            SceneManager.LoadScene("HardStages");
        }
    }

    public void game_quit() // 게임 종료
    {
        Application.Quit();
    }
}
