using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRotation : MonoBehaviour
{
    float scrollSpeed = 3.0f;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    void Update()
    {
        var offset = Time.time * scrollSpeed * Input.GetAxisRaw("Vertical");
        
        #region SetTextureOffset: Material(재질)에 적용된 Texture(텍스처)의 위치를 조절하는 함수
        meshRenderer.material.SetTextureOffset("_MainTex"/*Diffuse종류*/, new Vector2(0, offset));  //기본텍스처의 Y offset값 변경
        meshRenderer.material.SetTextureOffset("_BumpMap"/*노멀맵종류*/, new Vector2(0, offset));   //노멀텍스처의 Y offset값 변경
        #endregion
    }
}
