using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetPosition;

    void FixedUpdate()
    {

        transform.position = new Vector3(player.position.x + offsetPosition.x,
                                    player.position.y + offsetPosition.y,
                                    transform.position.z);
    }
}
