using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    public bool blockPosition = false;
    private Quaternion initRot;
    private Vector3 initPos;

    void Awake()
    {
        initRot = transform.rotation;
        initPos = transform.position;
    }

    void LateUpdate()
    {
        transform.rotation = initRot;
        if(blockPosition) transform.position = initPos;
    }
}
