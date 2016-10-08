using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private int valorDado, posAtual, proxPos, tamTabuleiro;
    private bool emMovimento;
    private Transform proxPosTransform;
	public Text textCasas;

    // Use this for initialization
    void Start()
    {
        // Setar o tamanho do tabuleiro, 
        // isso permite termos tabuleiros de qualquer tamanho,
        // bastando que cada sprite esteja dentro do GameObject "Board" na Unity.
        tamTabuleiro = GameObject.Find("Board").transform.childCount;

        // Setar a próxima posição no início do jogo
		proxPos = posAtual + 1;
    }

    // Update is called once per frame
    void Update()
    {
		// Desativar a contagem
		ActivateDiceUI(emMovimento);

        if (Input.GetKeyDown(KeyCode.D) && !emMovimento)
        {
            // "Jogar" o dado
            valorDado = Random.Range(1, 7);
            // Ligar o movimento
            emMovimento = true;
            // Buscar a nova posição para movimentar o personagem
			proxPosTransform = GameObject.Find("casa" + proxPos).transform;

            Debug.Log("Mover " + valorDado + " casas...");
        }

        if (emMovimento)
        {
            // Definição do sentido do movimento
            // Verificar as casas visitadas
			if (transform.position != proxPosTransform.position)
            {
                // Executar o movimento do personagem
				transform.position = Vector2.MoveTowards(transform.position, proxPosTransform.position, Time.deltaTime);
            }
            else
            {
                // Diminuir o valor do dado
                valorDado--;
                // Ajustar a posição atual
				posAtual = proxPos;
                // Setar a próxima posição, cuidando o tamanho do tabuleiro
				proxPos = posAtual == tamTabuleiro - 1 ? 0 : proxPos + 1;
                // Buscar a próxima posição para movimentar o personagem
				proxPosTransform = GameObject.Find("casa" + proxPos).transform;

                // Verificar a próxima jogada do dado,
                // caso verdadeiro, parar a movimentação.
                if (valorDado == 0)
                {
                    emMovimento = false;

                    // Após o personagem terminar a sua movimentação,
                    // executar alguma outra ação a partir daqui!!! 
                    Debug.Log("Cheguei ao destino!");

                }
            }

			// Escrever a movimentaçao na tela
			EscreverCasasAMovimentar(valorDado);
        }
    }

	// Escrever na HUD
	void EscreverCasasAMovimentar(int valor) {
		// Se o campo de texto nao for nulo, escrever
		if (textCasas != null) {
			textCasas.text = valor.ToString();
		}
	}

	// Ativar o HUD representando os dados
	void ActivateDiceUI(bool activate) {
		textCasas.transform.parent.gameObject.SetActive(activate);
	}
}
