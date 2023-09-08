using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    private static WorkZone _instance;

    [SerializeField] private Spawner spawn;
    [SerializeField] private LedPanel panel;
    [SerializeField] private ComboUI comboDisplay;
    private TeddysManager _teddy;

    public TeddysManager Teddy { get => _teddy; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In");
        _teddy = other.GetComponent<TeddysManager>();
        if (_teddy == null)
        {
            return;
        }
        int nbParts = other.GetComponent<TeddysManager>().TeddyParts.Count;
        _teddy.isInArea = true;
        //other.GetComponent<Sequence>().IsInWorkZone = true;
        Debug.Log("is in work zone");
        //activate whatever the comboUi does
        panel.NewPeluche(nbParts);
    }

    private void OnTriggerExit(Collider other)
    {
        _teddy = other.GetComponent<TeddysManager>();
        if (_teddy == null)
        {
            return;
        }
        _teddy.isInArea = false;
        spawn.Init();
    }
}
