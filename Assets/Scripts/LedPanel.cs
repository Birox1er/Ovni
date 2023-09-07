using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedPanel : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Image> list = new List<Image>();
    int currentLed;

    private void Start()
    {
        currentLed = 0;
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).GetComponent<Image>())
                list.Add(transform.GetChild(i).GetComponent<Image>());
        }
    }
    public void NewPeluche(int nbrPart)
    {
        currentLed = 0;
        for(int i = 0;i<nbrPart; i++)
        {
            list[i].color = Color.white;
            if (i == 1)
            {
                list[2].color = Color.black;
            }
        }
        
    }
    public void ValidatePart(int nbrPart)
    {
        list[currentLed].color = Color.green;
        if (nbrPart == currentLed)
        {
            currentLed = 0;
        }
        else
        {
            currentLed++;
        }
    }
    public void FailedPart(int nbrPart)
    {
        list[currentLed].color = Color.red;
        if (nbrPart == currentLed)
        {
            currentLed = 0;
        }
        else
        {
            currentLed++;
        }
    }
}
