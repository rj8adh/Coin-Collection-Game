using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    // public is accessibility, shown in unity inspector, other scripts can use it*
    // static = variable will be shared across multiple copies of the script
    // int = type of variable
    // coinCount = name of the variable
    // 0 = initial value assigned to the variable

    public static int coinCount = 0;
    public Text coinText;
    public SceneScriptManage sceneResetter;

    private void Awake()
    {
        Coin.coinCount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        ++Coin.coinCount;
        coinText.text = "Coins Left: " + coinCount.ToString();
        Debug.Log("Current count of coins:  " + coinCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (coinCount == 0)
        {
            coinText.text = "ALL COINS COLLECTED";
        }
    }

    private void OnDestroy()
    {
        --Coin.coinCount;
        Debug.Log("Coin count: " + coinCount);

        if (coinCount <= 0)
        {
            Debug.Log("ALL COINS COLLECTED");
            // game is won. destroy the timer and launch fireworks
            GameObject timer = GameObject.Find("LevelTimer");
            sceneResetter.Restart();
            Destroy(timer);

            GameObject[] FireWorkSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach(GameObject GO in  FireWorkSystems)
            {
                GO.GetComponent<ParticleSystem>().Play();
            }
        }

        coinText.text = "Coins Left: " + coinCount.ToString();

    }
}
