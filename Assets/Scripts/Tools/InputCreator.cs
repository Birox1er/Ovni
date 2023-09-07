using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using NaughtyAttributes;

public class InputCreator : EditorWindow
{
    private string Path = "Assets/Resources/ScriptableObject/Inputs/";
    private string _extention = ".asset";
    private Vector2 _windowSize;

    private SCInput _inputs;
    private InputCombinaison _editedCombinaison = new InputCombinaison();

    [MenuItem("GodMother/Input Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(InputCreator), false, "Input Creator");
    }

    private void OnGUI()
    {
        InitGUI();
        LoadInputs();
        OnGUIUpdate();
    }

    private void InitGUI()
    {
        _windowSize = new Vector2(position.width, position.height);
    }

    private void OnGUIUpdate()
    {
        EditorGUILayout.BeginHorizontal(SetOptionSize(_windowSize.x, _windowSize.x, _windowSize.y, _windowSize.y));
        DisplayInputList();
        DisplayCombinaisons();
        EditorGUILayout.EndHorizontal();
    }

    private void DisplayInputList()
    {
        EditorGUILayout.BeginVertical(SetOptionSize(200, 200, _windowSize.y, _windowSize.y));
        GUILayout.Label("Input List:", EditorStyles.boldLabel);
        if (GUILayout.Button("New Entry", SetOptionSize(200, 200, 20, 20))) {
            _editedCombinaison = new InputCombinaison();
            _inputs.InputsCombinaisons.Add(_editedCombinaison);
        }
        for (int i = 0; i < _inputs.InputsCombinaisons.Count; i++) {
            DisplayListElement(_inputs.InputsCombinaisons[i], i);
        }
        EditorGUILayout.EndVertical();
    }

    private void DisplayListElement(InputCombinaison combinaison, int index)
    {
        EditorGUILayout.BeginHorizontal(SetOptionSize(200, 200, 20, 20));
        if (GUILayout.Button("Edit", SetOptionSize(50, 50, 20, 20)))
            _editedCombinaison = combinaison;
        GUILayout.Label($"Combinaison ({index})", EditorStyles.boldLabel);
        if (GUILayout.Button("-", SetOptionSize(50, 50, 20, 20)))
            Debug.Log("Delete");
        EditorGUILayout.EndHorizontal();
    }

    private void DisplayCombinaisons()
    {
        EditorGUILayout.BeginVertical(SetOptionSize(200, 200, _windowSize.y, _windowSize.y));
        GUILayout.Label("Combinaison:", EditorStyles.boldLabel);
        for (int i = 0; i < _editedCombinaison.InputCombinaisonAxis.Count; i++) {
            EditorGUILayout.BeginHorizontal(SetOptionSize(200, 200, 20, 20));
            EditorGUILayout.LabelField("Input: ");
            _editedCombinaison.InputCombinaisonAxis[i].InputAxis = (KeyInput)EditorGUILayout.EnumPopup(_editedCombinaison.InputCombinaisonAxis[i].InputAxis);
            _editedCombinaison.InputCombinaisonAxis[i].Value = EditorGUILayout.FloatField(_editedCombinaison.InputCombinaisonAxis[i].Value);
            if (GUILayout.Button("X", SetOptionSize(20, 20, 20, 20))) {
                _editedCombinaison.InputCombinaisonAxis.RemoveAt(i);
                if (_editedCombinaison.Bind.Count > 0) {
                    _editedCombinaison.Bind.RemoveAt(_editedCombinaison.Bind.Count - 1);
                }
            }
            EditorGUILayout.EndHorizontal();
            if (_editedCombinaison.Bind.Count > i) {
                EditorGUILayout.BeginHorizontal(SetOptionSize(40, 40, 20, 20));
                EditorGUILayout.LabelField("Bind: ");
                _editedCombinaison.Bind[i] = (Bind)EditorGUILayout.EnumPopup(_editedCombinaison.Bind[i]);
                EditorGUILayout.EndHorizontal();
            }
        }
        if (GUILayout.Button("Add Input", SetOptionSize(340, 340, 20, 20))) {
            _editedCombinaison.InputCombinaisonAxis.Add(new Inputs());
            if (_editedCombinaison.InputCombinaisonAxis.Count > 1) {
                _editedCombinaison.Bind.Add(Bind.And);
            }
        }
        if (GUILayout.Button("Save", SetOptionSize(340, 340, 20, 20))) {
            SaveInputs();
        }
        EditorGUILayout.EndVertical();
    }

    private void DisplayInput(Input input)
    {

    }

    private void LoadInputs()
    {
        SCInput inputs = Resources.Load<SCInput>("ScriptableObject/Inputs/Inputs");
        
        _inputs = inputs;
    }

    private void SaveInputs()
    {
        string path = $"{Path}Inputs{_extention}";

        if (!File.Exists(path)) {
            Debug.Log("Input doesn't exists");
            AssetDatabase.CreateAsset(_inputs, path);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    #region GUIoptions
    public static GUILayoutOption[] SetOptionSize(int minWidth, int maxWidth, int minHeight, int maxHeight, int width = 0, int height = 0)
    {
        if (width == 0 || height == 0)
            return new GUILayoutOption[] {
            GUILayout.MinWidth(minWidth),
            GUILayout.MaxWidth(maxWidth),
            GUILayout.MinHeight(minHeight),
            GUILayout.MaxHeight(maxHeight)
        };
        return new GUILayoutOption[] {
            GUILayout.MinWidth(minWidth),
            GUILayout.MaxWidth(maxWidth),
            GUILayout.MinHeight(minHeight),
            GUILayout.MaxHeight(maxHeight),
            GUILayout.Width(width),
            GUILayout.Height(height)
        };
    }

    public static GUILayoutOption[] SetOptionSize(float minWidth, float maxWidth, float minHeight, float maxHeight, float width = 0, float height = 0)
    {
        if (width == 0 || height == 0)
            return new GUILayoutOption[] {
            GUILayout.MinWidth(minWidth),
            GUILayout.MaxWidth(maxWidth),
            GUILayout.MinHeight(minHeight),
            GUILayout.MaxHeight(maxHeight)
        };
        return new GUILayoutOption[] {
            GUILayout.MinWidth(minWidth),
            GUILayout.MaxWidth(maxWidth),
            GUILayout.MinHeight(minHeight),
            GUILayout.MaxHeight(maxHeight),
            GUILayout.Width(width),
            GUILayout.Height(height)
        };
    }
    #endregion //GUIoptions
}