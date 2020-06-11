using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPanel : MonoBehaviour {
    public Camera camera;
    public RawImage playerImage;
    private RenderTexture renderTexture;

	void OnEnable () {
        renderTexture = RenderTexture.GetTemporary(256,256);
        camera.targetTexture = renderTexture;
        playerImage.texture = renderTexture;
    }

    void OnDisable()
    {
        renderTexture.Release();
    }
}
