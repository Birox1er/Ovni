using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOther : MonoBehaviour
{
    [SerializeField]private float frequence;
    [SerializeField] private string name;
    private float time;
    private int score;
    private TextMeshProUGUI textScore;

    public int Score { get => score;}

    private void Start()
    {
        score = 0;
        time = 0;
        textScore= GetComponent<TextMeshProUGUI>();
        textScore.text = name + " : " + score;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= frequence /*&& is not player*/ )
        {
            score += 1;
            time = 0;          
        }
        textScore.text = name + " : " + score;
    }
}
