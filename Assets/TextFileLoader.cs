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
    public TMP_Text book_text;
    public List<string> pages = new List<string>();
    public int line_counter = 0;
    public int pages_count;

    [Header("Display page")]
    public int current_page;
    public TMP_Text current_page_ui;
    public TMP_Text title_ui;





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

            current_page_ui.text = current_page.ToString();
            try { book_text.text = pages[current_page]; }
            catch (Exception e) { book_text.text = e.Message; }



        }
    }
    // Start is called before the first frame update
   
    public void LoadFileToBook()
    {
        var fs = new FileStream(browser.AddressPath + browser.FileName, FileMode.Open, FileAccess.Read);
        var sr = new StreamReader(fs, Encoding.UTF8);

        string line = String.Empty;

        while ((line = sr.ReadLine()) != null)
        {

            text += line;
       

            if (text.Length >= 900)
            {
                //line_counter = 0;
                pages.Add(text);
                text = "";
            }

        }
        fs.Close();
        line_counter = 0;
        pages.Add(text);
        text = "";
        pages_count = pages.Count;
        book_text.text = pages[0];
        Book_is_Loaded = true;
        title_ui.text = browser.FileName;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

    }
}