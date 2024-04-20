using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private CargoReceivedZone _cargoReceivedZone;
    private CargoReceivedUIMenu _cargoReceivedUIMenu;

    private void Start()
    {
        _cargoReceivedZone = GetComponent<CargoReceivedZone>();
        _cargoReceivedUIMenu = GameObject.FindGameObjectWithTag("CargoMenuUI").GetComponent<CargoReceivedUIMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _cargoReceivedUIMenu.SetVisibleState(true);
            _cargoReceivedUIMenu.SetActiveCargoNames(_cargoReceivedZone.GetActiveCargo());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _cargoReceivedUIMenu.SetVisibleState(false);
            _cargoReceivedUIMenu.ClearCargoMenu();
        }
    }
}
