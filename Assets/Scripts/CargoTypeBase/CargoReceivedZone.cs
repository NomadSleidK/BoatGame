using System.Collections.Generic;
using UnityEngine;

public class CargoReceivedZone : MonoBehaviour
{
    [System.Serializable]
    public class ReceivedCargoList
    {
        [SerializeField] private string _cargoName;
        public string CargoName => _cargoName;

        public bool IsCargoActive;

        public ReceivedCargoList(string cargoName, bool isCargoActive)
        {
            _cargoName = cargoName;
            IsCargoActive = isCargoActive;
        }
    }

    [SerializeField] private CargoTypeBase _cargoType;
    [SerializeField] private List<ReceivedCargoList> _cargoList = new List<ReceivedCargoList>();

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
}