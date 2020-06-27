using UnityEngine;

public class Cake : MonoBehaviour
{
    private static int cakeCount = 0;   // is this ok with monobehaviour, how do threads work with unity/monobehaviour/hit detection??

    public float StartForceIntensity;
    public int NextCakeCount;
    public GameObject NextCake;

    public GameObject Splat;

    private Rigidbody2D _rb;
    private GameObject _splatFolder;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _splatFolder = GameObject.FindWithTag("SplatFolder");

        var x = Random.Range(0.5f, 1.5f) * StartForceIntensity;
        if (Random.value > 0.5f)
            x *= -1;

        var y = Random.Range(0.5f, 1.5f) * StartForceIntensity;
        if (Random.value > 0.5f)
            y *= -1;

        //var spin = Random.Range(-0.5f, 0.5f) * StartForceIntensity;

        _rb.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
        //_rb.AddTorque(spin, ForceMode2D.Impulse);

        cakeCount++;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            Split();
    }

    public void Split()
    {
        Debug.Log($"Split {gameObject.name}!");

        if (NextCake != null)
        {
//            var camShake = FindObjectOfType<CameraShake>();
//            StartCoroutine(camShake.Shake(1f, .4f));

            // next 'level'
            for(var i = 0; i < NextCakeCount; i++)
                Instantiate(NextCake, _rb.position, Quaternion.identity);

//            FindObjectOfType<AudioManager>()?.ScalePitch("theme", 1.5f);
        }
        else
        {
            // no more levels - are we the last cake - for the win?
            if (cakeCount == 1)
            {
                Debug.Log("WIN!!");
                FindObjectOfType<GameControl>().Win();
            }
                
        }

        // do splatter...
        var splat = Instantiate(Splat, new Vector3(_rb.position.x, _rb.position.y, 2), _rb.transform.rotation, _splatFolder.transform);
        //splat.transform.localScale = Vector3.Scale(_rb.transform.localScale, new Vector3(3, 3, 0));
        cakeCount--;
        Destroy(gameObject);
    }
}
