using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScriptManage : MonoBehaviour
{
    public void Restart()
    {
        Invoke("DoomsDay", 5.0f);
    }
    public void DoomsDay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
