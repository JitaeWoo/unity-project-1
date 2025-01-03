using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private Slider _hpUI;
    private PlayerController _playerController;
    public GameObject shot;
    private GameObject curShot;


    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
        curShot = null;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 1f, LayerMask.GetMask("Enemy"));
            if(hit.collider != null)
            {
                Debug.Log("I layer!!");
                if(GameObject.FindWithTag("Shot") != null){

                }else{
                    curShot = Instantiate(shot, hit.transform.position, Quaternion.identity);
                    curShot.GetComponent<Shot>().enemy = hit.transform.gameObject;
                    curShot.GetComponent<Shot>().playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().damage;
                }
            }
        }*/
    }

    private void InitializePlayer()
    {
        _playerController = Instantiate(playerPrefab);

        PlayerBaseStats baseStats = ScriptableObject.CreateInstance<PlayerBaseStats>();
        PlayerStats stats = new PlayerStats(baseStats);
        PlayerHealth hp = new PlayerHealth(stats.MaxHealth);
        PlayerHealthUI hpUI = new PlayerHealthUI(_hpUI);
        PlayerMovement movement = new PlayerMovement(_playerController.transform);
        PlayerInputHandler inputHandler = new PlayerInputHandler();
        PlayerDamageHandler damageHandler = new PlayerDamageHandler(hp, hpUI);
        PlayerInvincibilityManager invincibilityManager = new PlayerInvincibilityManager(_playerController, 0.5f);

        _playerController.Initialize(stats, hp, hpUI, movement, inputHandler, damageHandler, invincibilityManager);
    }
}
