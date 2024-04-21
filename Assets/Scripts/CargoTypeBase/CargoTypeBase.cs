using System;
using System.Collections.Generic;
using UnityEngine;
using static CargoReceivedData;
using static CargoUnloadingData;

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
    private CargoReceivedData[] ReceivedZones;
    private CargoUnloadingData[] UnloadingZones;


    public List<ReceivedCargoList> GetReceivedCargoList()
    {
        List <ReceivedCargoList> cargoList = new List<ReceivedCargoList>();

        foreach (CargoType cargo in _cargoTypes)
        {
            cargoList.Add(new(cargo.CargoName, false));
        }

        return cargoList;
    }

    public List<UnloadingCargoList> GetUnloadingCargoList()
    {
        List<UnloadingCargoList> cargoList = new List<UnloadingCargoList>();

        foreach (CargoType cargo in _cargoTypes)
        {
            cargoList.Add(new(cargo.CargoName, false, 0));
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

    public GameObject GetCargoPrefab(string name)
    {
        GameObject cargoPrefab = null;

        foreach (CargoType cargo in _cargoTypes)
        {
            if (cargo.CargoName == name)
            {
                cargoPrefab = cargo.CargoPrefab;
                break;
            }
        }

        return cargoPrefab;
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
        ReceivedZones = FindObjectsOfType<CargoReceivedData>();
        UnloadingZones = FindObjectsOfType<CargoUnloadingData>();

        if (CheckNameCorrected() == true)
            return;

        foreach (CargoReceivedData receivedZone in ReceivedZones)
        {
            receivedZone.ResetCargoList(GetReceivedCargoList());
        }

        foreach (CargoUnloadingData unloadingZone in UnloadingZones)
        {
            unloadingZone.ResetCargoList(GetUnloadingCargoList());
        }
    }
}
