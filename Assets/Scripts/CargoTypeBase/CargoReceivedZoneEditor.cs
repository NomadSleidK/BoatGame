using System;
using System.Collections;
using UnityEditor;
using static CargoReceivedZone;

[CustomEditor(typeof(CargoReceivedZone))]
[CanEditMultipleObjects]
public class CargoReceivedZoneEditor : Editor
{
    private SerializedProperty property;
    private bool[] _cargoArray;


    private void OnEnable()
    {
        property = serializedObject.FindProperty(nameof(CargoReceivedZone._cargoList));
        _cargoArray = new bool[property.arraySize];      
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        for (int i = 0; i < property.arraySize; i++)
        {
            SerializedProperty ooc = property.GetArrayElementAtIndex(i);
            _cargoArray[i] = ooc.FindPropertyRelative(nameof(ReceivedCargoList.IsCargoActive)).boolValue;
        }

        for (int i = 0; i < property.arraySize; i++)
        {
            SerializedProperty ooc = property.GetArrayElementAtIndex(i);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(ooc.FindPropertyRelative(nameof(ReceivedCargoList.CargoName)).stringValue);
            _cargoArray[i] = EditorGUILayout.Toggle(_cargoArray[i]);

            EditorGUILayout.EndHorizontal();
        }

        for (int i = 0; i < property.arraySize; i++)
        {
            SerializedProperty ooc = property.GetArrayElementAtIndex(i);
            ooc.FindPropertyRelative(nameof(ReceivedCargoList.IsCargoActive)).boolValue = _cargoArray[i];
        }

        serializedObject.ApplyModifiedProperties();
    }
}
