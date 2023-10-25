using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject panelRojo; // Asigna el panel correspondiente al estado rojo en el Inspector de Unity.
    public GameObject panelVerde; // Asigna el panel correspondiente al estado verde en el Inspector de Unity.

    public TrafficManager trafficManager;
    private void Start()
    {
        trafficManager = FindAnyObjectByType<TrafficManager>();
        // Desactiva ambos paneles al inicio del juego.
        panelRojo.SetActive(false);
        panelVerde.SetActive(false);
    }
    private void Update()
    {
        TrafficLightState estado = trafficManager.currentState;

        // Cambia los paneles seg�n el estado del sem�foro.
        CambiarPanelesSegunEstado(estado);
    }
    private void CambiarPanelesSegunEstado(TrafficLightState estado)
    {
        // Activa o desactiva los paneles seg�n el estado del sem�foro.
        switch (estado)
        {
            case TrafficLightState.Red:
                panelRojo.SetActive(false);
                panelVerde.SetActive(true);
                break;

            case TrafficLightState.Green:
                panelRojo.SetActive(true);
                panelVerde.SetActive(false);
                break;
        }
    }
}
