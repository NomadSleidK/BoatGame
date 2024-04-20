using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Boat;

public class CargoLoader : MonoBehaviour
{
    [SerializeField] private CargoTypeBase _cargoType;

    [SerializeField] private List<CargoPoint> _cargoPoints;

    private Boat _playerBoat;

    private void Start()
    {
        _playerBoat = GameObject.FindGameObjectWithTag("Player").GetComponent<Boat>();
        _cargoPoints = _playerBoat.GetCargoPoints;
    }

    public void AddCargoOnBoat(string cargoName)
    {
        foreach (CargoPoint cargo in _cargoPoints)
        {
            if (cargo.IsFullPoint != true)
            {
                cargo.IsFullPoint = true;

                cargo.Cargo = Instantiate(_cargoType.GetCargoPrefab(cargoName));
                cargo.Cargo.transform.SetParent(cargo.GetCargoPoint);
                cargo.Cargo.transform.rotation = new Quaternion(0, 0, 0, 0);
                cargo.Cargo.transform.transform.localPosition = Vector3.zero;

                break;
            }
        }
    }
}
