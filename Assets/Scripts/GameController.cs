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


    [Header("Oxigen")]
    [SerializeField] AudioClip[] audios;
    [SerializeField] AudioSource audioSour;

    /// RandoValue
    int randomValue = 0;
    [SerializeField] int valueX =0;
    private void Awake()
    {
        valueEnergy.SetValueStar(100);
        valueOxygen.SetValueStar(100);
    }
    public void InicialitateGame() {
        InvokeRepeating("OxygenUpdate", 0, timeLowerOxygen);
    }
    //public void EnergyUpdate(int value)
    //{
    //    valueEnergy.SetValue(value);
    //}
    public void OxygenUpdate()
    {
        if (valueOxygen.valueResources >=0)
        {
            valueOxygen.SetValue(-1);
            textOxygen.Raise(valueOxygen.valueResources);
        }
        else {
            Debug.Log("Perdiste");
        }
        if ((valueOxygen.valueResources >= 30 && valueOxygen.valueResources < 45) && valueX !=1)
        {
            GestionSusto();
            Debug.Log("1");
            valueX = 1;
        }
        else if ((valueOxygen.valueResources >= 15 && valueOxygen.valueResources < 30) && valueX != 2)
        {
            GestionSusto();
            Debug.Log("2");
            valueX = 2;
        }
        else if ((valueOxygen.valueResources > 0 && valueOxygen.valueResources < 15) && valueX != 3)
        {
            GestionSusto();
            Debug.Log("3");
            valueX = 3;
        }
    }

    public void GestionSusto()
    {
        randomValue = Random.Range(0, audios.Length);
        audioSour.clip = audios[randomValue];
        audioSour.Play();
    }

}
