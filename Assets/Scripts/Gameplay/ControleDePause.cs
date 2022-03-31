using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDePause : MonoBehaviour
{
    const float VALOR_ESCALA_PADRAO = 1f;
    const float FIXED_TIME_PADRAO = 0.02f;
    
    [SerializeField] private GameObject _painelDePause;
    [SerializeField][Range(0,1)] private float _escalaTempoDurantePause = 0.1f;

    private Coroutine _continuarJogo;

    private void Update()
    {
        if (EstouTocandoNaTela())
        {
            ContinuarJogo();
        }
        else
        {
            PausarJogo();
        }
    }

    public void PausarJogo()
    {
        _painelDePause.SetActive(true);
        MudarEscalaDeTempo(_escalaTempoDurantePause);
    }

    public void ContinuarJogo()
    {
        if(_continuarJogo == null)
            _continuarJogo = StartCoroutine(EsperarEContinuarJogo());
    }

    private IEnumerator EsperarEContinuarJogo()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        _painelDePause.SetActive(false);
        MudarEscalaDeTempo(VALOR_ESCALA_PADRAO);
        _continuarJogo = null;
    }

    public void MudarEscalaDeTempo(float escala)
    {
        Time.timeScale = escala;
        Time.fixedDeltaTime = FIXED_TIME_PADRAO * Time.timeScale;
    }

    public bool EstouTocandoNaTela()
    {
        return Input.touchCount > 0;
    }
}
