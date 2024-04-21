using UnityEngine;

public class ReceivedZone : MonoBehaviour
{
    private CargoReceivedData _cargoReceivedData;
    private CargoReceivedUIMenu _cargoReceivedUIMenu;

    private void Start()
    {
        _cargoReceivedData = GetComponent<CargoReceivedData>();
        _cargoReceivedUIMenu = GameObject.FindGameObjectWithTag("CargoMenuUI").GetComponent<CargoReceivedUIMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _cargoReceivedUIMenu.SetVisibleState(true);
            _cargoReceivedUIMenu.SetActiveCargoNames(_cargoReceivedData.GetActiveCargo());
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
