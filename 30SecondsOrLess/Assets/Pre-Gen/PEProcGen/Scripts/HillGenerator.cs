using UnityEngine;
using System.Collections;

public class HillGenerator : BaseGenerator {
	public float heightScale = 1.0F;
	public float xScale = 1.0F;
	public float yNoise = 0f;
	public float yOffset = 0f;

	public AnimationCurve contourCurve = AnimationCurve.Linear (0f, 0f, 1f, 1f);


	public void GenerateMap(){
		for(int y=0;y<MapHeight;y++){
			for(int x=0;x<MapWidth;x++){
				float xf = (float)x/(float)(MapWidth-1);
				float yf = (float)(y - yOffset)/(float)(MapHeight-1);
				float height = contourCurve.Evaluate(xf) * heightScale * Mathf.PerlinNoise(xf * xScale, yNoise);
				if(yf>height) CurrentMap[x,y] = 0;
			}
		}
	}

	public void Append(){
		GenerateMap();
		if(renderImmediate) Render ();
	}

	public void Generate () {
		for(int y=0;y<MapHeight;y++){
			for(int x=0;x<MapWidth;x++){
				CurrentMap[x,y] = 1;
			}
		}
		GenerateMap();
		if(renderImmediate) Render ();
	}

}
