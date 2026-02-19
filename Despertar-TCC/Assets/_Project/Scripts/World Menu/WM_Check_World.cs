using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WM_Check_World : MonoBehaviour
{
    private WM_Player_Movement playerPosition;

    void Awake()
    {
        playerPosition = GetComponent<WM_Player_Movement>();
    }
    public void LoadWorld(int ActualWorld)
    {
        switch (ActualWorld + 1)
        {
            case 1:
                SceneManager.LoadScene(SceneStrings.scnPredio1);
                break;
            case 2:
                SceneManager.LoadScene(SceneStrings.scnPredio2);
                break;
            case 3:
                SceneManager.LoadScene(SceneStrings.scnPredio3);
                break;
            case 4:
                SceneManager.LoadScene(SceneStrings.scnCantina);
                break;
        }
    }

    public void OnEnter(InputAction.CallbackContext input)
    {
        if(input.performed)
        {
            LoadWorld(playerPosition.ActualWorld);
        }
    }
}

/* Script pensado para entrar nas fases
* 
*/