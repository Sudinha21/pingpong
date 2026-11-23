using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public float velocidadeInicial = 5f;
    public float incremento = 1f;
    public float velocidadeMaxima = 14f;
    public int batidasParaAcelerar = 2;

    float velocidadeAtual;
    int batidas;
    bool fim;
    Vector2 ultimaVelocidade;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Lancar();
    }

    void Update()
    {
        // Depois do gol, Espaço reinicia a partida
        if (fim && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void FixedUpdate()
    {
        if (!fim) ultimaVelocidade = rb.linearVelocity;
    }

    public void Lancar()
    {
        velocidadeAtual = velocidadeInicial;
        batidas = 0;

        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        rb.linearVelocity = new Vector2(x, y).normalized * velocidadeAtual;
    }

    public void Parar()
    {
        fim = true;
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (fim) return;

        if (col.gameObject.name == "p1" || col.gameObject.name == "p2")
        {
            batidas++;
            if (batidas % batidasParaAcelerar == 0)
                velocidadeAtual = Mathf.Min(velocidadeAtual + incremento, velocidadeMaxima);
        }

        Vector2 normal = col.contacts[0].normal;
        Vector2 direcao = Vector2.Reflect(ultimaVelocidade, normal).normalized;
        rb.linearVelocity = direcao * velocidadeAtual;
    }
    public void Reiniciar()
{
    transform.position = Vector3.zero;
    Lancar();
}
}