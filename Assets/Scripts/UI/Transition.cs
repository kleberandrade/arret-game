using UnityEngine;

public static class Transition
{
    public static void LoadScene (string scene, Color color, float damp)
    {
		GameObject go = new GameObject ("Fader");

        Fader fader = go.AddComponent<Fader> ();
		fader.m_FadeDamp = damp;
		fader.m_FadeScene = scene;
		fader.m_FadeColor = color;
		fader.m_Start = true;
	}
}
