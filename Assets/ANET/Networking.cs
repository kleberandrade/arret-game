using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

namespace ANET
{

    namespace Networking
    {

        /**
         * Esta calsse possui constantes estáticas
         * utiliazdas para representar o modo de jogo.
         * Pode ser VR ou MOBILE.
         * Tanto VR quanto MOBILE são executados em dispositivos
         * mobile, porém o VR é executado com dipositivos
         * montados na cabeça (como GEAR VR ou GEAR BOX).
         */
        public class GameMode
        {
            /**
             * Constante que representa o 
             * tipo de gameplay "VR".
             * Jogador controla o alien.
             * Este player é considerado o host 
             * da partida.
             * @type {uint}
             * @public
             * @static
             */
            public static readonly uint VR = 0;

            /**
             * Constante que representa o tipo de gameplay MOBILE.
             * Um dos jogadores controla os drones.
             * @type {uint}
             * @public
             * @static
             */
            public static readonly uint MOBILE = 1;
        }

        /**
         * Esta classe é responsável por todo a interface
         * de comunição de rede do ARRET. Esta classe é 
         * desenvolvida em cima da implementação de SocketIO
         * para Unity baixada da Unity Asset Store.
         * @public
         * @type {Networking}
         * @class
         * @extends {MonoBehaviour}
         */
        public class Networking : MonoBehaviour
        {
            #region Static constants
            
            /**
             * Constante estática que representa o jogador de cor azul (Drone).
             * @static
             * @public
             * @type {String}
             */
            public static readonly string PLAYER_COLOR_BLUE = "blue";

            /**
             * Constante estática que representa o jogador de cor vermelha (Drone).
             * @type {String}
             * @public
             * @static
             */
            public static readonly string PLAYER_COLOR_RED = "red";

            /**
             * Constante estática que representa o jogador de que controla o Alien.
             * @type {String}
             * @public
             * @static
             */
            public static readonly string PLAYER_COLOR_NONE = "";
            #endregion

            #region Static Fields

            /**
             * Este é o campo estático que 
             * armazena a referência
             * da instância de Networking.
             *
             * Padrão Singleton.
             * @public
             * @static
             * @type {Networking}
             */
            static private Networking _instance;
            #endregion

            #region Privates Fields

            /**
             * Campo privado do tipo boolean que representa
             * se a isntância atual do game é o host da partida.
             * Apesar de o game ser totalmente online e conectado a 
             * um servidor, em toda partida um dos jogadores é 
             * considerado o host da partida. Este jogador é o 
             * que escolhe o gameMode "VR".
             * @private
             * @type {bool}
             */
            private bool host = false;

            /**
             * Campo privado do tipo string 
             * que armazena a cor do jogador 
             * da instância atual do jogo.
             * @private
             * @type {String}
             */
            private string color = "";

            /**
             * Campo privado do tipo SocketIOComponent.
             * SocketIOComponent é uma classe da 
             * implementação SocketIO Unity responsável 
             * por enviar e receber mensagens via protocolo
             * WebSocket.
             * @private
             * @type {SocketIOComponent}
             */
            private SocketIOComponent io;

            /**
             * Campo público do tipo List<GameObject>.
             * Armazena uma lista de GameObjects que se 
             * inscreveram para serem sincronizados em 
             * rede na partida. Isto é, terão seus dados 
             * trafegados pela rede.
             * @public
             * @type {List}
             */
            public List<GameObject> networked = new List<GameObject> ();
            #endregion

            #region Public Properties

            /**
             * Propriedade pública que dá acesso à instância de Networking do game.
             * Padrão Singleton.
             * @public
             * @static
             * @readonly
             * @type {Networking}
             * @example
             * // Retorna a única instância de Networking.
             * Networking.Instance;
             */
            static public Networking Instance
            {
                get
                {
                    return _instance;
                }
            }

            /**
             * Propriedade pública que diz se esta 
             * instância de jogo é o @{host} da partida.
             * @public
             * @type {bool}
             * @readonly
             * @example
             * Networking.Instance.Host;
             * // Retorna true se for o host, false se não for.
             */
            public bool Host
            {
                get
                {
                    return host;
                }
            }

            /**
             * Propriedade pública que dá acesso ao
             * componente SocletIO da implementação
             * SocketIO Unity.
             * No momento da atribuição deste componente
             * a classe Networking verifica se o client já 
             * está conectado ao servidor, se não estiver,
             * conecta-o.
             * @public
             * @type {SocketIOComponent}
             */
            public SocketIOComponent IO
            {
                get
                {
                    return io;
                }

                set
                {
                    io = value;

                    if(!io.IsConnected)
                        Connect();
                }
            }

