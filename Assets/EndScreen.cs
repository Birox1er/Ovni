using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EndScreen : MonoBehaviour
{
    [SerializeField]private ScoreOther score;
    [SerializeField]private TextMeshProUGUI textScore;


    private void Update()
    {
        textScore.text = " " + score.Score + " Teddy built ! ";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
