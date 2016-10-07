using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private int valorDado, posAtual, nextPos;
    private bool emMovimento;
    private Transform nextPosTransform;
    private Vector2 sentidoMov;

    // Use this for initialization
    void Start()
    {
        nextPos = posAtual + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) && !emMovimento)
        {
            valorDado = Random.Range(1, 7);
            emMovimento = true;
            nextPosTransform = GameObject.Find("casa" + nextPos).transform;
            sentidoMov = Vector2.zero;
            Debug.Log("Mover " + valorDado + " casas...");
        }

        if (emMovimento)
        {
            // Definição do sentido do movimento
            // Verificar as casas visitadas
            if (transform.position.x < nextPosTransform.position.x)
            {
                // Sentido de movimento para esquerda
                sentidoMov = transform.right;
            }
            else if (transform.position.y > nextPosTransform.position.y)
            {
                // Sentido de movimento para baixo
                sentidoMov = -transform.up;
            }
            else
            {
                valorDado--;
                posAtual = nextPos;
                nextPosTransform = GameObject.Find("casa" + ++nextPos).transform;

                if (valorDado == 0)
                {
                    emMovimento = false;
                }
            }

            // Executar o movimento do personagem
            transform.Translate(sentidoMov * Time.deltaTime);
        }
    }

}
