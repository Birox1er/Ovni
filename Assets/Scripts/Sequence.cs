using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    private bool isInWorkZone;
    private ScoreOther joueur;
    private LedPanel led;
    private int validated;
    private bool inFabrication;
    /*voir comment afficher les combos (mettre image dans les enfants ou autre).
     * avec peut être ici la connaissance du sprite actuel et l'ui qui le recupère
     */
    public bool IsInWorkZone { get => isInWorkZone; set => isInWorkZone = value; }

    void Start()
    {
        validated = 0;
        isInWorkZone = false;
        inFabrication = false;
    }

    void Update()
    {
        if (isInWorkZone)
        {
            //set le combo à faire
            if(inFabrication == false)
            {
                StartCoroutine(Fabrication());
            }
            if (Input.GetAxis("WhiteButton") != 0)
            {
                if (validated == transform.childCount)
                {
                    joueur.AddScore();
                }
                else
                {
                    joueur.RemoveScore();
                }
            }  
        }
    }
    IEnumerator Fabrication()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
           //while combo de l'enfant i n'est pas réaliser ne pas passer au suivant
           //+ check si le combo est bon si ui ++validated
        }
        yield return null;
    }
}
