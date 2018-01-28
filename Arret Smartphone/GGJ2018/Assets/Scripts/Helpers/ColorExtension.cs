using UnityEngine;

public static class ColorExtension {

	public static Color AlphaColor(Color color, float alpha)
	{
		return new Color (color.r, color.g, color.b, alpha);
	}
}
