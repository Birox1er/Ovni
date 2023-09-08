using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _teddys;
    [SerializeField] private GameObject[] _spawnPartPoints;
    [SerializeField] private Material _highLightMaterial;
    private List<InputCombinaison> _inputCombinaisons;
    private TeddysManager _teddyTobuild;
    private TeddysManager _teddysPart;
    private TeddysManager _teddyHighlight;
    [SerializeField]private ScoreOther playerScore;

    private int _partIndex;
    private Coroutine _fallingPartCoroutine;
    private float _time;

    public List<InputCombinaison> InputCombinaisons { get => _inputCombinaisons; }
    public int PartIndex { get => _partIndex; }
    public TeddysManager TeddyTobuild { get => _teddyTobuild; }
    

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        int pickedIndex = Random.Range(0, _teddys.Length);

        Debug.Log("Init()");
        _partIndex = 0;
        _teddyTobuild = Instantiate(_teddys[pickedIndex], transform.position, _teddys[pickedIndex].transform.rotation).GetComponent<TeddysManager>();
        _teddysPart = Instantiate(_teddys[pickedIndex], _spawnPartPoints[_partIndex].transform.position, _teddys[pickedIndex].transform.rotation).GetComponent<TeddysManager>();
        _teddyHighlight = Instantiate(_teddys[pickedIndex], transform.position, _teddys[pickedIndex].transform.rotation).GetComponent<TeddysManager>();
        _teddyHighlight.GetComponent<Collider>().enabled = false;
        _teddysPart.GetComponent<Collider>().enabled = false;
        foreach (MeshRenderer renderer in _teddyHighlight.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.material = _highLightMaterial;
        }

        _teddyTobuild.gameObject.name = "ToBuild";
        _teddysPart.gameObject.name = "Part";
        _teddyHighlight.gameObject.name = "Highlight";

        _teddyTobuild.DeactivateAllParts();
        _teddysPart.DeactivateAllParts();
        Destroy(_teddysPart.GetComponent<Move>());
        _teddyHighlight.ActivateAllParts();
        _teddysPart.ActivatePartsByIndex(_partIndex);
        _inputCombinaisons = GameManager.Instance.InputsCombo.GenerateList();
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
        _teddysPart.GetComponent<Collider>().enabled = false;
        if (_teddyHighlight.TeddyParts[index].IsActivated == true)
        {
            _teddyHighlight.DeactivatePartsByIndex(index);
            _teddyTobuild.ActivatePartsByIndex(index);
        }
    }

    private void Update()
    {
        if (_partIndex >= 3)
            return;
        FallingPart(4f);
        if (InputHandler.HandleInput(_inputCombinaisons[_partIndex])) {
            if (_teddyTobuild.isInArea) {
                InitPart(_partIndex % _teddysPart.TeddyParts.Count);
                _time = 0f;
                _partIndex++;
                if (_partIndex == 3)
                {
                    playerScore.AddScore();
                }
            }
            
        }
    }

    private void FallingPart(float delay)
    {
        //Lerp position on Y axis with lerp
        int index = _partIndex % _teddysPart.TeddyParts.Count;
        Vector3 start = _spawnPartPoints[_partIndex].transform.position;
        Vector3 end = _teddyTobuild.transform.position;
        float ratio = 0f;

        if (_time <= delay) {
            ratio = _time / delay;
            _teddysPart.transform.position = new Vector3(start.x, Mathf.Lerp(start.y, end.y, ratio), start.z);
            _time += Time.deltaTime;
        } else {
            _teddysPart.transform.position = new Vector3(start.x, end.y, start.z);
        }
    }
}
