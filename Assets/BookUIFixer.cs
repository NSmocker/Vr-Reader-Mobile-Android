using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookUIFixer : MonoBehaviour
{
    public RectTransform[] allChildren;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        allChildren = GetComponentsInChildren<RectTransform>();
        foreach (RectTransform child in allChildren)
        {
            child.rotation = child.parent.rotation ;

        }
       
    }
}
