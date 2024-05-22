          using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QUISMANAGE : MonoBehaviour
{
    [Header("Variaveis de Painel")]
    public GameObject painelInicio;
    public GameObject painelJogo;

    [Header("Objetos do Jogo")]
    public TMP_Text textoTitulo;
    public Image imagemQuiz;
    public TMP_Text textoPergunta;
    public TMP_Text[] textoResposta;

    [Header("Conte�do das perguntas")]
    public string[] titulos;
    public Sprite[] imagens;
    public string[] perguntas;
    public string[] alternativa1;
    public string[] alternativa2;
    public string[] alternativa3;
    public string[] alternativa4;
    public int[] alternativaCorreta;
    public int perguntaAtual;

    // Start is called before the first frame update
    void Start()
    {
        painelInicio.SetActive(true);
        painelJogo.SetActive(false);
    }

    //M�todo para iniciar o jogo
    public void IniciarJogo()
    {
        painelInicio.SetActive(false);
        painelJogo.SetActive(true);
        ProximaPergunta(perguntaAtual); 
    }

   //M�todos  para fazer perguntas

    public void ProximaPergunta(int numero)
    {
        textoTitulo.text = titulos[numero];
        imagemQuiz.sprite = imagens[numero];
        textoPergunta.text = perguntas[numero];
        textoResposta[0].text = alternativa1[numero];
        textoResposta[1].text = alternativa2[numero];
        textoResposta[2].text = alternativa3[numero];
        textoResposta[3].text = alternativa4[numero];
    }

    //M�todo para checar as perguntas

    public void ChecarResposta(int numero)
    {
        
        perguntaAtual++;
        if(perguntaAtual >= titulos.Length)
        {
            painelInicio.SetActive(true);
            painelJogo.SetActive(false);
            perguntaAtual = 0;
        }
        else
        {
            ProximaPergunta(perguntaAtual);
        }
    }

    //Co rotina para  mostrar se acertou ou errou
    IEnumerator ValidarResposta(int numero)
    {
        if(numero == alternativaCorreta[perguntaAtual])       
        {
            imagemQuiz.color = Color.green;
        }
        else
        {
            Debug.Log("Errou a pergunta" + perguntaAtual + 1);
        }
        yield return new WaitForSeconds(2);


    }
}
