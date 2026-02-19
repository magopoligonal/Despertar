using UnityEngine;

public class PersistenciaManager : MonoBehaviour
{
    public static PersistenciaManager Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //O objeto deve ser separado já que não queremos destrui-lo na cena
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
