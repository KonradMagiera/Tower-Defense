using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;
    
    public GameObject turret;
    public Image highlither;

    private GameObject selectedTurret;
    private RectTransform buttonPosition;

    // Initlialize before BuildingSpot Start executes
    void Awake()
    {
        buildManager = this;
    }

    void Start()
    {
        selectedTurret = turret;
    }

    public GameObject GetSelectedTurret()
    {
        return selectedTurret;
    }

    public void SetSelectedTurret(GameObject newTurret)
    {
        RectTransform transform = highlither.GetComponent<RectTransform>();

        transform.position = buttonPosition.position;
        selectedTurret = newTurret;
    }

    public void SetButtonPosition(RectTransform transform)
    {
        buttonPosition = transform;
    }

}
