using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoUnloadingData : MonoBehaviour
{
    [System.Serializable]
    public class UnloadingCargoList
    {
        public string CargoName;
        public bool IsCargoActive;

        public int CargoCount;
        public int SetCargoCount
        {
            get { return CargoCount; }
            set
            {
                if (value == 0)
                    IsCargoActive = false;

                CargoCount = value;
            }
        }

        public UnloadingCargoList(string cargoName, bool isCargoActive, int cargoCount)
        {
            CargoName = cargoName;
            IsCargoActive = isCargoActive;
            CargoCount = cargoCount;
        }
    }

    [SerializeField] private CargoTypeBase _cargoType;
    private TaskListData _taskListData;
    public List<UnloadingCargoList> CargoList;


    private void Start()
    {
        _taskListData = GameObject.FindGameObjectWithTag("TaskList").GetComponent<TaskListData>();
    }


    public void ResetCargoList(List<UnloadingCargoList> newCargoList)
    {
        if (CargoList != null)
        {
            foreach (UnloadingCargoList cargo in CargoList)
            {
                foreach (UnloadingCargoList newCargo in newCargoList)
                {
                    if (cargo.CargoName == newCargo.CargoName)
                    {
                        newCargo.IsCargoActive = cargo.IsCargoActive;
                        newCargo.CargoCount = cargo.CargoCount;
                    }
                }
            }
        }
        CargoList = newCargoList;
    }
}
