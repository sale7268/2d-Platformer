using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 100f;

    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Debug.Log("Time over, you Failed");
            Application.Quit();
        }
        string timez = currentTime.ToString();
        string finalTime = "";
        finalTime += timez[0].ToString();
        finalTime += timez[1].ToString();
        timer.GetComponent<TextMeshProUGUI>().text = finalTime;
    }
}
