using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classement : MonoBehaviour
{
    private List<ScoreOther> list=new List<ScoreOther>();
    private float time;

    private void Start()
    {
        time = 0;
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).GetComponent<ScoreOther>())
                list.Add(transform.GetChild(i).GetComponent<ScoreOther>());
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            int tmp;
            for (int i = 1; i < list.Count; ++i)
            {
                tmp = list[i].Score;
                int index = i;
                while (index > 0 && tmp < list[index - 1].Score)
                {
                    ScoreOther x = list[i];
                    list[i] = list[i - 1];
                    list[i - 1] = x;
                    --index;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].transform.localPosition = new Vector3(0, Mathf.Lerp(-130, 170, (float)i / (float)(list.Count-1)), 0);
            }
            time = 0;
        }
    }
}
