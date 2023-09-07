using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Inputs Binds", menuName = "Ovni/New Input Binds", order = 1)]
public class SCInputBinds : ScriptableObject
{
    [SerializeField] private InputBinds _leverOneUp;
    [SerializeField] private InputBinds _leverOneDown;
    [SerializeField] private InputBinds _leverTwoUp;
    [SerializeField] private InputBinds _leverTwoDown;
    [SerializeField] private InputBinds _whiteArrowUp;
    [SerializeField] private InputBinds _whiteArrowRight;
    [SerializeField] private InputBinds _whiteButton;
    [SerializeField] private InputBinds _blackArrowDown;
    [SerializeField] private InputBinds _blackArrowLeft;
    [SerializeField] private InputBinds _blackButton;
    private const int _length = 10;

    public InputBinds LeverOneUp => _leverOneUp;
    public InputBinds LeverOneDown => _leverOneDown;
    public InputBinds LeverTwoUp => _leverTwoUp;
    public InputBinds LeverTwoDown => _leverTwoDown;
    public InputBinds WhiteArrowUp => _whiteArrowUp;
    public InputBinds WhiteArrowRight => _whiteArrowRight;
    public InputBinds WhiteButton => _whiteButton;
    public InputBinds BlackArrowDown => _blackArrowDown;
    public InputBinds BlackArrowLeft => _blackArrowLeft;
    public InputBinds BlackButton => _blackButton;
    public int Length => _length;

    public InputBinds this[int index]
    {
        get {
            switch (index) {
                case 0:
                    return _leverOneUp;
                case 1:
                    return _leverOneDown;
                case 2:
                    return _leverTwoUp;
                case 3:
                    return _leverTwoDown;
                case 4:
                    return _whiteArrowUp;
                case 5:
                    return _whiteArrowRight;
                case 6:
                    return _whiteButton;
                case 7:
                    return _blackArrowDown;
                case 8:
                    return _blackArrowLeft;
                case 9:
                    return _blackButton;
                default:
                    return null;
            }
        }
    }
}

[System.Serializable]
public class InputBinds
{
    [SerializeField] private KeyCode _buttonKeyCode;

    public KeyCode ButtonKeyCode => _buttonKeyCode;
}
