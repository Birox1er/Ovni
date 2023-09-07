using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    [SerializeField] private Spawner spawn;
    [SerializeField] private LedPanel panel;
    private void OnTriggerEnter(Collider other)
    {
        int a = other.transform.childCount;
        Debug.Log("is in work zone");
        spawn.Spawn();
        panel.NewPeluche(a);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out of work zone");
        other.GetComponent<Move>().SelfDestruct();
    }
}
