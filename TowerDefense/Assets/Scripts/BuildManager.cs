using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;
    public GameObject turret;

    private GameObject selectedTurret;

    // Initlialize before BuildingSpot Start executes
    void Awake()
    {
        buildManager = this;
    }

    void Start()
    {
        selectedTurret = turret;
    }

    public GameObject GetSelectedTurret(){
        return selectedTurret;
    }
}
