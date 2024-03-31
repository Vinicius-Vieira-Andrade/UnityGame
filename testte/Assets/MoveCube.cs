using System;
using System.Collections; 
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;
//importando bibliotecas padrao

//o script é a propria classe, no caso criei o script moveCube que é aa classe tbm, a classe que criamos, herda da classe MonoBehavior, pois é padrao unity
public class moveCube : MonoBehaviour
{
    //essa anotacao "SerializeField serve para vermos a varivel diretamente no inspetor, sem ter q torna-la publica, oq não é legal de fazer"
    [SerializeField] private int vida;

    //velocidade cubo
    


    private MeshRenderer Guarda_MeshRenderer;


    private float horizontal;
    private float vertical;
    private bool isRunning = false;

    [SerializeField] private int velocidade;

    // Executado uma unica vez, quando demos play
    void Start()
    {
        vida = 100;

        // o GETCOMPONENT procura um componente do tipo MESHRENDERER dentro do objeto que esse script ta vinculado, e quando encontrar esse componentee dentro do obj ele retorna e atribui componente na variavel Guarda_MeshRenderer!
        Guarda_MeshRenderer = GetComponent<MeshRenderer>();

    }

    // basicamente ele é executado a cada frame, se meu jogo ta rodando a 60fps ele é executado 60 vezes por segundo,
    // geralmente coloca codigos/coisas que precisa ser tratada ao longo do tempo, no decorrer do jogo
    void Update()
    {
        //MudarCor();

        MoverCubo();
    }
    //essa porra de update é tipo laço de repeticao kkkkk



    void MoverCubo()
    {
        //a variavel recebe a leitura das teclas de direcao do teclado,
        //retorna -1 quando pressionamos "A" ou seta pra esquerda,
        //0 quando nao pressionamos nada,
        //retorna 1 quando pressionamos "D" ou seta para direita  
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //Bloco de codigo que verifica se o botao AWSD 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            Guarda_MeshRenderer.material.color = Random.ColorHSV();
        }


        //metodo "transforma.translate()" move um objeto na direcao que informamos, porem,
        //ele pede um parametro(), uma estrutura da unity que armazena posicoes de eixo X Y 
        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * velocidade);
        // Time.deltaTime é um valor que representa a duracao entre um frame e outro, multiplicando por                               ele temos um movimento consistente e mais suave
 

        //logica para correr
        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        //{

        //    isRunning = true;
        //    velocidade = 20;
        //    print("Running");

        //}
    }
}
