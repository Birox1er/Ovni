using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Inputs", menuName = "Ovni/New Input Combinaison", order = 0)]
public class SCInput : ScriptableObject
{
    [SerializeField] private List<InputCombinaison> _inputsCombinaisons = new List<InputCombinaison>();

    public List<InputCombinaison> InputsCombinaisons { get => _inputsCombinaisons; set => _inputsCombinaisons = value; }
}

[System.Serializable]
public class InputCombinaison
{
    [SerializeField] private List<Inputs> _inputCombinaisonAxis;
    [SerializeField] private List<Bind> _bind;

    public List<Inputs> InputCombinaisonAxis { get => _inputCombinaisonAxis; set => _inputCombinaisonAxis = value; }
    public List<Bind> Bind { get => _bind; set => _bind = value; }

    public InputCombinaison()
    {
        _inputCombinaisonAxis = new List<Inputs>();
        _bind = new List<Bind>();
    }
}

[System.Serializable]
public class Inputs
{
    [SerializeField] private KeyInput _inputAxis;
    [SerializeField, Range(-1f, 1f)] private float _value;

    public KeyInput InputAxis { get => _inputAxis; set => _inputAxis = value; }
    public float Value { get => _value; set => _value = value; }
}

public enum KeyInput
{
    Lever1Up,
    Lever1Down,
    Lever2Up,
    Lever2Down,
    WhiteArrowUp,
    WhiteArrowRight,
    WhiteButton,
    BlackArrowDown,
    BlackArrowLeft,
    BlackButton,
}

public enum Bind
{
    And,
    Or
}