using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Move teddy = other.GetComponent<Move>();
        if (teddy == null)
        {
            return;
        }
        other.GetComponent<Move>().SelfDestruct();
    }
}