            /**
             * Propriedade pública que dá acesso
             * à cor do player desta instância de jogo.
             * @public
             * @type {string}
             * @example
             * Networking.Instance.PlayerColor == Networking.PLAYER_COLOR_BLUE;
             * // Checa se a cor do jogador da instância atual do jogo é azul.
             */
            public string PlayerColor
            {
                get
                {
                    return color;
                }
                set
                {
                    color = value;
                }
            }
            #endregion

            #region Unity Interface

            /**
             * No método awake checamos se já existe uma 
             * instância de Networking, se já existir, destruimos 
             * esta instãncia para que apenas uma esteja em vigor.
             * Padrão singleton.
             * Se não, atribuimos esta instância à referência _instance.
             */
            private void Awake()
            {
                if (_instance)
                {
                    Destroy(gameObject);
                }
                else
                {
                    _instance = this;
                }
            }
            #endregion

            #region Static Methods

            /**
             * Este método é responsável por 
             * forçar um truncamento das casas 
             * após a virgula a fim de evitar imprecisões
             * no tráfego de valores float pela rede.
             * @param {Vector3} vec Vector3 a ser truncado.
             * @return {Vector3} Vector3 com algumas casas decimais truncadas.
             * @example
             * Vector3 vec = new Vector3(1.2335f,1.2335f,1.2335f);
             * vec = Networking.TruncVec(vec);
             * print(vec); // O retorno será algo próximo à Vector3(1.23f,1.23f,1.23f)
             */
            public static Vector3 TrunVec(Vector3 vec)
            {
                return new Vector3(
                    (int)(vec.x * 10) / 10.0f,
                    (int)(vec.y * 10) / 10.0f,
                    (int)(vec.z * 10) / 10.0f
                );
            }
            #endregion

            #region Public Interface

            /**
             * Método responsável por conectar esta instância 
             * do game, ao servidor. Este método apenas abre 
             * a conexão Socket e solicita o bind do servidor.
             * Este método não adentra salas de jogos nem envia 
             * mensagens.
             * Este método declara os principais eventos do SocketIO
             * e gerencia internamente a maioria dos envios e recebimentos
             * de mensagens e disparo dos eventos do jogo.
             * Este método é chamado automaticamente no início da cena
             * quando o método Awake for executado.
             * @public
             * @type {void}
             */
            public void Connect()
            {
                if (io)
                {
                    io.Connect();

                    io.On("disconnect", new Action<SocketIOEvent>((SocketIOEvent evt) => {
                        BroadcastAMessage("OnServerDisconection", null);
                    }));

                    io.On("connect", new Action<SocketIOEvent>((SocketIOEvent evt) => {
                        BroadcastAMessage("OnServerConnected", null);
                        Debug.Log("Successfully connected to the server.");
                    }));

                    io.On("action", new Action<SocketIOEvent>((SocketIOEvent evt) => {
                        string action = evt.data.GetField("action").str;
                        JSONObject payload = evt.data.GetField("payload");
                        // Debug.Log("ACTION: "+action);

                        if (action == "joinRoom")
                        {
                            host = payload.GetField("host").b;
                            Debug.Log("HOST: " + Host);
                            BroadcastAMessage("OnJoinRoom", payload);
                        }
                        else if (action == "abortGame")
                        {
                            BroadcastAMessage("OnGameAbort", payload);
                        }
                        else if(action == "gameplayLoaded")
                        {
                            BroadcastAMessage("OnGameplayLoaded", payload);
                            if (payload.GetField("start").b)
                            {
                                BroadcastAMessage("OnMatchStarted", null);
                            }
                        }
                        else if (action == "setColor")
                        {
                            BroadcastAMessage("OnColorSet", payload);
                        }
                        else if(action == "placeDrone")
                        {
                            BroadcastAMessage("OnDronePlace", payload);
                        }
                        else if(action == "tick")
                        {
                            BroadcastAMessage("OnTick", payload);
                        }
                        else if(action == "destroyDrone")
                        {
                            BroadcastAMessage("OnDroneDestroy", payload);
                        }
                        else if(action == "moveAlien")
                        {
                            BroadcastAMessage("OnAlienMove", payload);
                        }
                        else if (action == "gameOver")
                        {
                            BroadcastAMessage("OnGameOver", payload);

                            if (payload.HasField("winner"))
                            {
                                string winner = payload.GetField("winner").str;
                                if(winner == "vr")
                                {
                                    if (Host) // Se for host, pq host é o player VR nesse caso.
                                    {
                                        BroadcastAMessage("OnVictory", payload);
                                    }
                                    else
                                    {
                                        BroadcastAMessage("OnDefeat",null);
                                    }
                                }
                                else
                                {
                                    if(winner == color)
                                    {
                                        BroadcastAMessage("OnVictory",null);
                                    }
                                    else
                                    {
                                        BroadcastAMessage("OnDefeat",null);
                                    }
                                }
                            }
                        }
                    }));
                }
            }

