using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R)) 
        {
            tempoTotalDeGiro = Random.Range(3f, 6f);
            girando =true;
            IniciarGiro();
        }


        if (girando)
        {
            // Gira a roleta com base na velocidade atual
            float anguloGiro = velocidadeAtual * Time.deltaTime;
            roletaRectTransform.Rotate(0, 0, anguloGiro);

            // Reduz a velocidade gradualmente
            tempoTotalDeGiro -= Time.deltaTime;

            if (tempoTotalDeGiro <= 0f)
            {
                // Para a roleta quando o tempo de giro expira
                girando = false;
                Debug.Log("A roleta parou!");
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
        // Reinicializa as variáveis
        tempoTotalDeGiro = Random.Range(3f, 6f);
        girando = true;
        velocidadeAtual = Random.Range(100f, velocidadeMaxima);
    }

}
