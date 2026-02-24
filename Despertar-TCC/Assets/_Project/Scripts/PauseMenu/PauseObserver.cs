using System;
using UnityEngine;

public class PauseObserver : MonoBehaviour
{
    private PauseManager pauseManager;
    void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    void OnEnable()
    {
        //se cadastra no evento para observar
        PauseManager.OnPausePress += ShowMenuPause;        
    }

    void OnDisable()
    {
        //sai do cadastro de evento e para de observar  
        PauseManager.OnPausePress -= ShowMenuPause;     
    }

    private void ShowMenuPause()
    {
        //é no receptor que acontece a mágica
        if(!pauseManager.IsPaused)
        {
            pauseManager.SetActivePauseMenuCanvas(true);
            pauseManager.IsPaused = true;
        }
        else
        {
            pauseManager.SetActivePauseMenuCanvas(false);
            pauseManager.IsPaused = false;
        }
        Time.timeScale = pauseManager.IsPaused ? 0f:1f; //bem coisa de IA mas é interessante vai kk
        Debug.Log($"Time Scale neste momento: {Time.timeScale}");
    }
}
