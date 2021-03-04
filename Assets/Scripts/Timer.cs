using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer sharedInstance;
    [SerializeField] GameObject textTimer;

    [HideInInspector]
    public float timer;
    [HideInInspector]
    public float minutes;
    [HideInInspector]
    public float seconds;
  
    private string displayTime;


    private void Awake()

    {
        sharedInstance = this;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        textTimer.GetComponent<Text>().text = displayTime;
        textTimer.GetComponent<Text>().color = new Color(146, 146, 146);
    }
}
