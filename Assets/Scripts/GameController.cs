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
        if (valueOxygen.valueResources >=0)
        {
            valueOxygen.SetValue(-1);
            textOxygen.Raise(valueOxygen.valueResources);
        }
        else {
            Debug.Log("Perdiste");
        }
        if (valueOxygen.valueResources >= 30 && valueOxygen.valueResources < 45)
        {
            GectionSusto();
        }
        else if (valueOxygen.valueResources >= 15 && valueOxygen.valueResources < 30)
        {
            GectionSusto();
        }
        else if (valueOxygen.valueResources > 0 && valueOxygen.valueResources < 15)
        {
            GectionSusto();
        }
    }

    public void GectionSusto()
    {
        randomValue = Random.Range(0, audios.Length);
        audioSour.clip = audios[randomValue];
        audioSour.Play();

    }

}
