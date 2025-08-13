using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Camera : MonoBehaviour
{
    [SerializeField]Transform player;
    Vector3 offset = new Vector3(0, 2, -100);

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x , player.position.y + offset.y, offset.z);
    }
}
