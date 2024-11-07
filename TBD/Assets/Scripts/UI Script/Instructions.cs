using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public int curPage;
    public int maxPage;
    // Start is called before the first frame update
    void Start()
    {
        curPage = 0;
        maxPage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextPage()
    {
        if(curPage == maxPage)
            return;
        string oldPage = curPage.ToString();
        GameObject.Find(oldPage).GetComponent<SpriteRenderer>().sortingOrder = 0;
        curPage += 1;
        string newPage = curPage.ToString();
        GameObject.Find(newPage).GetComponent<SpriteRenderer>().sortingOrder = 4;
    }
    public void previousPage()
    {
        if (curPage == 0)
            return;
        string oldPage = curPage.ToString();
        GameObject.Find(oldPage).GetComponent<SpriteRenderer>().sortingOrder = 0;
        curPage -= 1;
        string newPage = curPage.ToString();
        GameObject.Find(newPage).GetComponent<SpriteRenderer>().sortingOrder = 4;
    }
}
