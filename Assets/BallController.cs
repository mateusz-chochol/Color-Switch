using UnityEngine;

public class BallController : MonoBehaviour {

    public Rigidbody2D rb;
    public float force;
    public Camera cam;

    Vector2 forceVector;
    SpriteRenderer spriteRenderer;

	void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        forceVector = new Vector2(0f, force);
        rb.isKinematic = true;
        ChooseColour();
	}
	
    void ChooseColour() {

        switch ((int)Random.Range(1.0f, 4.99f))
        {
            case 1:
                spriteRenderer.color = new Color(1f, 252 / 255f, 38f / 255f, 1f);
                break;
            case 2:
                spriteRenderer.color = new Color(129f / 255f, 39f / 255f, 1f, 1f);
                break;
            case 3:
                spriteRenderer.color = new Color(1f, 39f / 255f, 206f / 255f, 1f);
                break;
            case 4:
                spriteRenderer.color = new Color(38f / 255f, 252f / 255f, 1f, 1f);
                break;
        }
    }

	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            if(rb.isKinematic)
            {
                rb.isKinematic = false;
            }

            rb.velocity = new Vector2 (0f, 0f);
            rb.AddForce(forceVector);

        }

        if (transform.position.y >= cam.transform.position.y && rb.velocity.y >= 0f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag != "CheckPoint")
        {
            if (collision.GetComponent<SpriteRenderer>().color.ToString() != spriteRenderer.color.ToString())
            {
                Debug.Log("GameOver");
            }
        }
        else
            ChooseColour();
    }
}
