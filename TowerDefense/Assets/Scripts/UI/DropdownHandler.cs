using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownHandler : MonoBehaviour
{
    private Turret turret;
    void Awake()
    {
        GameObject parentTurret = transform.parent.gameObject;
        turret = parentTurret.GetComponent<Turret>();
    }


    public void ChangeSeekType(int value)
    {
        turret.ChangeSeekType(value);
    }
}
