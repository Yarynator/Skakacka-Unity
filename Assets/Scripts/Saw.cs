using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    
    Transform saw;

    void Start()
    {
        saw = transform;
    }

    void Update()
    {
        Quaternion otoceni = saw.rotation;
        otoceni.eulerAngles += new Vector3(0, 0, -500) * Time.deltaTime;
        saw.rotation = otoceni;
    }
}
