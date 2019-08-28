using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static int CallStage;
    public static int StageNum;
    private bool Difficulty = SceneChanger.Difficulty;

    public void Btn1() { StageNum = 1; CallStage = 1; SceneManager.LoadScene("InGame"); }
    public void Btn2() { StageNum = 2; CallStage = 2; SceneManager.LoadScene("InGame"); }
    public void Btn3() { StageNum = 3; CallStage = 3; SceneManager.LoadScene("InGame"); }
    public void Btn4() { StageNum = 4; CallStage = 4; SceneManager.LoadScene("InGame"); }
    public void Btn5() { StageNum = 5; CallStage = 5; SceneManager.LoadScene("InGame"); }
    public void Btn6() { StageNum = 6; CallStage = 6; SceneManager.LoadScene("InGame"); }
    public void Btn7() { StageNum = 7; CallStage = 7; SceneManager.LoadScene("InGame"); }
    public void Btn8() { StageNum = 8; CallStage = 8; SceneManager.LoadScene("InGame"); }
    public void Btn9() { StageNum = 9; CallStage = 9; SceneManager.LoadScene("InGame"); }
    public void Btn10() { StageNum = 10; CallStage = 10; SceneManager.LoadScene("InGame"); }
}
