using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldCounter : MonoBehaviour
{
    public float timeStart = 15f;
    public Text shieldCounter;

    // Start is called before the first frame update
    void Start()
    {
        shieldCounter.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        if(timeStart <= 0)
        {
            timeStart = 15f;
        }

        shieldCounter.text = Mathf.Round(timeStart).ToString();

    }
}
