using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private int valorDado, posAtual, nextPos, tamTabuleiro;
    private bool emMovimento;
    private Transform nextPosTransform;

    // Use this for initialization
    void Start()
    {
        // Setar o tamanho do tabuleiro, 
        // isso permite termos tabuleiros de qualquer tamanho,
        // bastando que cada sprite esteja dentro do GameObject "Board" na Unity.
        tamTabuleiro = GameObject.Find("Board").transform.childCount;

        // Setar a próxima posição no início do jogo
        nextPos = posAtual + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) && !emMovimento)
        {
            // "Jogar" o dado
            valorDado = Random.Range(1, 7);
            // Ligar o movimento
            emMovimento = true;
            // Buscar a nova posição para movimentar o personagem
            nextPosTransform = GameObject.Find("casa" + nextPos).transform;

            Debug.Log("Mover " + valorDado + " casas...");
        }

        if (emMovimento)
        {
            // Definição do sentido do movimento
            // Verificar as casas visitadas
            if (transform.position != nextPosTransform.position)
            {
                // Executar o movimento do personagem
                // transform.Translate(sentidoMov * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, nextPosTransform.position, Time.deltaTime);
            }
            else
            {
                // Diminuir o valor do dado
                valorDado--;
                // Ajustar a posição atual
                posAtual = nextPos;
                // Setar a nova posição, cuidando o tamanho do tabuleiro
                nextPos = posAtual == tamTabuleiro - 1 ? 0 : nextPos + 1;
                // Buscar a próxima posição para movimentar o personagem
                nextPosTransform = GameObject.Find("casa" + nextPos).transform;

                // Verificar a próxima jogada do dado,
                // caso verdadeiro, parar a movimentação.
                if (valorDado == 0)
                {
                    emMovimento = false;
                }
            }
        }
    }
}
