using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pontuacao : MonoBehaviour
{
    public int Pontos 
    {
        get
        {
            return _pontos;
        }
    }

    [SerializeField] private MeuEventopersonalizadoInt OnPontuar;
    private int _pontos;

    public void Pontuar()
    {
        _pontos++;
        OnPontuar.Invoke(_pontos);
    }
}

[System.Serializable]
public class MeuEventopersonalizadoInt : UnityEvent<int>
{

}
