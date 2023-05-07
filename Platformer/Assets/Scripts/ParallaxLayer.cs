using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField]
    private Vector2 moveSpeedFactor;
    [SerializeField]
    private int textureWidthFactor; //3
    private Transform trCamera;
    private Vector2 cameraPos;
    private Vector2 lastCameraPos;
    private Vector2 cameraDeltaPos;
    private Vector2 textureHalfSize;
    private Vector3 deltaPos;
    void Start()
    {
        trCamera = Camera.main.transform;
        cameraPos = trCamera.position;
        lastCameraPos = cameraPos;

        var spriteRenderer = GetComponent<SpriteRenderer>();
        var sprite = spriteRenderer.sprite;
        textureHalfSize = new Vector2(sprite.texture.width / sprite.pixelsPerUnit / 2, sprite.texture.height / sprite.pixelsPerUnit / 2);
        spriteRenderer.size = new Vector2(textureHalfSize.x * 2 * textureWidthFactor, textureHalfSize.y * 2);
        transform.position = new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }

    void LateUpdate()
    {
        cameraPos = trCamera.position;
        cameraDeltaPos = cameraPos - lastCameraPos;
        deltaPos.x = cameraDeltaPos.x * moveSpeedFactor.x;
        deltaPos.y = cameraDeltaPos.y * moveSpeedFactor.y;
        var newPos = transform.position + deltaPos;
        lastCameraPos = cameraPos;

        if (cameraPos.x >= newPos.x+textureHalfSize.x)
        {
            newPos += new Vector3(textureHalfSize.x * 2, 0, 0);
        }
        else if(cameraPos.x <= newPos.x-textureHalfSize.x)
        {
            newPos -= new Vector3(textureHalfSize.x * 2, 0, 0);
        }
        transform.position = newPos;
    }
}
