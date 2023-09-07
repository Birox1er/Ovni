using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOther : MonoBehaviour
{
    [SerializeField]private float frequence;
    [SerializeField] private string npcName;
    private float time;
    private int score;
    private TextMeshProUGUI textScore;

    public int Score { get => score;}

    private void Start()
    {
        score = 0;
        time = 0;
        textScore= GetComponent<TextMeshProUGUI>();
        textScore.text = npcName + " : " + score;
    }
    void Update()
    {
        time += Time.deltaTime;
        float rand = Random.Range(0.85f, 1.16f);
        if (time >= frequence*rand && frequence!=0 )
        {
            
            AddScore();
            time = 0;          
        }
        textScore.text = npcName + " : " + score;
    }
    public void AddScore()
    {
        score += 1;
    }
    public void RemoveScore()
    {
        if (score > 0)
        {
            score -= 1;
        }
    }
}
