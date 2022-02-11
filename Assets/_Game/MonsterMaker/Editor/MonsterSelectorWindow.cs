using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class MonsterSelectorWindow : EditorWindow
{
    private MonsterType _selectedMonsterType = MonsterType.None;
    private MonsterType _previousSelectedMonsterType = MonsterType.None;
    private List<GameObject> _selectableGameObjects = new List<GameObject>();
    private int _selectionIndex = 0;

    [MenuItem("Window/Monster Selector")]
    public static void ShowWindow()
    {
        GetWindow<MonsterSelectorWindow>("Monster Selector");
    }

    private void OnGUI()
    {
        //window code goes here
        EditorGUILayout.Space(10);
        GUILayout.Label("Selection Filters:", EditorStyles.boldLabel);
        _selectedMonsterType = (MonsterType)EditorGUILayout.EnumPopup
            ("MonsterType to select:", _selectedMonsterType);
        UpdateSelectableIfSelectionChanged();


        EditorGUILayout.Space(5);
        if(GUILayout.Button("Select All"))
        {
            SelectAllMonsters();
        }

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Cycle Selection:");
        if (GUILayout.Button("Previous"))
        {
            SelectPrevious();
        }
        if (GUILayout.Button("Next"))
        {
            SelectNext();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void UpdateSelectableIfSelectionChanged()
    {
        if(_selectedMonsterType != _previousSelectedMonsterType)
        {
            UpdateSelectable();
            _previousSelectedMonsterType = _selectedMonsterType;
        }
    }

    private void SelectAllMonsters()
    {
        Selection.objects = _selectableGameObjects.ToArray();
    }

    private void SelectNext()
    {
        // check if list is valid
        if(_selectableGameObjects.Count <= 0)
        {
            return;
        }

        // if we're at the end, go back to the beginning
        if(_selectionIndex >= _selectableGameObjects.Count - 1)
        {
            _selectionIndex = 0;
        }
        // otherwise increase index to next one
        else
        {
            _selectionIndex++;
        }
        // ensure our next index object is valid
        if(_selectableGameObjects[_selectionIndex] != null)
        {
            Selection.activeObject = _selectableGameObjects[_selectionIndex];
        }
    }

    private void SelectPrevious()
    {
        if (_selectableGameObjects.Count <= 0)
            return;
        if (_selectionIndex <= 0)
            _selectionIndex = _selectableGameObjects.Count - 1;
        else
            _selectionIndex--;

        if(_selectableGameObjects[_selectionIndex] != null)
        {
            Selection.activeObject = _selectableGameObjects[_selectionIndex];
        }
    }

    private void UpdateSelectable()
    {
        _selectableGameObjects.Clear();
        // collect all the monsters in our scene
        Monster[] monsters = FindObjectsOfType<Monster>();
        // check each monster, store if type matches
        foreach (Monster monster in monsters)
        {
            if (monster.Data.MonsterType == _selectedMonsterType)
            {
                _selectableGameObjects.Add(monster.gameObject);
            }
        }
    }

    private void OnHierarchyChange()
    {
        UpdateSelectable();
    }
}
