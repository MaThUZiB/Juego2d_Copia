using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform positionPlayer;
    private Vector3 posicionInicialCamara;
    void Start()
    {
        posicionInicialCamara = transform.position - positionPlayer.position;
    }

    void LateUpdate()
    {
        Vector3 nuevaPosicion = positionPlayer.position + posicionInicialCamara;
        transform.position = nuevaPosicion;
    }

}
