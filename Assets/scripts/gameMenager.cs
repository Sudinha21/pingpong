using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int pontosParaVencer = 5;

    int p1, p2;
    TMP_Text placarP1, placarP2, textoVitoria;
    Bola bola;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        placarP1 = GameObject.Find("PlacarP1").GetComponent<TMP_Text>();
        placarP2 = GameObject.Find("PlacarP2").GetComponent<TMP_Text>();
        textoVitoria = GameObject.Find("TextoVitoria").GetComponent<TMP_Text>();
        bola = FindObjectOfType<Bola>();

        textoVitoria.text = "";
        Atualizar();
    }

    public void Ponto(string vencedor)
    {
        if (vencedor == "p1") p1++;
        else p2++;
        Atualizar();

        if (p1 >= pontosParaVencer || p2 >= pontosParaVencer)
        {
            bola.Parar();
            textoVitoria.text = vencedor + " ganhou!\nAperte Espaço para jogar de novo";
        }
        else
        {
            bola.Reiniciar();
        }
    }

    void Atualizar()
    {
        placarP1.text = p1.ToString();
        placarP2.text = p2.ToString();
    }
}