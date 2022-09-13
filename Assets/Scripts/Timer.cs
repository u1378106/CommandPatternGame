using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeLeft = 3.5f;
    public TextMeshProUGUI startText; // used for showing countdown from 3, 2, 1 


    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            startText.text = "Timer : " + (timeLeft).ToString("0");
            if (timeLeft < 0)
            {

            }
        }
    }
}