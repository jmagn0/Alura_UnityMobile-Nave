using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelRanking : MonoBehaviour
{
    [SerializeField] private Ranking _rank;
    [SerializeField] private GameObject colocadoPrefab;

    void Start()
    {
        var listaColocados = _rank.ListaPontuacao();

        for (int i = 0; i < listaColocados.Count; i++)
        {
            if (i >= 5) break;

            var obj = Instantiate(colocadoPrefab, this.transform);
            obj.GetComponent<ItemColocado>().ConfigurarColocado(i + 1, listaColocados[i].nome, listaColocados[i].pontuacao);
        }    
    }
}
