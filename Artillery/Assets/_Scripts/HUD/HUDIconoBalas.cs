using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class HUDIconoBalas : MonoBehaviour
{
    private Canon jugador;
    public TMP_Text txtLabel;
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
        if (txtLabel != null) txtLabel.text = jugador.GetBalaPrefab().Nombre;
    }
}