using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemColocado : MonoBehaviour
{
    [SerializeField] private Text _textoColocado;
    [SerializeField] private Text _textoNome;
    [SerializeField] private Text _textoPontuacao;

    public void ConfigurarColocado(int posicao, string nome, int pontuacao)
    {
        _textoColocado.text = posicao.ToString();
        _textoNome.text = nome;
        _textoPontuacao.text = pontuacao.ToString();
    }
}