            /**
             * Inscreve (ou registra) um GameObject
             * na lista de objetos sincronizados na
             * rede na partida.
             * Todos os eventos do jogo que forem recebidos
             * pelo Socket são propagados por toda a cena
             * para todos os objetos inscritos por este método.
             * @public
             * @type {void}
             * @param {GameObject} go Instância de GameObject a ser inscrito na lista de objetos sincronizados na rede na partida.
             * @example
             * // Utilização
             * Networking.Instance.Register(gameObject);
             */
            public void Register(GameObject go)
            {
                if(!networked.Contains(go))
                    networked.Add(go);
                // Debug.Log(networked.Count);
            }

            /**
             * Este método é uma hack do método nativo da Unity
             * BroadcastMessage. A diferença é que BoardcastMessage (nativo)
             * propaga uma mensagem para todos os componentes de um GameObject.
             * Já BroadcastAMessage (hack) propaga para todos os objetos inscritos 
             * em Networking.
             * Apesar de sua visibilidade pública, dificilmente este método 
             * será utilizado publicamente, pois todo o gerencimanto de propagação de
             * mensagens é realizado de forma privada dentro da classe Networking.
             * Pode ser utilizado de publicamente a fim de forçar a propagação de alguns
             * eventos, útil para prototipação, teste e mockup.
             * Este método é construído em cima da utilização do método nativo do Unity SendMessage.
             * @public
             * @type {void}
             * @param {string} methodName   String que contém o nome do método a ser invocado no objeto que recebe a mensagem.
             * @param {JSONOBject} payload  Contém os dados recebidos do servidor. É uma instância de JSONObject, classe da implementação de SocketIO Unity que atua como um hash map (encapsulamento de pares chave/valor) para abstrair de forma simplificada objetos JSON. 
             * @example
             * // Propaga um evento de OnServerDisconection sem payload
             * Networking.Instance.BroadcastAMessage("OnServerDisconection", null);
             * // Propaga um evento de OnServerDisconection com payload
             * Networking.Instance.BroadcastAMessage("OnJoinRoom", payload);
             * @todo Poderíamos implementar uma melhoria aqui, evitando a utilização do SendMessage a fim de melhorar a performance. 
             */
            public void BroadcastAMessage(string methodName,JSONObject payload)
            {
                networked.RemoveAll((GameObject item) => {
                   return item == null;
                });

                foreach(GameObject go in networked)
                {
                    
                    if (payload != null)
                    {
                        go.SendMessage(methodName, payload,SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        go.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
                    }
                    //Debug.Log(methodName+", "+go.name);
                }
                // Debug.Log("-------------------");

            }

            /**
             * Envia uma requisição/solicitação de criação
             * de uma nova partida para o servidor.
             * Recebe o tipo do jogador que está requisitando 
             * a partida. Este dado é importante pois o 
             * servidor vai distribuindo automaticamente os 
             * jogadores conforme seus respectivos tipos e 
             * formando partidas completas.
             * @public
             * @type {void}
             * @param {uint} gameMode Tipo do jogador que está requisitando uma partida.
             * @example
             * // Utilização
             * Networking.Instance.MakeMatch(GameMode.VR); // Solicita a criação de uma partida e diz para o servidor que o player solicitante joga como VR.
             */
            public void MakeMatch(uint gameMode)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "makematch");

                if(gameMode == GameMode.MOBILE)
                {
                    payload.AddField("type", "mobile");
                }else if(gameMode == GameMode.VR)
                {
                    payload.AddField("type", "vr");
                }

                io.Emit("action",payload);

            }

            /**
             * Envia para o servidor uma requisição
             * dizendo que a cena onde se dá o gameplay
             * foi totalmente carregada e está executando.
             * Serve para iniciar a sincronia da partida com 
             * todos os jogadores conectados na mesma.
             * Pode ser chamado no método Start de algum objeto
             * da cena de gameplay.
             * @public
             * @type {void}
             * @example
             * // Utilização
             * Networking.Instance.GameplaySceneLoaded(); // Notifica o server que o gameplay começou para esta instância de jogo.
             */
            public void GameplaySceneLoaded()
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "gameplayLoaded");

