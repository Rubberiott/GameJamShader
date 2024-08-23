using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] ResourcesValue valueEnergy;
    [SerializeField] ResourcesValue valueOxygen;
    [SerializeField] int timeLowerOxygen;


    //SO Text
    [SerializeField] GameIntEvent textEnergy;
    [SerializeField] GameIntEvent textOxygen;

    private void Awake()
    {
        
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
        valueEnergy.SetValue(value);
    }
    public void OxygenUpdate()
    {
        valueOxygen.SetValue(-1);
        textOxygen.Raise(valueOxygen.valueResources);
    }
}
