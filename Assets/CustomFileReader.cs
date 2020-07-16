using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class CustomFileReader : MonoBehaviour
{

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        string[] fileEntries = Directory.GetFiles("/storage/emulated/0");
        foreach (string x in fileEntries) text.text+=x+"\n";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
