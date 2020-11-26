using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI towerName;
    public TextMeshProUGUI towerPrice;
    public GameObject tower;

    void Start()
    {
        towerName.text = tower.name;
        Turret target = tower.GetComponent<Turret>();
        towerPrice.text = $"{target.price}g";
    }
}
