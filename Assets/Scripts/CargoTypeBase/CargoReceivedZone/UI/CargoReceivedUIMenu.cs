using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoReceivedUIMenu : MonoBehaviour
{
    [SerializeField] private CargoTypeBase _cargoTypeBase;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonsGroup;

    [SerializeField] private List<string> _cargoNames;
    private GameObject[] _buttons;
    private Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        SetVisibleState(false);
    }

    public void SetVisibleState(bool state)
    {
        if (state)
            _canvas.enabled = true;
        else
            _canvas.enabled = false;
    }

    public void SetActiveCargoNames(List<string> cargoNames)
    {
        _cargoNames = cargoNames;
        CreateButtonList();
    }

    public void ClearCargoMenu()
    {
        foreach (GameObject button in _buttons)
        {
            Destroy(button);
        }
    }

    private void CreateButtonList()
    {
        _buttons = new GameObject[_cargoNames.Count];

        for (int i = 0; i < _cargoNames.Count; i++)
        {
            _buttons[i] = Instantiate(_buttonPrefab);
            _buttons[i].transform.SetParent(_buttonsGroup);
            _buttons[i].GetComponent<CargoButton>().SetCargoButtonDesign(_cargoNames[i], _cargoTypeBase.GetCargoSprite(_cargoNames[i])) ;
        }
    }
}
