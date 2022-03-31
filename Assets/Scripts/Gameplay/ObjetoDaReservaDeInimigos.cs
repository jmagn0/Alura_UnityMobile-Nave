using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDaReservaDeInimigos : MonoBehaviour
{
    private ReservaDeInimigos _minhaReserva;

    public void DevolverParaReserva()
    {
        _minhaReserva.DevolverInimigo(this.gameObject);
    }

    public void SetReserva(ReservaDeInimigos reserva)
    {
        _minhaReserva = reserva;
    }
}
