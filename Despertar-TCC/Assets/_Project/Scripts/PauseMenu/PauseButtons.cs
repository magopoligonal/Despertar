using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    private PauseManager pauseManager = null;
    void Start()
    {
        if(pauseManager == null)
        pauseManager = GetComponent<PauseManager>();
    }
    public void BackToWorldSelection()
    {
        SceneManager.LoadScene(SceneStrings.scnWorldSelection);
        pauseManager.TurnOffOnSceneChanged();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneStrings.scnMenuPrincipal);
        pauseManager.TurnOffOnSceneChanged();
    }
    //como fazer o botão resume? lul

    
}
