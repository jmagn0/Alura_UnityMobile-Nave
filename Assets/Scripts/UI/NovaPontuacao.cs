using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaPontuacao : MonoBehaviour
{
    [SerializeField] private TextoDinamico _texto;
    [SerializeField] private Ranking _ranking;

    private string id;
    // Start is called before the first frame update
    void Start()
    {
        Pontuacao obj = FindObjectOfType<Pontuacao>();
        int totalDePontos = -1;
        if(obj != null)
        {
            totalDePontos = obj.Pontos;
        }
        _texto.AlterarTexto(totalDePontos);
        id = _ranking.AdicionarPontuacao(totalDePontos, "Nome");
    }

    public void AlterarNome(string nome)
    {
        _ranking.AlterarNome(nome, id);
    }
    
}
