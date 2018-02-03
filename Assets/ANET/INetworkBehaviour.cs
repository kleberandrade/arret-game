using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ANET
{
    namespace Networking
    {
        public class INetworkBehaviour : MonoBehaviour
        {

            public virtual void Start()
            {
                // Debug.Log(this is INetworkBehaviour);
                if(Networking.Instance)
                    Networking.Instance.Register(gameObject);
            }

            public virtual void OnConnected()
            {

            }

            /*
             * Notifica o client que um novo jogador adentrou a sala
             * {
             *  grid        : string,
             *  newuser     : bool,
             *  totalusers  : number,
             *  startgame   : bool,
             *  host        : bool
             *  }
             */
            public virtual void OnJoinRoom(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o client que o jogo atual foi abortado/encerrado por qualquer motivo
             */ 
            public virtual void OnGameAbort(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o client que um player acabou de carregar a cena de gamplay e pode comecar a jogar.
             * Define tambem se a partida deve comecar ou aguardar outros player carregar a partida.
             * {
             *  start : bool
             * }
             */ 
            public virtual void OnGameplayLoaded(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o player atual da cor que ele deverá usar para se representar
             * {
             *  color : string ("blue" | "red")
             * }
             */ 
            public virtual void OnColorSet(JSONObject payload)
            {
                // To be overriden
            }

            /**
             * Notifica o client de que um drone foi colocado
             * {
             *  x     : float,
             *  y     : float,
             *  z     : float ,  
             *  color : string
             * }
             */
            public virtual void OnDronePlace(JSONObject payload)
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
        }
    }
}
