using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuCanvas;
    private bool isPaused = false;

    public bool IsPaused { get => isPaused; set => isPaused = value; }

    //Events
    public static event Action OnPausePress;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }


    public void OnPause(InputAction.CallbackContext input)
    {
        //verificar qual cena estou e se não estiver no menu(controlar isso por gamestate depois) emite o evento
        if(input.performed && SceneManager.GetActiveScene().name.Equals(SceneStrings.scnMenuPrincipal))
        {
            return;
        }
        else if(input.performed)
        {
            OnPausePress?.Invoke();
        }
    }

    //Get set
    public GameObject GetPauseMenuCanvas()
    {
        return pauseMenuCanvas;
    }
    public void SetActivePauseMenuCanvas(bool isActive)
    {
        if(isActive)
        {
            pauseMenuCanvas.SetActive(true);
            Debug.Log("O menu pause foi ativado.");
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Debug.Log("O menu pause foi desativado.");
        }
    }

    public void TurnOffOnSceneChanged()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
