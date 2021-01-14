using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;
    
    public GameObject turret;
    public Image highlither;
    [Header("UI Objects")]
    public TextMeshProUGUI turretName;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI corruption;
    public TextMeshProUGUI range;
    public TextMeshProUGUI turnRate;
    public TextMeshProUGUI attackSpeed;
    public TextMeshProUGUI bulletSpeed;
    
    private GameObject selectedTurret;
    private RectTransform buttonPosition;
    private GameObject turretToChange;

    // Initlialize before BuildingSpot Start executes
    void Awake()
    {
        buildManager = this;
    }

    void Start()
    {
        selectedTurret = turret;
        SetGuiInfo();
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
        SetGuiInfo();

        if(turretToChange != null)
        {
            Turret tmp = turretToChange.GetComponent<Turret>();
            tmp.HideUI();
        }
    }

    public void SetTurretToChange(GameObject turret)
    {
        if(turretToChange != null)
        {
            Turret tmp = turretToChange.GetComponent<Turret>();
            tmp.HideUI();
        }

        turretToChange = turret;
        Turret t = turretToChange.GetComponent<Turret>();
        t.ShowUI();
        
    }

    public void SetButtonPosition(RectTransform transform)
    {
        buttonPosition = transform;
    }

    private void SetGuiInfo()
    {
        Turret stats = selectedTurret.GetComponent<Turret>();
        turretName.text =  selectedTurret.name;
        damage.text = stats.damage.ToString();
        corruption.text =  stats.corruption.ToString();
        range.text =  stats.range.ToString();
        turnRate.text =  stats.turnRate.ToString();
        attackSpeed.text = stats.attackSpeed.ToString();
        bulletSpeed.text =  stats.bulletSpeed.ToString();
    }
}
