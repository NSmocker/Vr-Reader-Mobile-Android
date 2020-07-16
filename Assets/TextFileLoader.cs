using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using uFileBrowser;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextFileLoader : MonoBehaviour
{
    public string text;
    public FileBrowser browser;
    public TMP_InputField book_text;
    public List<string> pages = new List<string>();
    public int line_counter=0;
    public int pages_count;

    [Header("Display page")]
    public int current_page;
    public Text current_page_ui;
    public Text title_ui;





    public bool Book_is_Loaded;



    public void NextPage() 
    {
        if (Book_is_Loaded) 
        {
            current_page++;
            DisplayCurrentPage();
        }
    }
    public void PrevPage()
    {
        if (Book_is_Loaded)
        {
            current_page--;
            DisplayCurrentPage();
        }
    }

    public void DisplayCurrentPage() 
    {
        if (Book_is_Loaded) 
        {
            if (current_page > pages_count) current_page = pages_count;
            if (current_page < 0) current_page = 0;

            try { book_text.text = pages[current_page]; }
            catch (Exception e) { book_text.text = e.Message;  }



        }
    }
    // Start is called before the first frame update
    IEnumerator Fade()
    {
        var fs = new FileStream(browser.AddressPath + browser.FileName, FileMode.Open, FileAccess.Read);
        var sr = new StreamReader(fs, Encoding.UTF8);

        string line = String.Empty;

        while ((line = sr.ReadLine()) != null)
        {

            text += line;
            line_counter++;

            if (line_counter >= 50) 
            {
                line_counter = 0;
                pages.Add(text);
                text = "";
            }

        }
        line_counter = 0;
        pages.Add(text);
        text = "";
        pages_count = pages.Count;
        book_text.text = pages[0];
        Book_is_Loaded = true;
        title_ui.text = browser.FileName;
        yield return null;
    }
    public void LoadFileToBook() 
    {
        StartCoroutine(Fade());      
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        current_page_ui.text = current_page.ToString();
        
    }
}
