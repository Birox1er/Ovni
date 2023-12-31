using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private EndScreen endScreen;
    private TextMeshProUGUI textTimer;
    private int baseTimer;
    private void Start()
    {
        baseTimer = (int)timer;
        textTimer = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        int day = (int)Mathf.Lerp(73, 0, timer/baseTimer);

        textTimer.text = "Day :" + day+" / 73";
        if (day >= 73)
        {
            endScreen.gameObject.SetActive(true);
        }
    }
}
