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
            private string color = "";
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
            public void Connect()
            {
                if (io)
                {
                    io.Connect();

                    io.On("disconnect", new Action<SocketIOEvent>((SocketIOEvent evt) => {
                        BroadcastAMessage("OnServerDisconection", null);
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
                        }else if(action == "tick")
                        {
                            BroadcastAMessage("OnTick", payload);
                        }else if(action == "destroyDrone")
                        {
                            BroadcastAMessage("OnDroneDestroy", payload);
                        }
                    }));
                }
            }

            public void Register(GameObject go)
            {
                if(!networked.Contains(go))
                    networked.Add(go);
                // Debug.Log(networked.Count);
            }

            public void BroadcastAMessage(string methodName,JSONObject payload)
            {
                networked.RemoveAll((GameObject item) => {
                   return item == null;
                });

                foreach(GameObject go in networked)
                {
                    
                    if (payload != null)
                    {
                        go.SendMessage(methodName, payload);
                    }
                    else
                    {
                        go.SendMessage(methodName);
                    }
                    //Debug.Log(methodName+", "+go.name);
                }
                // Debug.Log("-------------------");

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

            public void Tick()
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "tick");

                io.Emit("action",payload);
            }

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
            #endregion


        }
    }
}

