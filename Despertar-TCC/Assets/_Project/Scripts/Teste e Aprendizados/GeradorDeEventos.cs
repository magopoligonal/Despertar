using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GeradorDeEventos : MonoBehaviour
{
    public static Action OnEspacoPressionado;



    public void OnJump(InputAction.CallbackContext input)
    {
        if(input.performed)
        {
            OnEspacoPressionado?.Invoke();   
        }
    }
}
