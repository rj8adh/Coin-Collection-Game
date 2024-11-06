using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    // max time in seconds
    public float maxTime = 60;
    public Text timeText;
    public Text coinText;

    // force variable to be seen in unity
    [SerializeField] private float countDown = 0f;

    void Start()
    {
        countDown = maxTime;
    }

    void Update()
    {
        // reduce time by  1 for every real-time second that passes
        countDown -= Time.deltaTime;

        // restart the level if the timer gets to 0
        if (countDown <= 0)
        {
            // reset the coin count
            Coin.coinCount = 0;
            //SceneManager.LoadScene("Scene01");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        timeText.text = "Time: " + countDown.ToString();
    }
}
