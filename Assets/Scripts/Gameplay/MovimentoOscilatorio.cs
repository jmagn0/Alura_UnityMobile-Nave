using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoOscilatorio : MonoBehaviour
{
    private Vector3 _posicaoInicial;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _velocidade;

    private float angulo;
    private void Awake()
    {
        _posicaoInicial = transform.position;
    }

    private void Update()
    {
        angulo += _velocidade;
        var variacao = Mathf.Sin(angulo);
        transform.position = _posicaoInicial + (_amplitude * variacao * Vector3.up);
    }
}
