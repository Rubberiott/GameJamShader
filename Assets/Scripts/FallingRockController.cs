using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockController : MonoBehaviour
{
    [SerializeField] private float _timeOfStartFalling;
    [SerializeField] private float _timeForDestroy = 4f;
    private Rigidbody _myRigidbody;
    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Activado la colision");
        ActivateFallingRock(_timeOfStartFalling);
    }
    public void ActivateFallingRock(float Timer)
    {
        StartCoroutine(TimeForFalling(Timer));
    }
    IEnumerator TimeForFalling(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        _myRigidbody.isKinematic = false;
        Destroy(this.gameObject, _timeForDestroy);
    }
}
