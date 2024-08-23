using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Material material;

    void Start()
    {
        material.SetFloat("_DissolveAmount", 0.0f);
    }

    void Update()
    {
        float dissolve = Mathf.PingPong(Time.time, 1);
        material.SetFloat("_DissolveAmount", dissolve);
    }
}
