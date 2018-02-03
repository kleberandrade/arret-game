using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

namespace ANET
{

    namespace Networking
    {

        public class GameMode
        {
            public static readonly uint VR = 0;
            public static readonly uint MOBILE = 1;
        }

        public class Networking : MonoBehaviour
        {
            #region Static Fields
            static private Networking _instance;
            #endregion

            #region Privates Fields
            private bool host = false;
            private SocketIOComponent io;
            public List<GameObject> networked = new List<GameObject> ();
            #endregion

            #region Public Properties
            static public Networking Instance
            {
                get
                {
                    return _instance;
                }
            }

            public bool Host
            {
                get
                {
                    return host;
                }
            }

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
            #endregion

            #region Unity Interface
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

            #region Public Interface
            public void Connect()
            {
                if (io)
                {
                    io.Connect();

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
                        }else if(action == "gameplayLoaded")
                        {
                            BroadcastAMessage("OnGameplayLoaded", payload);
                        }else if (action == "setColor")
                        {
                            BroadcastAMessage("OnColorSet", payload);
                        }else if(action == "placeDrone")
                        {
                            BroadcastAMessage("OnDronePlace", payload);
                        }
                    }));
                }
            }

            public void Register(GameObject go)
            {
                networked.Add(go);
                // Debug.Log(networked.Count);
            }

            public void BroadcastAMessage(string methodName,JSONObject payload)
            {
                bool vai = true;
                for (int i = 0; vai;)
                {
                    if(i > networked.Count)
                    {
                        vai = false;
                    }
                    else
                    {
                        GameObject go = networked[i];
                        // Debug.Log("Carai:" + go);
                        if (go)
                        {
                            // Debug.Log(go.GetComponent<INetworkBehaviour>().GetType()+", "+methodName);
                            go.BroadcastMessage(methodName, payload);
                            i++;
                        }
                        else
                        {
                            networked.RemoveAt(i);
                        }
                    }
                    
                }
            }

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

            public void GameplaySceneLoaded()
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "gameplayLoaded");

                io.Emit("action",payload);
            }

            public void PlaceDrone(Vector3 position)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "placeDrone");

                payload.AddField("x", position.x);
                payload.AddField("y", position.y);
                payload.AddField("z", position.z);

                io.Emit("action", payload);
            }
            #endregion


        }
    }
}

