using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Boat : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;

    [System.Serializable]
    public class CargoPoint
    {
        [SerializeField] private Transform _cargoPoint;
        public Transform GetCargoPoint => _cargoPoint;

        public bool IsFullPoint;

        public GameObject Cargo;
    }

    [SerializeField] private List<CargoPoint> _cargoPoints;
    public List<CargoPoint> GetCargoPoints => _cargoPoints;

    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
