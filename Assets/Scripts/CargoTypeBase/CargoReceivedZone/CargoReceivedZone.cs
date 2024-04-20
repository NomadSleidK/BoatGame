using Unity.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoReceivedZone : MonoBehaviour
{
    [System.Serializable]
    public class ReceivedCargoList
    {
        public string CargoName;
        public bool IsCargoActive;

        public ReceivedCargoList(string cargoName, bool isCargoActive)
        {
            CargoName = cargoName;
            IsCargoActive = isCargoActive;
        }
    }

    [SerializeField] private CargoTypeBase _cargoType;
    public List<ReceivedCargoList> _cargoList;

    public void ResetCargoList(List<ReceivedCargoList> newCargoList)
    {
        if (_cargoList != null)
        {
            foreach (ReceivedCargoList cargo in _cargoList)
            {
                foreach (ReceivedCargoList newCargo in newCargoList)
                {
                    if (cargo.CargoName == newCargo.CargoName)
                    {
                        newCargo.IsCargoActive = cargo.IsCargoActive;
                    }
                }
            }
        }
        _cargoList = newCargoList;
    }

    public List<string> GetActiveCargo()
    {
        List<string> cargoList = new List<string>();

        foreach (ReceivedCargoList cargo in _cargoList)
        {
            if (cargo.IsCargoActive == true)
            {
                cargoList.Add(cargo.CargoName);
            }
        }
        return cargoList;
    }
}