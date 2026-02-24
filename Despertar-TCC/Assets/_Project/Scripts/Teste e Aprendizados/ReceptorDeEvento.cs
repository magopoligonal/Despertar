using UnityEngine;

public class ReceptorDeEvento : MonoBehaviour
{
    void OnEnable()
    {
        GeradorDeEventos.OnEspacoPressionado += MudarCor;
    }

    void OnDisable()
    {
        GeradorDeEventos.OnEspacoPressionado -= MudarCor;       
    }

    void MudarCor()
    {
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        Debug.Log($"Eu {this.name} reagi ao evento!");
    }
}
