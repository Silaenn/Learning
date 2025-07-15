using System;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Weapon
{
    public string name;
    public int damage;
    [Range(0f, 1f)] public float accuracy;
}

[CustomPropertyDrawer(typeof(Weapon))]
public class WeaponDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        float fieldWidth = position.width / 3;
        Rect nameRect = new Rect(position.x, position.y, fieldWidth, position.height);
        Rect damageRect = new Rect(position.x + fieldWidth + 10, position.y, fieldWidth, position.height);
        Rect accuracyRect = new Rect(position.x + fieldWidth * 2, position.y, fieldWidth, position.height);

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(damageRect, property.FindPropertyRelative("damage"), GUIContent.none);
        EditorGUI.PropertyField(accuracyRect, property.FindPropertyRelative("accuracy"), GUIContent.none);

        EditorGUI.EndProperty();
    }
}
public class InspectorKustom : MonoBehaviour
{
    [SerializeField] Weapon primaryWeapon;
}
