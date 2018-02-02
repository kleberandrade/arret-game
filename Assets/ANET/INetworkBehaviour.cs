using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ANET
{
    namespace Networking
    {
        public class INetworkBehaviour : MonoBehaviour
        {

            void Start()
            {
                // Debug.Log(this is INetworkBehaviour);
                Networking.Instance.Register(gameObject);
            }

            public virtual void OnConnected()
            {

            }

            /**
             * { 
             * 	action: 'joinRoom',
             * 	payload: { 
             * 		newuser: true,
             * 		totalusers: 1,
             * 		startgame: false,
             * 		host: true,
             * 		action: 'joinRoom' 
             *  } 
             * }
             */
            public virtual void OnJoinRoom(JSONObject payload)
            {
                // To be overriden
            }

            public virtual void OnGameAbort(JSONObject payload)
            {
                // To be overriden
            }

        }
    }
}
