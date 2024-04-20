using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CargoButton : MonoBehaviour
{
    [SerializeField] private Text _buttonText;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetCargoButtonDesign(string text, Sprite sprite)
    {
        CargoButtonSetText(text);
        CargoButtonSetSprite(sprite);
    }

    private void CargoButtonSetText(string text)
    {
        _buttonText.text = text;
    }

    private void CargoButtonSetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }
}
