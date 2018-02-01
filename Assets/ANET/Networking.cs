using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

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
            [SerializeField]
            private SocketIOComponent io = null;
            #endregion

            #region Public Properties
            static public Networking Instance
            {
                get
                {
                    return _instance;
                }
            }
            #endregion

            #region Unity Interface
            private void Awake()
            {
                _instance = this;
            }

            private void Start()
            {
                Instance.Connect();
            }
            #endregion

            #region Public Interface
            public void Connect()
            {
                if (io)
                {
                    io.Connect();
                }
            }

            public void Play(uint gameMode)
            {
                JSONObject payload = new JSONObject();
                payload.AddField("action", "makematch");

                if(gameMode == GameMode.MOBILE)
                {
                    payload.AddField("type", "mobile");
                    io.Emit("action",payload);
                }else if(gameMode == GameMode.VR)
                {
                    payload.AddField("type", "vr");
                    io.Emit("action",payload);
                }
                
            }
            #endregion


        }
    }
}

