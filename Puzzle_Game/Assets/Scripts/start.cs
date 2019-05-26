using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public void destroy_me()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    public void start_Game()
    {
        SceneManager.LoadScene("Selcet_Stage");
    }
}
