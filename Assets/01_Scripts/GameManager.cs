using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Kid[] kids;
    private int index, probabilityForKid;
    public static GameManager instance;
    public int vidas = 3;

    public GameObject perdistePanel;
    public TextMeshProUGUI vidasText;

    private void Awake()
    {
        instance = this;
    }
    //Inicia Corrutina;
    void Start()
    {
        StartCoroutine(DistractingKids());
    }

    void Update()
    {
        if (vidas <= 0)
        {
            Perdiste();
        }
        vidasText.text = vidas.ToString();
    }
    public void Perdiste()
    {
        perdistePanel.SetActive(true);
        SceneManagerScript.instance.CargarEscenaIntro();
    }
    //Define cada cu�nto tiempo un ni�o podr�a distraerse.
    IEnumerator DistractingKids()
    {
        probabilityForKid = UnityEngine.Random.Range(0, 3);
        yield return new WaitForSeconds(2f);
        ConfirmDistraction();
        StartCoroutine(DistractingKids());
    }

    void ConfirmDistraction()
    {
        //Randomiza el ni�o que se distraer�;
        index = UnityEngine.Random.Range(0, 6);
        //Si el ni�o llamado no se encuentra distra�do, se distraer�;
        if (probabilityForKid == 2 && !kids[index].distracted)
        {
            kids[index].distracted = true;
            DistractorsForKids();
        }
        //Si el ni�o llamado se encuentra distra�do, entonces la funcion se repite hasta que encuentre otro ni�o para distraer;
        else if (probabilityForKid == 2)
        {
            ConfirmDistraction();
        }
    }
    //Asigna el ni�o al distractor m�s cercano existente y que no ha llamado a algun otro ni�o anteriormente.
    void DistractorsForKids()
    {
        foreach (Kid k in kids)
        {
            if (k.distracted && k.distraction == null)
            {
                k.distraction = GameObject.FindWithTag("Trap").transform;
                Distract d = k.distraction.GetComponent<Distract>();
                d.called = true;
            }
        }
    }
}
