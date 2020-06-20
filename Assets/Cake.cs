using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public float StartForceIntensity;
    public int NextCakeCount;
    public GameObject NextCake;

    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();

        var x = Random.Range(0.5f, 1.5f) * StartForceIntensity;
        if (Random.value > 0.5f)
            x *= -1;

        var y = Random.Range(0.5f, 1.5f) * StartForceIntensity;
        if (Random.value > 0.5f)
            y *= -1;

        var spin = Random.Range(-0.5f, 0.5f) * StartForceIntensity;

        _rb.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
        _rb.AddTorque(spin, ForceMode2D.Impulse);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            Split();
    }

    public void Split()
    {
        Debug.Log($"Split {gameObject.name}!");

        if(NextCake != null)
        {
            for(var i = 0; i < NextCakeCount; i++)
                Instantiate(NextCake, _rb.position, Quaternion.identity);
        }

        // do splatter...
        Destroy(gameObject);
    }
}
