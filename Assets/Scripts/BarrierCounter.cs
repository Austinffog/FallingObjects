using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierCounter : MonoBehaviour
{
    public float timeStart = 180f;
    public Text barrierCounter;

    // Start is called before the first frame update
    void Start()
    {
        barrierCounter.text = timeStart.ToString(); //convert float to string
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        if (timeStart <= 0)
        {
            timeStart = 180f;
        }
        barrierCounter.text = Mathf.Round(timeStart).ToString();

    }
}
