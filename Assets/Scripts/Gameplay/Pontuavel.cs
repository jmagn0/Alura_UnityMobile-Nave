using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuavel : MonoBehaviour
{
    private Pontuacao _pontuacao;

    public void Pontuar()
    {
        _pontuacao.Pontuar();
    }

    public void SetPontuacao(Pontuacao pontuacao)
    {
        _pontuacao = pontuacao;
    }
}
