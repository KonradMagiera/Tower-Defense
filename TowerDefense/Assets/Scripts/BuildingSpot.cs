using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rendererObj.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rendererObj.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (placedTurret != null)
        {
            return;
        }

        GameObject turret = BuildManager.buildManager.GetSelectedTurret();
        Turret stats = turret.GetComponent<Turret>();

        if (stats.price > Player.playerMoney)
        {
            Debug.Log("Not enough money");
            return;
        }
        
        Player.playerMoney -= stats.price;
        placedTurret = (GameObject)Instantiate(turret, transform.position + transformY, transform.rotation);
    }
}
