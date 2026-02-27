using UnityEngine;

public class AguaSimulacion : MonoBehaviour
{
    [Header ("Tiempo")]
    public float duracionMin = 1f;
    private float timer;
    private int minuto;

    [Header("Parámetros del Tanque")]
    public float capacidadMax = 500f;
    public float aguaActual = 0f;
    public float entrante = 30f;
    public float saliente = 20f;

    [Header("Ajustes Visuales")]
    public float escalaMaximaY = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minuto = 0;

        DrawView();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duracionMin)
        {
            timer = 0;
            Simulate();
            DrawView();
        }
    }

    void Simulate()
    {
        minuto++;

        aguaActual += entrante;
        aguaActual -= saliente;

        aguaActual = Mathf.Clamp(aguaActual, 0f, capacidadMax);

        Debug.Log("Minuto: " + minuto + " / Agua: " + aguaActual + "L");
    }

    void DrawView()
    {
        float porcentaje = aguaActual / capacidadMax;

        Vector3 escala = transform.localScale;
        escala.y = escalaMaximaY * porcentaje;
        transform.localScale = escala;

        transform.localPosition = new Vector3(0, escala.y / 2f, 0);
    }
}
