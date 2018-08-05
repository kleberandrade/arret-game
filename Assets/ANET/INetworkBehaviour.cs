﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ANET
{
    namespace Networking
    {
        /**
         * Adaptador de rede do jogo, recebe eventos enviados
         * pela classe Networking, quando mensagens específicas 
         * para cada evento é recebido pela rede.
         * A classe Networking trata estas mensagens recebidas
         * e encaminha o payload para os respectivos eventos.
         * A maioria dos eventos recebe um parâmetro de método 
         * chamado payload.
         * Para utilizar este adaptador basta criar um script C# e 
         * extender INetworkBehaviour ao invés de MonoBehaviour.
         * Todo e qualquer script que extende INetworkBehaviour 
         * vai receber todos os eventos recebidos pela interface 
         * de rede.
         * Para capturá-los basta extender o método desejado e 
         * utilizar os dados recebidos.
         * Formato de propagação de eventos muito similar 
         * ao Photon Unity Networking.
         * @public
         * @type {InetworkBehaviour}
         */
        public class INetworkBehaviour : MonoBehaviour
        {

            public virtual void Start()
            {
                // Debug.Log(this is INetworkBehaviour);
                if(Networking.Instance)
                    Networking.Instance.Register(gameObject);
            }

            /**
             * 
             */
            public virtual void OnConnected()
            {

            }

            /**
             * Notifica o client que um novo jogador adentrou a sala.
             * 
             * O payload é recebido em formato JSONObject. É uma classe
             * para serialização de objetos JSON baseado em Dictionary. Ou seja, 
             * o conteúdo é armazenado em formato chave/valor.
             * JSONObject parseia automaticamente os tipos de dados para o mais adequado.
             * Valores numéricos recebidos com ponto flutuante são automaticamente convertidos
             * para float e devem ser acessados via GetFloat. Valores numéricos recebidos 
             * sem ponto flutuante são automaticamente convertidos para int e devem ser acessados
             * via GetFloat.
             * 
             * @public
             * @type {void}
             * @param {JSONObject} payload Conteúdo da mensagem recebido pela rede em formato JSON.
             * 
             * @example
             * // Layout do payload:
             * //  {
             * //      grid        : string, // Representa o id da GameRoom onde o client atual entrou.
             * //      newuser     : bool,   // Diz para o jogador que entrou na sala se ele é um novo joador ou não.
             * //      totalusers  : number, // Representa o número atualizado de jogadores na GameRoom atual.
             * //      startgame   : bool,   // Representa se a partida deve começar ou não. Utilizado para chamar o carregamento da cena de gamplay após a GameRoom estar completa.
             * //      host        : bool    // Representa se o client atual deve se assumir como host da partida ou não.
             * //  }
             * payload.GetBool("newuser");    // Obtém o valor do campo "newuser" do tipo {bool} do payload.
             * payload.GetInt("totalusers");  // Obtém o valor do campo "totalusers" do tipo {int} do payload.
             */
            public virtual void OnJoinRoom(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o client que o jogo atual foi 
             * abortado/encerrado por qualquer motivo.
             * O server emite este evento para todos os clients 
             * conectados em uma GameRoom quando um dos clients
             * se desconecta em meio a uma partida.
             * 
             * O payload é recebido em formato JSONObject. É uma classe
             * para serialização de objetos JSON baseado em Dictionary. Ou seja, 
             * o conteúdo é armazenado em formato chave/valor.
             * JSONObject parseia automaticamente os tipos de dados para o mais adequado.
             * Valores numéricos recebidos com ponto flutuante são automaticamente convertidos
             * para float e devem ser acessados via GetFloat. Valores numéricos recebidos 
             * sem ponto flutuante são automaticamente convertidos para int e devem ser acessados
             * via GetFloat.
             * 
             * @public
             * @type {void}
             * @param {JSONObject} payload Conteúdo da mensagem recebido pela rede em formato JSON.
             *
             * @example
             * // Layout do payload:
             * // {
             * //     errormsg : 'A player has been disconected from the game' // Mensagem de erro que ocasionou o aborto do game.
             * // }
             * payload.GetString("errormesg");
             */ 
            public virtual void OnGameAbort(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o client de que ele foi desconectado do server.
             * Isto pode acontecer por qualquer motivo, o server caiu, ou
             * a conexão de internet do client foi perdida.
             * Nenhum payload é recebido neste evento.
             * @public
             * @type {void}
             */
            public virtual void OnServerDisconection()
            {
                // To be overriden
            }

            /**
             * Notifica o client que o a conexão com 
             * o server foi realizada com sucesso.
             * Nenhum payload é recebido neste evento.
             * @public
             * @type {void}
             */
            public virtual void OnServerConnected()
            {
                // To be overriden
            }

            /**
             * Notifica o client que um player finalizou o processo de 
             * carregamento da cena de gamplay e pode comecar a jogar.
             * Define tambem se a partida deve comecar ou aguardar 
             * outros players carregarem a partida.
             *  
             * O payload é recebido em formato JSONObject. É uma classe
             * para serialização de objetos JSON baseado em Dictionary. Ou seja, 
             * o conteúdo é armazenado em formato chave/valor.
             * JSONObject parseia automaticamente os tipos de dados para o mais adequado.
             * Valores numéricos recebidos com ponto flutuante são automaticamente convertidos
             * para float e devem ser acessados via GetFloat. Valores numéricos recebidos 
             * sem ponto flutuante são automaticamente convertidos para int e devem ser acessados
             * via GetFloat.
             * 
             * @public
             * @type {void}
             * @param {JSONObject} payload Conteúdo da mensagem recebido pela rede em formato JSON.
             * 
             * @example
             * // Layout do payload:
             * // {
             * //     start : bool
             * // }
             * payload.GetBool("start"); // Obtém o valor do campo "start" do tipo {bool} do payload. Diz se a partida deve ser iniciada ou não.
             */
            public virtual void OnGameplayLoaded(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o player atual da cor que 
             * ele deverá usar para se representar
             * na partida.
             *  
             * O payload é recebido em formato JSONObject. É uma classe
             * para serialização de objetos JSON baseado em Dictionary. Ou seja, 
             * o conteúdo é armazenado em formato chave/valor.
             * JSONObject parseia automaticamente os tipos de dados para o mais adequado.
             * Valores numéricos recebidos com ponto flutuante são automaticamente convertidos
             * para float e devem ser acessados via GetFloat. Valores numéricos recebidos 
             * sem ponto flutuante são automaticamente convertidos para int e devem ser acessados
             * via GetFloat.
             * 
             * @public
             * @type {void}
             * @param {JSONObject} payload Conteúdo da mensagem recebido pela rede em formato JSON.
             * 
             * @example
             * // {
             * //     color : string // ("blue" | "red")
             * // }
             * payload.GetString("color"); // Obtém o valor do campo "color" do tipo {string} do payload. 
             */ 
            public virtual void OnColorSet(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o client de que um 
             * drone foi colocado no mapa.
             *  
             * O payload é recebido em formato JSONObject. É uma classe
             * para serialização de objetos JSON baseado em Dictionary. Ou seja, 
             * o conteúdo é armazenado em formato chave/valor.
             * JSONObject parseia automaticamente os tipos de dados para o mais adequado.
             * Valores numéricos recebidos com ponto flutuante são automaticamente convertidos
             * para float e devem ser acessados via GetFloat. Valores numéricos recebidos 
             * sem ponto flutuante são automaticamente convertidos para int e devem ser acessados
             * via GetFloat.
             * 
             * @public
             * @type {void}
             * @param {JSONObject} payload Conteúdo da mensagem recebido pela rede em formato JSON.
             * 
             * @example
             * // Layout do payload:
             * // {
             * //     x       : float,    // Posição em x que o drone foi colocado.
             * //     y       : float,    // Posição em y que o drone foi colocado.
             * //     z       : float ,   // Posição em z que o drone foi colocado.
             * //     color   : string,   // Cor do drone que foi colocado.
             * //     droneId : int       // Id do novo drone colocado.
             * // }
             * payload.GetFloat("x");     // Obtém o valor do campo "x" do tipo {float} do payload.
             * payload.GetInt("droneId"); // Obtém o valor do campo "droneId" do tipo {id} do payload.
             */
            public virtual void OnDronePlace(JSONObject payload)
            {

            }

            /**
             * Notifica o client de que um drone foi destruido
             * {
             *  x     : float,
             *  y     : float,
             *  z     : float ,  
             *  color : string
             * }
             */
            public virtual void OnDroneDestroy(JSONObject payload)
            {

            }

            /**
             * Notifica o client de que a partida comecou
             */
            public virtual void OnMatchStarted()
            {

            }

            /**
             * Notifica o client do tempo total da partida
             * {
             *  m : int, // minutos
             *  s : int, // segundos
             *  t : int  // tempo total em segundos
             * }
             */
            public virtual void OnTick(JSONObject payload)
            {

            }

            /**
             * Notifica o client da nova posicao do alien
             * {
             *  x : float,
             *  y : float,
             *  z : float
             * }
             */
            public virtual void OnAlienMove(JSONObject payload)
            {

            }

            /**
             * Notifica o client de que o game acabou e traz o resultado da partida.
             * {
             *  winner : "blue" | "red" | "vr"
             * }
             */
            public virtual void OnGameOver(JSONObject payload)
            {

            }

            /**
             * Notifica o client de que ganhou a partida.
             */
            public virtual void OnVictory()
            {

            }

            /**
             * Notifica o client de que perdeu a partida.
             */
            public virtual void OnDefeat()
            {

            }
        }
    }
}
