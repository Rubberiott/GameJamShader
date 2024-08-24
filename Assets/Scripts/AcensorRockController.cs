using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcensorRockController : MonoBehaviour
{
    public GameObject FinalDestination;
    public float timeReverse;
    public float velocidad = 5f;
    Vector3 inicialPos;
    public Vector3 currentPos;
    Rigidbody myRB;
    bool condition = false;
    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
        inicialPos = this.gameObject.transform.position;
        currentPos = inicialPos;
    }
    private void Update()
    {
    }
    private void FixedUpdate()
    {
        if (condition)
        {
            Vector3 posicionDeseada = Vector3.MoveTowards(myRB.position, FinalDestination.transform.position, velocidad * Time.fixedDeltaTime);
            myRB.MovePosition(posicionDeseada);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Invoke("MoveToPosFinal", timeReverse);
    }

    public void MoveToPosFinal()
    {
        condition = true;
    }
    public void MoveToPosInit()
    {
        condition = false;
    }
}
