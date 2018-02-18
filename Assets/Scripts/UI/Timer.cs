using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

using ANET.Networking;

namespace ARRET
{
    public class Timer : INetworkBehaviour
    {

        #region Private Fields
        private int elapsedSeconds;
        private Text field = null;
        private bool started = false;
        private Coroutine routine = null;

        [SerializeField]
        [Tooltip("Defines if Timer must start automatically or not. Leave unckhed so it will be initialized by OnMatchStart Event (network).")]
        private bool autoStart = false;
        [SerializeField]
        [Tooltip("Difference between the server match time and the client match time allowed. If the client time is lower than server's or higher than server's by this amount, Timer will reconciliate its time.")]
        private int reconciliationThreshold = 1;

        #endregion

        #region Public Property
        public int ElapsedSeconds
        {
            get
            {
                return elapsedSeconds;
            }

            set
            {
                elapsedSeconds = value;
                field.text = Format();
            }
        }

        public Text Field
        {
            get
            {
                return field;
            }
        }
        #endregion

        public override void Start()
        {
            base.Start();
            field = GetComponent<Text>();
            if(autoStart)
                TimerStart();
        }

        IEnumerator IncrementTimer()
        {
            while(true){
                yield return new WaitForSeconds(1);
                Debug.Log("ClientTick");
                if(elapsedSeconds % 15 == 0)
                {
                    if (Networking.Instance)
                        Networking.Instance.Tick();
                }
                elapsedSeconds++;
                field.text = Format();
            }
        }

        #region Public Methods
        public void TimerStart()
        {
            // Debug.Log("TimerStart");
            if (!started)
            {
                routine = StartCoroutine(IncrementTimer());
                started = true;
            }
        }

        public void TimerStop()
        {
            if (started)
            {
                StopCoroutine(routine);
                started = false;
            }
        }

        public string Format()
        {
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;

            string mm = (minutes < 10 ? "0" + minutes.ToString() : minutes.ToString());
            string ss = (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
            return String.Format("{0}:{1}", mm, ss);
        }
        #endregion

        #region Network Events
        public override void OnMatchStarted()
        {
            TimerStart();
        }

        public override void OnGameOver(JSONObject payload)
        {
            TimerStop();
        }

        public override void OnTick(JSONObject payload)
        {
            // Debug.Log("SV: "+ payload.GetField("t").n+", CL: "+elapsedSeconds);
            int sv = (int) payload.GetField("t").n;
            if(elapsedSeconds + reconciliationThreshold < sv || elapsedSeconds - reconciliationThreshold > sv)
            {
                elapsedSeconds = sv;
                field.text = Format();
                // Debug.Log("Rrumo!");

            }
        }
        #endregion
    }
}

