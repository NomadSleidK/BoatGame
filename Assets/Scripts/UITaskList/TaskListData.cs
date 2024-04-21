using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListData : MonoBehaviour
{
    private CargoUnloadingData[] _cargoUnloadingData;

    private void Start()
    {
        _cargoUnloadingData = FindObjectsOfType<CargoUnloadingData>();
    }

    public void SetTaskList()
    {

    }
}
