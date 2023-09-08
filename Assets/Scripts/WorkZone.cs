using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    [SerializeField] private Spawner spawn;
    [SerializeField] private LedPanel panel;
    [SerializeField] private ComboUI comboDisplay;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In");
        TeddysManager teddy = other.GetComponent<TeddysManager>();
        if (teddy == null)
        {
            return;
        }
        int nbParts = other.GetComponent<TeddysManager>().TeddyParts.Count;
        spawn.Init();
        //other.GetComponent<Sequence>().IsInWorkZone = true;
        Debug.Log("is in work zone");
        //activate whatever the comboUi does
        panel.NewPeluche(nbParts);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out of work zone");
        other.GetComponent<Move>().SelfDestruct();
    }
}