                io.Emit("action",payload);
            }

            /**
             * Este método funciona como uma espécie de 
             * heartbeat indicando que cada client está vivo.
             * Este método é chamado a cada 15 segundos 
             * por cada client.
             * A cada tick o servidor responde com um 
             * evento OnTick recebido pelo client, onde
             * no payload é recebido o tempo total de 
             * partida (autoritativo no server).
             * @public
             * @type {void}
             */
            public void Tick()
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "tick");

                io.Emit("action",payload);
            }

            /**
             * Envia para o servidor uma requisição
             * dizendo que o jogador atual está 
             * colocando um drone.
             * O ideal seria que o servidor gerasse 
             * o novo id para o drone e retornasse-o 
             * para o client solicitante.
             * Porém para evitar mais uma mensagem, resolvemos 
             * que um dos players coloca apenas drones de ID par e 
             * o outro apenas drones de ID impar. Assim o 
             * server não precisa manter uma lista de qual drone
             * pertence a qual jogador.
             * @public
             * @type {void}
             * @param {int} droneId Id do drone que está sendo colocado.
             * @param {Vector3} position Posição tridimensional onde o Drone está sendo colocado.
             * @example
             * Networking.Instance.PlaceDrone(droneId, towerTransform.position); // Envia o position (truncado no BuildManager) pela rede.
             */
            public void PlaceDrone(int droneId, Vector3 position)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "placeDrone");

                payload.AddField("droneId", droneId);
                payload.AddField("x", position.x);
                payload.AddField("y", position.y);
                payload.AddField("z", position.z);

                io.Emit("action", payload);
            }

            /**
             * Envia para o servidor uma requisição
             * dizendo que o jogador atual está 
             * destruindo um de seus drones.
             * Segue a mesma logica do placeDrone, onde
             * os ids pares são de um player e os ímpares 
             * de oturo.
             * O server então propaga esta mensagem aos demais 
             * players para que os clients removam os drones de 
             * suas respectivas instâncias de game.
             * @public
             * @type {void}
             * @param {int} droneId Id do drone a ser destruído.
             * @example
             * Networking.Instance.PlaceDrone(droneId, towerTransform.position); // Envia o position (truncado no BuildManager) pela rede.
             */
            public void DestroyDrone(int droneId)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "destroyDrone");

                payload.AddField("droneId", droneId);

                io.Emit("action", payload);
            }

            /**
             * Envia para o servidor uma mensagem
             * atualizando a posição do alien.
             * Este método deve ser utilizado apenas
             * pelo client cujo jogador joga 
             * como gameMode "VR".
             * @public
             * @type {void}
             * @param {Vector3} newPosition Nova posição de alien.
             * @example
             * Networking.Instance.MoveAlien(gameObject.transform.position); // Envia o novo position do gameObject que corresponde ao player "VR" (alien).
             */
            public void MoveAlien(Vector3 newPosition)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "moveAlien");

                payload.AddField("x", newPosition.x);
                payload.AddField("y", newPosition.y);
                payload.AddField("z", newPosition.z);

                io.Emit("action", payload);
            }


            /**
             * Envia para o servidor uma mensagem
             * notificando o servidor de que o game acabou.
             * Esta mensagem deve ser enviada somente 
             * pelo jogador considerado 
             * o host da partida (player "VR").
             * Pois será o jogador host da partida 
             * o responsável por calculará a vitória 
             * da partida e o momento do GameOver.
             * @public
             * @type {void}
             * @param {string} _color representa Indica o vencedor da partida. Três valores possíveis "blue" | "red" | "vr". Apesar do valor "vr" não representar uma cor, precisávamos de um valor para representar o alien (jogador VR).
             * @example
             * Networking.Instance.GameOver("vr");   // Indica o final da partida, vitória para o jogador "VR".
             * Networking.Instance.GameOver("red");  // Indica o final da partida, vitória para o jogador "vermelho".
             * Networking.Instance.GameOver("blue"); // Indica o final da partida, vitória para o jogador "azul".
             */
            public void GameOver(string _color)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "gameOver");

                if (_color == PLAYER_COLOR_BLUE)
                {
                    payload.AddField("winner", "blue");
                }
                else if(_color == PLAYER_COLOR_RED)
                {
                    payload.AddField("winner", "red");
                }
                else
                {
                    payload.AddField("winner", "vr");
                } 

                io.Emit("action", payload);
            }
            #endregion


        }
    }
}

