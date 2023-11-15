using System.Collections;
using System.Collections.Generic;
using static Cores;
using UnityEngine;
using UnityEngine.UI;

public class RoletaController : MonoBehaviour
{
    public RectTransform roletaRectTransform;

    //Parametros para controlar a velocidade, tempo de giro e desaceleração
    public float tempoTotalDeGiro = 5f; 
    public float tempoDeDesaceleracao = 2f; 
    public float velocidadeMaxima = 200f; 
    public AnimationCurve curvaDeDesaceleracao;
    public bool girando = false;
    private float velocidadeAtual;

    //Referencia da seta para que ela seja ativada e desativada
    public GameObject seta;

    void Update()
    {
        if (girando)
        {
            //ativa a seta ao girar
            seta.GetComponent<Image>().enabled = true;

            // Gira a roleta com base na velocidade atual
            float anguloGiro = velocidadeAtual * Time.deltaTime;
            roletaRectTransform.Rotate(0, 0, anguloGiro);

            // Reduz a velocidade gradualmente
            tempoTotalDeGiro -= Time.deltaTime;

            if (tempoTotalDeGiro <= 0f)
            {
                // Para a roleta quando o tempo de giro expira
                girando = false;

                //desativa a seta ao girar
                seta.GetComponent<Image>().enabled = false;
            }
            else
            {
                // Ajusta a velocidade com base na curva de desaceleração   
                float percentualDesaceleracao = 1f - (tempoTotalDeGiro / tempoDeDesaceleracao);
                velocidadeAtual = Mathf.Lerp(velocidadeMaxima, 0f, curvaDeDesaceleracao.Evaluate(percentualDesaceleracao));
            }
        }

        
    }

    public void IniciarGiro()
    {
        // Reinicia as variáveis
        tempoTotalDeGiro = Random.Range(3f, 6f);
        girando = true;
        velocidadeAtual = Random.Range(100f, velocidadeMaxima);
    }
}
