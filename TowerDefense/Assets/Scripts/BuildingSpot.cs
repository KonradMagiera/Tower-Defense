using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSpot : MonoBehaviour
{
    public Color hoverColor;

    private Renderer rendererObj;
    private Color startColor;
    private GameObject placedTurret;
    private Vector3 transformY;

    void Start()
    {
        rendererObj = GetComponent<Renderer>();
        startColor = rendererObj.material.color;
        transformY = new Vector3(0, 0.55f, 0);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        rendererObj.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rendererObj.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (placedTurret != null)
        {
            return;
        }

        GameObject turret = BuildManager.buildManager.GetSelectedTurret();
        Turret stats = turret.GetComponent<Turret>();

        // Not enough money, maybe change gold color for a second
        if (stats.price > Player.playerMoney)
        {
            return;
        }

        Player.playerMoney -= stats.price;
        placedTurret = (GameObject)Instantiate(turret, transform.position + transformY, transform.rotation);
    }
}
