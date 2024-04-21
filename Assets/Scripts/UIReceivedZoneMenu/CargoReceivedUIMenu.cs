using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public delegate void LoaderCargo(string name);

public class CargoReceivedUIMenu : MonoBehaviour
{
    [SerializeField] private CargoTypeBase _cargoTypeBase;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonsGroup;
    
    private CargoLoader _cargoLoader;
    private List<string> _cargoNames;
    private GameObject[] _buttons;
    private Canvas _canvas;

    LoaderCargo AddCargoLoader;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _cargoLoader = GameObject.FindGameObjectWithTag("Player").GetComponent<CargoLoader>();
        AddCargoLoader = _cargoLoader.AddCargoOnBoat;
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
            _buttons[i] = Instantiate(_buttonPrefab, _buttonsGroup);
            _buttons[i].GetComponent<CargoButton>().SetCargoButtonSettings(_cargoNames[i], _cargoTypeBase.GetCargoSprite(_cargoNames[i]), AddCargoLoader);     
        }
    }
}
