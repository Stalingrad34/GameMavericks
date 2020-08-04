using UnityEngine;

public class GameBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private Material material = null;
    private Vector2 offset;

    void Start()
    {
        offset = material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        offset.y += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
