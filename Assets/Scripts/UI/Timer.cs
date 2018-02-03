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

        [SerializeField]
        private bool autoStart = false;

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
                StartCoroutine(IncrementTimer());
                started = true;
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

        public override void OnTick(JSONObject payload)
        {
            // Debug.Log("SV: "+ payload.GetField("t").n+", CL: "+elapsedSeconds);
            int sv = (int) payload.GetField("t").n;
            if(elapsedSeconds+1 < sv || elapsedSeconds-1 > sv)
            {
                elapsedSeconds = sv;
                field.text = Format();
                // Debug.Log("Rrumo!");

            }
        }
        #endregion
    }
}

