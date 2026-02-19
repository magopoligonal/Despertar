using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WM_Player_Movement : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private GameObject[] buildingPosition;
    [SerializeField] private PlayerProgress playerProgress;

    [Header("Debug")]
    [SerializeField] private bool resetProgressOnStart = false;

    [Header("Variaveis")]
    [SerializeField] private int cont = 0;
    
    void Start()
    {
        //---TO DO ---
        //acessar a ultima fase jogada para posicionar o player na posicao correta
        //talvez seja interessante criar uma classe só para isso ou um scriptableobject.
        if(playerProgress != null)
        {
            if(resetProgressOnStart) //não esquecer ligado no debug
            {
                playerProgress.ResetProgress();
            }

            //acessa o scriptable object e referencia o valor da ultima fase
            cont = playerProgress.LastWorldPosition;
            Change_UI_Position(cont);
        }
    }





//METODOS
    //Input Sytem
    public void OnNavigate_Arrows(InputAction.CallbackContext input)
    {
        if(!input.performed)
        return;

        int sidePressed = (int)(input.ReadValue<Vector2>().x);
        Debug.Log($"click value: {sidePressed}");

        if(sidePressed > 0.5f)
        {
            MoveToNextPosition();
        }
        else if(sidePressed < -0.5f)
        {
            MoveToPreviousPosition();
        }
    }
    public void OnNavigate_Button(InputAction.CallbackContext input)
    {
        if(input.performed)
        {
            MoveToNextPosition();
        }
    }





    //Locais
        private void Change_UI_Position(int position)
    {
        this.transform.position = buildingPosition[position].transform.position;
        Debug.Log($"Moveu para a posicao: {buildingPosition[position].name}");
    }

    private void MoveToNextPosition()
    {
        cont++;
        if (cont >= buildingPosition.Length)
        {
            cont = 0;
        }
        Change_UI_Position(cont);
        SavePosition();
    }

    private void MoveToPreviousPosition()
    {
        cont--;
        if (cont < 0)
        {
            cont = buildingPosition.Length - 1;
        }
        Change_UI_Position(cont);
        SavePosition();
    }
    private void SavePosition()
    {
        if(playerProgress != null)
        {
            playerProgress.LastWorldPosition = cont;
        }
    }

    //Getter-Setters
    public int ActualWorld
    {
        get{return cont;}
    }

}


//Essa classe tratara da movimentação do personagem durante o menu do mundo
/*
*
*/
