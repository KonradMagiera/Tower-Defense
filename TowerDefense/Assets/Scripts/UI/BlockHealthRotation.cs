using UnityEngine;

public class BlockHealthRotation : MonoBehaviour
{
    private Quaternion initRot;

    void Start()
    {
        initRot = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = initRot;
    }
}
