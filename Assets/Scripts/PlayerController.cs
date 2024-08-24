using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distanciaRayo = 10f;
    public float velocidadElevacion = 2f;
    public string tagObjetivo = "Piso";
    [SerializeField] Transform origen;

    void Update()
    {
        
        Vector3 direccion = Vector3.down;

        RaycastHit hit;

        if (Physics.Raycast(origen.position, direccion, out hit, distanciaRayo))
        {
            if (hit.transform.CompareTag(tagObjetivo))
            {
                ElevarObjeto(hit.point);
                print("Hola");
            }
        }
        Debug.DrawRay(origen.position, direccion * distanciaRayo, Color.red);
    }

    void ElevarObjeto(Vector3 puntoImpacto)
    {
        Vector3 posicionObjetivo = new Vector3(transform.position.x, puntoImpacto.y, transform.position.z);

        transform.position = posicionObjetivo;
    }
}
