using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(MonsterAbility))]
public class MonsterAbilityDrawer : PropertyDrawer
{
    private SerializedProperty _name;
    private SerializedProperty _damage;
    private SerializedProperty _element;

    // how to draw to the Inspector window
    public override void OnGUI(Rect position, 
        SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // fill our properties
        _name = property.FindPropertyRelative("_name");
        _damage = property.FindPropertyRelative("_damage");
        _element = property.FindPropertyRelative("_element");

        // drawing instructions here
        Rect foldOutBox = new Rect(position.min.x, position.min.y,
            position.size.x, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);

        if (property.isExpanded)
        {
            // draw our properties
            DrawNameProperty(position);
            DrawDamageProperty(position);
            DrawElementProperty(position);
        }

        EditorGUI.EndProperty();
    }

    // request more vertical spacing, return it
    public override float GetPropertyHeight
        (SerializedProperty property, GUIContent label)
    {
        int totalLines = 1;

        // increase our height if we expand arrow
        if (property.isExpanded)
        {
            totalLines += 3;
        }

        return (EditorGUIUtility.singleLineHeight * totalLines);
    }

    private void DrawNameProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 60;
        float xPos = position.min.x;
        float yPos = position.min.y + EditorGUIUtility.singleLineHeight;
        float width = position.size.x * .4f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPos, yPos, width, height);
        EditorGUI.PropertyField(drawArea, _name, new GUIContent("Name"));
    }

    private void DrawDamageProperty(Rect position)
    {
        Rect drawArea = new Rect(position.min.x + (position.width * .5f),
            position.min.y + EditorGUIUtility.singleLineHeight,
            position.size.x * .5f, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(drawArea, _damage, new GUIContent("Damage"));
    }

    private void DrawElementProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 100;
        Rect drawArea = new Rect(position.min.x + (position.width * .3f),
            position.min.y + (EditorGUIUtility.singleLineHeight * 2),
            position.size.x * .7f, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(drawArea, _element, new GUIContent("Element Type:"));
    }
}
