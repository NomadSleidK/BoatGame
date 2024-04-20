using System;
using System.Collections.Generic;
using UnityEngine;
using static CargoReceivedZone;

[CreateAssetMenu(fileName = "CargoTypeBase", menuName = "ScriptableObjects/CargoTypeBase", order = 51)]
public class CargoTypeBase : ScriptableObject
{
    [System.Serializable]
    public class CargoType
    {
        [SerializeField] private string _cargoName;
        public string CargoName => _cargoName;

        [SerializeField] private Sprite _cargoSprite;
        public Sprite CargoSprite => _cargoSprite;

        [SerializeField] private GameObject _cargoPrefab;
        public GameObject CargoPrefab => _cargoPrefab;
    }

    [SerializeField] private List<CargoType> _cargoTypes;

    [SerializeField] private CargoReceivedZone[] _fabrics;

    public List<ReceivedCargoList> GetCargoList()
    {
        List <ReceivedCargoList> cargoList = new List<ReceivedCargoList>();

        foreach (CargoType cargo in _cargoTypes)
        {
            cargoList.Add(new(cargo.CargoName, false));
        }

        return cargoList;
    }

    public Sprite GetCargoSprite(string name)
    {
        Sprite cargoSprite = null;

        foreach (CargoType cargo in _cargoTypes)
        {
            if (cargo.CargoName == name)
            {
                cargoSprite = cargo.CargoSprite;
                break;
            }
        }

        return cargoSprite;
    }

    private bool CheckNameCorrected()
    {
        foreach (CargoType cargoA in _cargoTypes)
        {
            foreach (CargoType cargoB in _cargoTypes)
            {
                if (cargoA.CargoName == cargoB.CargoName && cargoA != cargoB)
                {
                    Debug.LogError("Несколько грузов имеют одинаковые имена!");
                    return true;
                }
            }
        }
        return false;
    }

    private void OnValidate()
    {
        _fabrics = FindObjectsOfType<CargoReceivedZone>();

        if (CheckNameCorrected() == true)
            return;

        foreach (CargoReceivedZone receivedZone in _fabrics)
        {
            receivedZone.ResetCargoList(GetCargoList());
        }
    }
}
