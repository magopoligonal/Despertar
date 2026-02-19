using UnityEngine;
using UnityEngine.SceneManagement;

public static class PerformBootStrap
{
    const string SceneName = "BootStrapped Scene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        //percorre as cenas
        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; ++sceneIndex)
        {
            var candidate = SceneManager.GetSceneAt(sceneIndex);

            if (candidate.name == SceneName)
            {
                //retorna caso já esteja carregado evitando sobreposição
                return;
            }
        }
        //faz com que o a cena seja sobrecarregada em cima da que já está rolando
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive); 

    }
}



public class BootStrapManagers : MonoBehaviour
{
    public static BootStrapManagers Instance { get; private set; } = null;

    void Awake()
    {
        // checa se já existe 
        if (Instance != null)
        {
            Debug.LogError("Foi encontrado outra classe BootStrapManager no objeto: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;

        //vai manter os objetos ativos durante a troca de scenes
        DontDestroyOnLoad(gameObject);
    }

    
}
