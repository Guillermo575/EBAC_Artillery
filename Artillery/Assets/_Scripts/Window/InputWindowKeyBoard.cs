using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class InputWindowKeyBoard : MonoBehaviour
{
    private InputManager inputManager;
    public TMP_Text txtAnglePositive;
    public TMP_Text txtAngleNegative;
    public TMP_Text txtStrengthPositive;
    public TMP_Text txtStrengthNegative;
    public TMP_Text txtShoot;
    void Start()
    {
        inputManager = InputManager.GetManager();
        var objApuntar = inputManager.GetActionKeys("Canon", "Apuntar", "<Keyboard>", "Teclado_WASD");
        txtAnglePositive.text = objApuntar[0].KeyString.ToUpper();
        txtAngleNegative.text = objApuntar[1].KeyString.ToUpper();
        var objModificarFuerza = inputManager.GetActionKeys("Canon", "Modificar_Fuerza", "<Keyboard>", "Teclado_WASD");
        txtStrengthPositive.text = objModificarFuerza[0].KeyString.ToUpper();
        txtStrengthNegative.text = objModificarFuerza[1].KeyString.ToUpper();
        var objShoot = inputManager.GetActionKeys("Canon", "Disparar", "<Keyboard>");
        txtShoot.text = objShoot[0].KeyString.ToUpper();
    }
}