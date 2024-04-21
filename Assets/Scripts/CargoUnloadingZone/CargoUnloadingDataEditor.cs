using UnityEditor;
using static CargoUnloadingData;

[CustomEditor(typeof(CargoUnloadingData))]
[CanEditMultipleObjects]
public class CargoUnloadingDataEditor : Editor
{
    private SerializedProperty _cargoList;
    private bool[] _isActiveCargo;
    private int[] _cargoCount;

    private void OnEnable()
    {
        _cargoList = serializedObject.FindProperty(nameof(CargoUnloadingData.CargoList));
        _isActiveCargo = new bool[_cargoList.arraySize];
        _cargoCount = new int[_cargoList.arraySize];
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        for (int i = 0; i < _cargoList.arraySize; i++)
        {
            SerializedProperty cargoProperty = _cargoList.GetArrayElementAtIndex(i);
            _isActiveCargo[i] = cargoProperty.FindPropertyRelative(nameof(UnloadingCargoList.IsCargoActive)).boolValue;
            _cargoCount[i] = cargoProperty.FindPropertyRelative(nameof(UnloadingCargoList.CargoCount)).intValue;
        }

        for (int i = 0; i < _cargoList.arraySize; i++)
        {
            SerializedProperty cargoProperty = _cargoList.GetArrayElementAtIndex(i);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(cargoProperty.FindPropertyRelative(nameof(UnloadingCargoList.CargoName)).stringValue);
            _isActiveCargo[i] = EditorGUILayout.Toggle(_isActiveCargo[i]);

            if (_isActiveCargo[i] == true)
                _cargoCount[i] = EditorGUILayout.IntField(_cargoCount[i]);

            EditorGUILayout.EndHorizontal();
        }

        for (int i = 0; i < _cargoList.arraySize; i++)
        {
            SerializedProperty cargoProperty = _cargoList.GetArrayElementAtIndex(i);
            cargoProperty.FindPropertyRelative(nameof(UnloadingCargoList.IsCargoActive)).boolValue = _isActiveCargo[i];
            cargoProperty.FindPropertyRelative(nameof(UnloadingCargoList.CargoCount)).intValue = _cargoCount[i];
        }

        serializedObject.ApplyModifiedProperties();
    }
}
