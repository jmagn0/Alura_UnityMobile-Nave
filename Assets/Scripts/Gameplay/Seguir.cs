using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField] private Transform _alvo;
    [SerializeField] private float _velocidade = 5;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 deslocamento = _alvo.position - transform.position;
        deslocamento = deslocamento.normalized;
        deslocamento *= _velocidade;

        _rb.AddForce(deslocamento, ForceMode2D.Force);        
    }

    public void SetAlvo(Transform objeto)
    {
        _alvo = objeto;
    }
}
