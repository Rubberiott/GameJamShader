using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text textEnerGy;
    [SerializeField] TMP_Text textOxygen;

    //SO 
    private void Awake()
    {
        
    }
    public void UpdateTextEnergy( int value)
    {
        textEnerGy.text = value.ToString();
    }
    public void UpdateTextOxygen(int value)
    {
        textOxygen.text = value.ToString();
    }
}
