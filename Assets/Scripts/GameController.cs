using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] int valueEnergy = 100;
    [SerializeField] int valueOxygen = 100;
    [SerializeField] int timeLowerOxygen;
    private void Awake()
    {
        Invoke("InicialitateGame",0);
    }
    private void Start()
    {

    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {

    }
    public void InicialitateGame() {
        InvokeRepeating("CurremtTime",0, timeLowerOxygen);
    }
    public void EnergyUpdate(int value)
    {
        valueEnergy -= value;
    }
    public void OxygenUpdate(int value)
    {

    }
    public void CurremtTime()
    {
        valueOxygen--;
        if(valueOxygen == 50) {
            print("Te queda la mitad de oxigeno");
        }
        if (valueOxygen == 15)
        {
            print("Falta Oxigeno");
        }
    }
}
