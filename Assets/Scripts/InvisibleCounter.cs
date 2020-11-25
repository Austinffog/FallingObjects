using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleCounter : MonoBehaviour
{
    public float timeStart = 30f;
    public Text invisibleCounter;

    // Start is called before the first frame update
    void Start()
    {
        invisibleCounter.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        if (timeStart <= 0)
        {
            timeStart = 30f;
        }
        invisibleCounter.text = Mathf.Round(timeStart).ToString();
    }
}
