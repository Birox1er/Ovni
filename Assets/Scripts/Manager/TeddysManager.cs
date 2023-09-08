using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddysManager : MonoBehaviour
{
    [SerializeField] private List<TeddysPart> _teddyParts;

    public List<TeddysPart> TeddyParts { get => _teddyParts; }

    public void ActivatePartsByIndex(int index)
    {
        index = index % TeddyParts.Count;

        TeddyParts[index].activatePart();
    }

    public void DeactivatePartsByIndex(int index)
    {
        index = index % TeddyParts.Count;

        TeddyParts[index].deactivatePart();
    }

    public void ActivateAllParts()
    {
        foreach (var part in TeddyParts)
            part.activatePart();
    }

    public void DeactivateAllParts()
    {
        foreach (var part in TeddyParts)
            part.deactivatePart();
    }
}

[System.Serializable]
public class TeddysPart
{
    [SerializeField] private List<GameObject> _parts;
    private bool _isActivated;

    public List<GameObject> Parts { get => _parts; }
    public bool IsActivated { get => _isActivated; }

    public void activatePart()
    {
        foreach (var part in _parts)
            part.SetActive(true);
        _isActivated = true;
    }

    public void deactivatePart()
    {
        foreach (var part in _parts)
            part.SetActive(false);
        _isActivated = false;
    }
}