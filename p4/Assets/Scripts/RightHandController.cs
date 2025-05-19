using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{
    
    //estado
    public InputActionReference JoyStick_North_Reference;
    [Space(20)]

    //right controller - grab
    public ActionBasedController actionBasedController_grab;
    public XRRayInteractor xrRayInteractor_grab;
    public LineRenderer LineRenderer_grab;
    public XRInteractorLineVisual xrInteractorLineVisual_grab;

    //right controller - teleport
    public ActionBasedController actionBasedController_teleport;
    public XRRayInteractor xrRayInteractor_teleport;
    public LineRenderer LineRenderer_teleport;
    public XRInteractorLineVisual xrInteractorLineVisual_teleport;


    //metodos propios
    private void JoyStickArribaPresionado(InputAction.CallbackContext context)
    {
        xrRayInteractor_grab.enabled = false;
        //
        xrRayInteractor_teleport.enabled = true;

        xrInteractorLineVisual_teleport.enabled = true;
    }

    private void JoyStickArribaLiberado(InputAction.CallbackContext context)
    {
        xrRayInteractor_grab.enabled = true;

        xrRayInteractor_teleport.enabled = false;

        xrInteractorLineVisual_teleport.enabled = false;
    }

    private void OnEnable()
    {
        JoyStick_North_Reference.action.performed += JoyStickArribaPresionado;
        JoyStick_North_Reference.action.canceled += JoyStickArribaLiberado;
    }

    

    private void OnDisable()
    {
        JoyStick_North_Reference.action.performed -= JoyStickArribaPresionado;
        JoyStick_North_Reference.action.canceled -= JoyStickArribaLiberado;
    }


}
