using UnityEngine;
using UnityEngine.UI;

public class HeliController : MonoBehaviour
{
    Rigidbody rb;
    public int coinTotal;
    float timer,time;
    float smooth = 2.5f;
    public float speed = 400f;
    public Slider GasSlider;
    public ParticleSystem explosion;
    public AudioSource explosionSound;
    public AudioSource gasSound;
    public AudioSource coinSound;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        GasSlider = GameObject.Find("GasBar").GetComponent<Slider>();
        explosion = GameObject.Find("ExplosionParticles").GetComponent<ParticleSystem>();
        coinSound = GameObject.Find("coinSound").GetComponent<AudioSource>();
        gasSound = GameObject.Find("gasSound").GetComponent<AudioSource>();
        explosionSound = GameObject.Find("ExplosionSound").GetComponent<AudioSource>();

        time = 1;
        timer = 10;
        GasSlider.value = 10;
        GasSlider.maxValue = 10;
	}

	void FixedUpdate () {

        timer -= time * Time.deltaTime;
        GasSlider.value = timer;

        if (transform.position.y < -30.5 || transform.position.y > 50 || GasSlider.value == 0)
            Explode();

        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);

            if (time == 1)
                time = 1.5f;

            Quaternion target = Quaternion.Euler(0f, 0f, 30f);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    rb.velocity = new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);
                    break;
                case TouchPhase.Stationary:
                    rb.velocity = new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);
                    break;

                case TouchPhase.Ended:
                    if (speed > 0)
                        speed -= 2 * Time.deltaTime;
                    
                    target = Quaternion.Euler(0f, 0f, 0f);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);

                    if (time == 1.5f)
                        time = 1;
                    break;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (time == 1)
                time = 1.5f;

            rb.AddForce(new Vector3(0,1,0) * 50f);
            //rb.velocity = new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
            Quaternion target = Quaternion.Euler(0f, 0f, 15f);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);
        }
        else
        {
            rb.AddForce(new Vector3(0, -1, 0) * 15f);
            if (time == 1.5f)
                time = 1;
            Quaternion target = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);
        }
    }

    public void PickupCoin()
    {
        int money = PlayerPrefs.GetInt("TotalCoins");
        money += 1;
        PlayerPrefs.SetInt("TotalCoins", money);
        PlayerPrefs.Save();

        Handheld.Vibrate();

        // trigger audio playback and emit particles from particle system
        coinSound.Play();
    }

    public void PickupGas()
    {
        timer = 10;
        Handheld.Vibrate();
        gasSound.Play();
    }

    public void Explode()
    {
        explosionSound.Play();
        Handheld.Vibrate();

        // set explosion position to helicopter's and emit
        explosion.transform.position = transform.position;
        explosion.Play();

        //Destroy(GameObject.Find("Player"));
        Destroy(gameObject);
    }
}
