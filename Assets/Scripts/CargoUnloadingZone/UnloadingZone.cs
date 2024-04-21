using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Boat;
using static CargoUnloadingData;

public class UnloadingZone : MonoBehaviour
{
    private CargoUnloadingData _cargoUnloadingData;
    private CargoLoader _cargoLoader;

    private void Start()
    {
        _cargoUnloadingData = GetComponent<CargoUnloadingData>();
        _cargoLoader = GameObject.FindGameObjectWithTag("Player").GetComponent<CargoLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CheckCargoOnBoat(_cargoLoader.GetCargoSpaces);
        }
    }

    private void CheckCargoOnBoat(List<CargoSpace> cargoSpaces)
    {
        List<UnloadingCargoList> unloadingCargoList = _cargoUnloadingData.CargoList;

        foreach (CargoSpace space in cargoSpaces)
        {
            if (space.IsFullPoint == true)
            {
                foreach (UnloadingCargoList cargo in unloadingCargoList)
                {
                    if ((space.CargoName == cargo.CargoName) && (cargo.IsCargoActive == true) && (cargo.CargoCount > 0))
                    {
                        cargo.SetCargoCount--;
                        _cargoLoader.UnloadCargo(space.CargoName);
                        break;
                    }
                }
            }
        }
    }
}
