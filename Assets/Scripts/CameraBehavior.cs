using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 camOffset = new Vector3(0f, 2f, -10f);
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;        
    }

    void LateUpdate()
    {
       this.transform.position = target.TransformPoint(camOffset);
       this.transform.LookAt(target);
    }
}
