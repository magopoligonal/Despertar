using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress", menuName = "Scriptable Objects/PlayerProgress")]
public class PlayerProgress : ScriptableObject
{
    [Header("Progresso do Jogador")]
    [SerializeField] private int lastCompletedLevel = 0;
    [SerializeField] private int lastWorldPosition = 0;

    [Header("Configurações")]
    [SerializeField] private bool debugMode = true;

    public int LastWorldPosition
    {
        get
        {
            return lastWorldPosition;
        }

        set
        {
            lastWorldPosition = Mathf.Clamp(value, 0, int.MaxValue); //nova sintaxe com value implicito
            if (debugMode)
                Debug.Log($"Progresso atualizado: Posição {lastWorldPosition}");
        }
    }

    public int LastCompletedLevel
    {
        get
        {
            return lastCompletedLevel;
        }
        set
        {
            lastCompletedLevel = Mathf.Max(value, 0);
        }
    }

        // Método para resetar o progresso (útil para testes)
    public void ResetProgress()
    {
        lastCompletedLevel = 0;
        lastWorldPosition = 0;
        if (debugMode) Debug.Log("Progresso resetado!");
    }
    
    // Método para desbloquear próximo nível
    public void UnlockNextLevel(int currentLevel)
    {
        if (currentLevel >= lastCompletedLevel)
        {
            lastCompletedLevel = currentLevel + 1;
        }
    }
    
    // Verifica se um nível está desbloqueado
    public bool IsLevelUnlocked(int levelIndex)
    {
        return levelIndex <= lastCompletedLevel;
    }


}
