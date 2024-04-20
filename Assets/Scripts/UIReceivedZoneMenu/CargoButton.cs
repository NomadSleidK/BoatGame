using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CargoButton : MonoBehaviour
{
    [SerializeField] private Text _buttonText;
    private Image _image;
    private LoaderCargo _loaderCargo;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetCargoButtonSettings(string text, Sprite sprite, LoaderCargo loaderCargo)
    {
        CargoButtonSetText(text);
        CargoButtonSetSprite(sprite);
        _loaderCargo = loaderCargo;
    }

    private void CargoButtonSetText(string text)
    {
        _buttonText.text = text;
    }

    private void CargoButtonSetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void Click()
    {
        _loaderCargo(_buttonText.text);
    }
}
