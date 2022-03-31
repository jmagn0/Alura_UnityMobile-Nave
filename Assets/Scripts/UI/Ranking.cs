using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    const string NOME_DO_ARQUIVO = "Ranking.json";
    [SerializeField]
    private List<Colocado> listaColocado;

    string caminho;

    void Awake()
    {
        caminho = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);

        if (File.Exists(caminho))
        {
            CarregarPontuacao();
        }
        else
        {
            listaColocado = new List<Colocado>();
        }
        
    }

    public int QuantidadeRanking()
    {
        return listaColocado.Count;
    }

    public ReadOnlyCollection<Colocado> ListaPontuacao()
    {
        return listaColocado.AsReadOnly();
    }

    public string AdicionarPontuacao(int pontos, string nome)
    {
        var id = Guid.NewGuid().ToString();
        var colocado = new Colocado(nome, pontos, id);
        listaColocado.Add(colocado);
        listaColocado.Sort();
        SalvarPontuacao();
        return id;
    }

    public void AlterarNome(string nome, string id)
    {
        foreach (var item in listaColocado)
        {
            if(item.id == id)
            {
                item.nome = nome;
                break;
            }
        }
        SalvarPontuacao();
    }

    private void SalvarPontuacao()
    {
        string arquivoTexto = JsonUtility.ToJson(this, true);
        File.WriteAllText(caminho, arquivoTexto);
    }

    private void CarregarPontuacao()
    {
        string listaSalvaJson = File.ReadAllText(caminho);
        JsonUtility.FromJsonOverwrite(listaSalvaJson, this);
    }
}

[System.Serializable]
public class Colocado:IComparable
{
    public string nome;
    public int pontuacao;
    public string id;

    public Colocado(string nome, int pontuacao, string id)
    {
        this.nome = nome;
        this.pontuacao = pontuacao;
        this.id = id;
    }

    public int CompareTo(object obj)
    {
        //< 0 se eu venho antes - 0 se eu venho na mesma posicao - > 0 se eu venho depois

        var outroObjeto = obj as Colocado;
        return outroObjeto.pontuacao.CompareTo(this.pontuacao);
    }
}
