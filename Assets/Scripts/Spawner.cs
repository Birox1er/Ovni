using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> Peluches = new List<GameObject>();

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int rand = Random.Range(0, Peluches.Count);
        Instantiate(Peluches[rand], transform);
    }
}
