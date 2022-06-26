using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 FollowPos;
    public Transform Target;
    void Start()
    {
        //FollowPos = Camera.main.transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(FollowPos.x,FollowPos.y,Target.position.z + FollowPos.z);
    }
}
