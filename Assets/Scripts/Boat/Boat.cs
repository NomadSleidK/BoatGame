using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Boat : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;

    [System.Serializable]
    public class CargoSpace
    {
        [SerializeField] private Transform _cargoPoint;
        public Transform GetCargoPoint => _cargoPoint;

        public bool IsFullPoint;

        public string CargoName;
        public GameObject Cargo;
    }

    [SerializeField] private List<CargoSpace> _cargoPoints;
    public List<CargoSpace> GetCargoPoints => _cargoPoints;

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
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                _agent.SetDestination(hit.point);
            }
        }
    }
}
