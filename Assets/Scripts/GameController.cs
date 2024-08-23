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
        valueEnergy.SetValueStar(100);
        valueOxygen.SetValueStar(100);
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
        InvokeRepeating("OxygenUpdate", 0, timeLowerOxygen);
    }
    public void EnergyUpdate(int value)
    {
        valueEnergy.SetValue(value);
    }
    public void OxygenUpdate()
    {
        if (valueOxygen.valueResources >0)
        {
            valueOxygen.SetValue(-1);
            textOxygen.Raise(valueOxygen.valueResources);
        }
        else {
            Debug.Log("Perdiste");
        }
    }
}
