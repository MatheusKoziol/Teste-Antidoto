using System.Collections;
using TMPro;
using UnityEngine;
using static Cores;

public class SetaController : MonoBehaviour
{

    //Referencias para as mensagens que aparecem na tela
    public TMP_Text mensagemTxt;
    public TMP_Text perguntaTxt;

    //Parametros que controlam qual cor foi selecionada
    public RoletaController roletaController;
    public CorSelecionada cor;

    //Parametro que verifica se a roleta ja foi rodada desde a execução do jogo
    public bool primeiraVez = true;

    //referencia ds objetos que serão ativados/desativados conforme a roleta gira
    public GameObject botaoGirar;
    public GameObject LogoRed;

    private void Update()
    {
        if (!roletaController.girando)
        {
            ExibirMensagem();
            if (!primeiraVez)
            {
                mensagemTxt.gameObject.SetActive(true);
                botaoGirar.gameObject.SetActive(true);
                roletaController.gameObject.SetActive(false);
            }
            perguntaTxt.gameObject.SetActive(false);
            LogoRed.gameObject.SetActive(true);

        }
        else
        {
            mensagemTxt.gameObject.SetActive(false);
            perguntaTxt.gameObject.SetActive(true);
            botaoGirar.gameObject.SetActive(false);
            LogoRed.gameObject.SetActive(false);
            roletaController.gameObject.SetActive(true);
        }

    }

    //Exibe a mensagem de vitória ou derrota após a roleta parar de girar
    private void ExibirMensagem()
    {

        switch (cor)
        {
            case CorSelecionada.azul:
            case CorSelecionada.verde:
                mensagemTxt.text = "Sinto muito, não foi dessa vez.";
                break;
            case CorSelecionada.vermelho:
            case CorSelecionada.amarelo:
                mensagemTxt.text = "Parabéns! Você vai se tornar um milionário!";
                break;
            default:
                break;
        }
    }

    //Verifica com qual cor a seta está colidindo
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!roletaController.girando) return;

        switch (collision.tag)
        {
            case "ParteAmarela":
                cor = CorSelecionada.amarelo;
                break;
            case "ParteAzul":
                cor = CorSelecionada.azul;
                break;
            case "ParteVerde":
                cor = CorSelecionada.verde;
                break;
            case "ParteVermelha":
                cor = CorSelecionada.vermelho;
                break;
        }
    }

    public void GirouPrimeiraVez() => primeiraVez = false;
}
