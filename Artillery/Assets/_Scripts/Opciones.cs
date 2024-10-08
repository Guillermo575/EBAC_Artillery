using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Opciones", menuName = "Tools/Opciones", order = 1)]
public class Opciones : ObjetoPersistente
{
    public float VolumenSonido = 0;
    public float VolumenMusica = 0;
    public enum dificultad
    {
        facil,
        normal,
        dificil
    }
    public void CambiarVolumenSonido(float nuevaVolumenSonido)
    {
        VolumenSonido = nuevaVolumenSonido;
    }
    public void CambiarVolumenMusica(float nuevaVolumenMusica)
    {
        VolumenMusica = nuevaVolumenMusica;
    }
}