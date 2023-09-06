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

    public List<Inputs> InputCombinaisonAxis { get => _inputCombinaisonAxis; set => _inputCombinaisonAxis = value; }
}

[System.Serializable]
public class Inputs
{
    [SerializeField, InputAxis] private string _inputAxis;
    [SerializeField, Range(-1f, 1f)] private float _value;

    public string InputAxis { get => _inputAxis; set => _inputAxis = value; }
    public float Value { get => _value; set => _value = value; }
}