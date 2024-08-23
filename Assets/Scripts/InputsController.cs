using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class InputsController : MonoBehaviour
{
    [Header("InputLeft")]
    [SerializeField] InputActionProperty selectActionLeft;
    [SerializeField] GameIntEvent leftPress;
    [Header("InputLeft")]
    [SerializeField] InputActionProperty selectActionRight;
    [SerializeField] GameIntEvent rightPress;

    [Header("Linterna")]
    [SerializeField] GameObject linterna;

    [Header("Oxigen")]
    [SerializeField] ResourcesValue Oxygen;
    [SerializeField] int quantityRecargaOxigen;
    [SerializeField] GameIntEvent textOxygen;
    [SerializeField] ColliderOxygen scriptOxygen;

    [Header("Energy")]
    [SerializeField] ResourcesValue energy;
    [SerializeField] int quantityRecargaEnergy;
    [SerializeField] GameIntEvent textEnergy;
    //[SerializeField] ColliderOxygen scriptOxygen;
    [SerializeField] GameObject panelLoose;


    [Header("InputMovement")]
    [SerializeField] InputActionProperty selectActionMovement;
    [SerializeField] AudioSource movementAudioSource;

    void OnEnable()
    {
        selectActionLeft.action.performed += OnActionPerformedLeft;
        selectActionLeft.action.canceled += OnActionCanceledLeft;

        selectActionRight.action.performed += OnActionPerformedRight;
        selectActionRight.action.canceled += OnActionCanceledRight;

        selectActionMovement.action.performed += OnActionPerformedMovement;
        selectActionMovement.action.canceled += OnActionCanceledMovement;
    }

    void OnDisable()
    {
        selectActionLeft.action.performed -= OnActionPerformedLeft;
        selectActionLeft.action.canceled -= OnActionCanceledLeft;

        selectActionRight.action.performed -= OnActionPerformedRight;
        selectActionRight.action.canceled -= OnActionCanceledRight;

        selectActionMovement.action.performed -= OnActionPerformedMovement;
        selectActionMovement.action.canceled -= OnActionCanceledMovement;
    }

    private void OnActionPerformedLeft(InputAction.CallbackContext context)
    {
        //leftPress.Raise(2);
        if (Oxygen.valueResources<100 && scriptOxygen.colision && energy.valueResources >0)
        {
            InvokeRepeating("OxygenUpdate", 3, 3);
        }
    }

    private void OnActionCanceledLeft(InputAction.CallbackContext context)
    {
        //leftPress.Raise(2);
        CancelInvoke("OxygenUpdate");

    }

    private void OnActionPerformedMovement(InputAction.CallbackContext context)
    {
        if(!movementAudioSource.isPlaying)
            movementAudioSource.Play();
    }
    private void OnActionCanceledMovement(InputAction.CallbackContext context)
    {
        movementAudioSource.Stop();
    }
    private void OnActionPerformedRight(InputAction.CallbackContext context)
    {
        if(energy.valueResources > 0)
        {
            rightPress.Raise(2);
            linterna.SetActive(true);

            InvokeRepeating("EnergyUpdate", 2, 3);
        }
    }

    private void OnActionCanceledRight(InputAction.CallbackContext context)
    {
        rightPress.Raise(2);
        linterna.SetActive(false);

        energy.SetValue(-2);
        textEnergy.Raise(energy.valueResources);

        CancelInvoke("EnergyUpdate");
    }
    public void OxygenUpdate()
    {
        Oxygen.SetValue(quantityRecargaOxigen);
        textOxygen.Raise(Oxygen.valueResources);

        energy.SetValue(-quantityRecargaEnergy);
        textEnergy.Raise(energy.valueResources);
        if (Oxygen.valueResources <=0 && energy.valueResources <= 0)
        {
            panelLoose.SetActive(true);
        }
    }

    public void EnergyUpdate()
    {
        energy.SetValue(-1);
        textEnergy.Raise(energy.valueResources);
    }

}
