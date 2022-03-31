using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private Pontuacao _pontuacao;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private Rect _areaGeracao;
    [SerializeField]
    private Transform _alvo;
    [SerializeField]
    private ReservaDeInimigos reservaInimigo;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, tempo);        
    }

    private void Instanciar()
    {
        if(!reservaInimigo.TemInimigo()) { return; }

        var inimigo = reservaInimigo.PegarInimigo();
        GameObject.Instantiate(inimigo);
        inimigo.SetActive(true);
        this.DefinirPosicaoInimigo(inimigo);
        inimigo.GetComponent<Seguir>().SetAlvo(_alvo);
        inimigo.GetComponent<Pontuavel>().SetPontuacao(_pontuacao);
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector3(
                        Random.Range(_areaGeracao.x, _areaGeracao.x+_areaGeracao.width),
                        Random.Range(_areaGeracao.y, _areaGeracao.y+_areaGeracao.height),
                        0);

        var posicaoInimigo = this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(100, 0, 100);
        var posicao = _areaGeracao.position + (Vector2)transform.position + (_areaGeracao.size / 2);
        Gizmos.DrawWireCube(posicao,_areaGeracao.size);
    }

    
}
