using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject ui_Input;
    [SerializeField] private bool isPaused;


    void LateUpdate()
    {
        if(SceneManager.GetActiveScene().name.Equals(SceneStrings.scnMenuPrincipal))
        {
            ui_Input.SetActive(false);
            Debug.Log("Menu Pause desativado com sucesso!");
        }
        else
        {
            ui_Input.SetActive(true);
            Debug.Log("Menu pause reativado com sucesso");
        }
    }

    public void OnPause(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
            if (!isPaused)
            {
                pauseMenuCanvas.SetActive(true);
                isPaused = true;
            }
            else
            {
                isPaused = false;
                pauseMenuCanvas.SetActive(false);
            }
        }
    }
}
