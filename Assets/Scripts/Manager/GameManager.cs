using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private SCInputBinds _inputBinds;
    private SCInput _inputsCombo;

    public SCInputBinds InputBinds => _inputBinds;
    public SCInput InputsCombo => _inputsCombo;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
        LoadBindings();
        _inputsCombo = Resources.Load<SCInput>("ScriptableObject/Inputs/Inputs");
        if (_inputsCombo == null) {
            Debug.LogError("Inputs not found");
        }
    }

    private void Start()
    {
        
    }

    private void LoadBindings()
    {
        _inputBinds = Resources.Load<SCInputBinds>("ScriptableObject/Binds/ComputerInput");
        
        if (_inputBinds == null) {
            Debug.LogError("InputBinds not found");
        }
    }

    public InputBinds GetInputBinds(KeyInput input)
    {
        switch (input) {
            case KeyInput.Lever1Up:
                return _inputBinds.LeverOneUp;
            case KeyInput.Lever1Down:
                return _inputBinds.LeverOneDown;
            case KeyInput.Lever2Up:
                return _inputBinds.LeverTwoUp;
            case KeyInput.Lever2Down:
                return _inputBinds.LeverTwoDown;
            case KeyInput.WhiteArrowUp:
                return _inputBinds.WhiteArrowUp;
            case KeyInput.WhiteArrowRight:
                return _inputBinds.WhiteArrowRight;
            case KeyInput.WhiteButton:
                return _inputBinds.WhiteButton;
            case KeyInput.BlackArrowDown:
                return _inputBinds.BlackArrowDown;
            case KeyInput.BlackArrowLeft:
                return _inputBinds.BlackArrowLeft;
            case KeyInput.BlackButton:
                return _inputBinds.BlackButton;
            default:
                return null;
        }
    }
}
