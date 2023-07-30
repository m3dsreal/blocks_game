using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform GeneratorFollow;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GeneratorFollow.transform.position + new Vector3(0.96f, 2.78f, -4.14f);
    }
}
