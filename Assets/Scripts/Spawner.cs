using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _teddys;
    [SerializeField] private GameObject[] _spawnPartPoints;

    private TeddysManager _teddyTobuild;
    private TeddysManager _teddysPart;
    private TeddysManager _teddyHighlight;

    private int _partIndex;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        int pickedIndex = Random.Range(0, _teddys.Length);

        _partIndex = 0;
        _teddyTobuild = Instantiate(_teddys[pickedIndex], transform.position, Quaternion.identity).GetComponent<TeddysManager>();
        _teddysPart = Instantiate(_teddys[pickedIndex], _spawnPartPoints[_partIndex].transform.position, Quaternion.identity).GetComponent<TeddysManager>();
        _teddyHighlight = Instantiate(_teddys[pickedIndex], transform.position, Quaternion.identity).GetComponent<TeddysManager>();

        _teddyTobuild.gameObject.name = "ToBuild";
        _teddysPart.gameObject.name = "Part";
        _teddyHighlight.gameObject.name = "Highlight";

        _teddyTobuild.DeactivateAllParts();
        _teddysPart.DeactivateAllParts();
        _teddyHighlight.ActivateAllParts();
        _teddysPart.ActivatePartsByIndex(_partIndex);
    }

    private void Reset()
    {
        Destroy(_teddyTobuild.gameObject, 0f);
        Destroy(_teddysPart.gameObject, 0f);
        Destroy(_teddyHighlight.gameObject, 0f);
    }

    private void InitPart(int index)
    {
        Debug.Log("InitPart");
        _teddysPart.DeactivateAllParts();
        _teddysPart.ActivatePartsByIndex((index + 1) % _teddysPart.TeddyParts.Count);
        _teddysPart.transform.position = _spawnPartPoints[(index + 1) % _teddysPart.TeddyParts.Count].transform.position;
        if (_teddyHighlight.TeddyParts[index].IsActivated == true)
            _teddyHighlight.DeactivatePartsByIndex(index);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            InitPart(_partIndex % _teddysPart.TeddyParts.Count);
            _partIndex++;
        }
        if (_partIndex > 3) {
            Reset();
            Init();
        }
    }
}
