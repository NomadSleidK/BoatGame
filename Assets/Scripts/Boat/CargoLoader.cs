using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Boat;

public class CargoLoader : MonoBehaviour
{
    [SerializeField] private CargoTypeBase _cargoType;

    [SerializeField] private List<CargoSpace> _cargoSpace;
    public List<CargoSpace> GetCargoSpaces => _cargoSpace;

    private Boat _playerBoat;

    private void Start()
    {
        _playerBoat = GameObject.FindGameObjectWithTag("Player").GetComponent<Boat>();
        _cargoSpace = _playerBoat.GetCargoPoints;
    }

    public void AddCargoOnBoat(string cargoName)
    {
        foreach (CargoSpace cargo in _cargoSpace)
        {
            if (cargo.IsFullPoint != true)
            {
                cargo.IsFullPoint = true;
                cargo.CargoName = cargoName;

                cargo.Cargo = Instantiate(_cargoType.GetCargoPrefab(cargoName), cargo.GetCargoPoint);
                cargo.Cargo.transform.rotation = new Quaternion(0, 0, 0, 0);
                cargo.Cargo.transform.transform.localPosition = Vector3.zero;

                break;
            }
        }
    }

    public void UnloadCargo(string cargoName)
    {
        foreach (CargoSpace cargo in _cargoSpace)
        {
            if (cargo.CargoName == cargoName)
            {
                cargo.IsFullPoint = false;
                cargo.CargoName = "";
                Destroy(cargo.Cargo);
                break;
            }
        }
    }
}
