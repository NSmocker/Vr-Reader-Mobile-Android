using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonTester : MonoBehaviour
{

    public TextMeshProUGUI text_totest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text_totest.text = "Button Fire1 is:" + Input.GetButton("Fire1").ToString();

        if (Input.GetButtonDown("Fire1") || Input.touchCount > 0)
        { VrInputModule.m_ClickAction = true; }
        else { VrInputModule.m_ClickAction = false; }


    }
}
