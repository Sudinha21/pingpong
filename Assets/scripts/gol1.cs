using UnityEngine;
using TMPro;

public class gol1 : MonoBehaviour
{
    public string vencedor = "win2";
    TMP_Text textoVitoria;

    void Start()
    {
        textoVitoria = FindObjectOfType<TMP_Text>();
        textoVitoria.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Bola bola = other.GetComponent<Bola>();
        if (bola == null) return;

        bola.Parar();
        textoVitoria.text = vencedor + " ganhou!\nAperte Espaço para jogar de novo";
    }
}