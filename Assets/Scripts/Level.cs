using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> enemies;

    public Vector3 GetPosOfNearestEnemy()
    {
        Vector3 pos = enemies[enemies.Count - 1].gameObject.transform.position;

        return pos;
    }
}