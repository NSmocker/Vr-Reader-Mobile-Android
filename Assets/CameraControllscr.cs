using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraControllscr : MonoBehaviour
{
   public List<RaycastResult> results;
    public Vector3 delta, lastEuler;
    public VrInputModule module;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {


        
        transform.eulerAngles += new Vector3(-Input.gyro.rotationRateUnbiased.x * 5,0, 0);
        transform.eulerAngles += new Vector3(0, -Input.gyro.rotationRateUnbiased.y * 5, 0);


        module.m_ClickAction = false;
       if (Input.GetButtonDown("Fire1") ){ module.m_ClickAction = true; }
        if (Input.touchCount > 0){ module.m_ClickAction = true; }







        if (Input.GetButton("Fire2")) transform.eulerAngles = Vector3.zero;



    }
}
