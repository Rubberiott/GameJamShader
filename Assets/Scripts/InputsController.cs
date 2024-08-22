using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputsController : MonoBehaviour
{
    [Header ("InputLeft")]
    [SerializeField] InputActionProperty selectActionLeft;
    [SerializeField] GameIntEvent leftPress;
    [Header("InputLeft")]
    [SerializeField] InputActionProperty selectActionRight;
    [SerializeField] GameIntEvent rightPress;

    [Header("Linterna")]
    [SerializeField] GameObject linterna;



    void Start()
    {
        
    }

    void OnEnable()
    {
        // Aseg�rate de suscribirte a los eventos en OnEnable
        selectActionLeft.action.performed += OnActionPerformedLeft;
        selectActionLeft.action.canceled += OnActionCanceledLeft;

        selectActionRight.action.performed += OnActionPerformedRight;
        selectActionRight.action.canceled += OnActionCanceledRight;
    }

    void OnDisable()
    {
        // Desuscr�bete de los eventos en OnDisable para evitar fugas de memoria
        selectActionLeft.action.performed -= OnActionPerformedLeft;
        selectActionLeft.action.canceled -= OnActionCanceledLeft;

        selectActionRight.action.performed -= OnActionPerformedRight;
        selectActionRight.action.canceled -= OnActionCanceledRight;
    }

    private void OnActionPerformedLeft(InputAction.CallbackContext context)
    {
        leftPress.Raise(2);
    }

    private void OnActionCanceledLeft(InputAction.CallbackContext context)
    {
        leftPress.Raise(2);
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


}
