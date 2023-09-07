using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    [SerializeField] private Spawner spawn;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is in work zone");
        spawn.Spawn();
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out of work zone");
        other.GetComponent<Move>().SelfDestruct();
    }
}
