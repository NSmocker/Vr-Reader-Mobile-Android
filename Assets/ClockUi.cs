using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUi : MonoBehaviour
{
    public TextMeshPro clock_ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        clock_ui.text = System.DateTime.Now.ToString();
    }
}
