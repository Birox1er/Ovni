using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    [SerializeField] private Spawner spawn;
    [SerializeField] private LedPanel panel;
    [SerializeField] private ComboUI affichage;
    private void OnTriggerEnter(Collider other)
    {
        int a = other.transform.childCount;
        other.GetComponent<Sequence>().IsInWorkZone = true;
        Debug.Log("is in work zone");
        //activate whatever the comboUi does
        spawn.Spawn();
        panel.NewPeluche(a);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out of work zone");
        other.GetComponent<Move>().SelfDestruct();
    }
}
