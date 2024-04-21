using UnityEditor;
using static CargoReceivedData;

[CustomEditor(typeof(CargoReceivedData))]
[CanEditMultipleObjects]
public class CargoReceivedDataEditor : Editor
{
    private SerializedProperty _cargoList;
    private bool[] _cargoArray;


    private void OnEnable()
    {
        _cargoList = serializedObject.FindProperty(nameof(CargoReceivedData._cargoList));
        _cargoArray = new bool[_cargoList.arraySize];      
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        for (int i = 0; i < _cargoList.arraySize; i++)
        {
            SerializedProperty ooc = _cargoList.GetArrayElementAtIndex(i);
            _cargoArray[i] = ooc.FindPropertyRelative(nameof(ReceivedCargoList.IsCargoActive)).boolValue;
        }

        for (int i = 0; i < _cargoList.arraySize; i++)
        {
            SerializedProperty ooc = _cargoList.GetArrayElementAtIndex(i);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(ooc.FindPropertyRelative(nameof(ReceivedCargoList.CargoName)).stringValue);
            _cargoArray[i] = EditorGUILayout.Toggle(_cargoArray[i]);

            EditorGUILayout.EndHorizontal();
        }

        for (int i = 0; i < _cargoList.arraySize; i++)
        {
            SerializedProperty ooc = _cargoList.GetArrayElementAtIndex(i);
            ooc.FindPropertyRelative(nameof(ReceivedCargoList.IsCargoActive)).boolValue = _cargoArray[i];
        }

        serializedObject.ApplyModifiedProperties();
    }
}
