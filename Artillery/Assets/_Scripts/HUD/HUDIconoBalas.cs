using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class HUDIconoBalas : MonoBehaviour
{
    private Canon jugador;
    public List<Sprite> lstImages;
    void Start()
    {
        jugador = GameObject.FindObjectsByType<Canon>(FindObjectsSortMode.InstanceID)[0];
    }
    void Update()
    {
        var nombre = "HUD_Bala_" + jugador.GetBalaPrefab().Nombre;
        var lst = (from x in lstImages where x.name == nombre select x).ToList();
        this.gameObject.GetComponent<Image>().sprite = lst.First();
    }
}