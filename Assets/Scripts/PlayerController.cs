using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }
}
