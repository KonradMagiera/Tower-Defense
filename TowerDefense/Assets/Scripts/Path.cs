using UnityEngine;

public class Path : MonoBehaviour
{
    public static Transform[] enemyPath;

    void Awake()
    {
        enemyPath = new Transform[transform.childCount];
        for(int i = 0; i < enemyPath.Length; i++)
        {
            enemyPath[i] = transform.GetChild(i);
        }
    }
}
