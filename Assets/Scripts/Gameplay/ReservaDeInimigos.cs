using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaDeInimigos : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _quantidade;

    private Stack<GameObject> _stack = new Stack<GameObject>();

    private void Start()
    {
        ConstruirTodosInimigos();
    }

    private void ConstruirTodosInimigos()
    {
        for (int i = 0; i < _quantidade; i++)
        {
            GameObject obj = Instantiate(_prefab, this.transform);
            var objDaReserva = obj.GetComponent<ObjetoDaReservaDeInimigos>();
            objDaReserva.SetReserva(this);            
            obj.SetActive(false);
            _stack.Push(obj);
        }
    }

    public GameObject PegarInimigo()
    {
        var inimigo = _stack.Pop();
        inimigo.SetActive(true);
        return inimigo;
    }

    public bool TemInimigo()
    {
        return _stack.Count > 0;
    }

    public void DevolverInimigo(GameObject inimigo)
    {
        inimigo.SetActive(false);
        _stack.Push(inimigo);
    }
}
