using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

    void Start()
    {
        
    }

    void OnEnable()
    {
        // Asegúrate de suscribirte a los eventos en OnEnable
        selectActionLeft.action.performed += OnActionPerformedLeft;
        selectActionLeft.action.canceled += OnActionCanceledLeft;

        selectActionRight.action.performed += OnActionPerformedRight;
        selectActionRight.action.canceled += OnActionCanceledRight;
    }

    void OnDisable()
    {
        // Desuscríbete de los eventos en OnDisable para evitar fugas de memoria
        selectActionLeft.action.performed -= OnActionPerformedLeft;
        selectActionLeft.action.canceled -= OnActionCanceledLeft;

        selectActionRight.action.performed -= OnActionPerformedRight;
        selectActionRight.action.canceled -= OnActionCanceledRight;
    }

    private void OnActionPerformedLeft(InputAction.CallbackContext context)
    {
        //leftPress.Raise(2);
        if (Oxygen.valueResources<100 && scriptOxygen.colision)
        {
            InvokeRepeating("OxygenUpdate", 3, 3);
        }
    }

    private void OnActionCanceledLeft(InputAction.CallbackContext context)
    {
        //leftPress.Raise(2);
        CancelInvoke("OxygenUpdate");
    }
    private void OnActionPerformedRight(InputAction.CallbackContext context)
    {
        rightPress.Raise(2);
        linterna.SetActive(true);
    }

    private void OnActionCanceledRight(InputAction.CallbackContext context)
    {
        rightPress.Raise(2);
        linterna.SetActive(false);
    }
    public void OxygenUpdate()
    {
        Oxygen.SetValue(quantityRecargaOxigen);
        textOxygen.Raise(Oxygen.valueResources);
    }

}
