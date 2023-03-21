using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public enum BossPhase
{
    First,
    Second,
    Third,
    NoAttack
}
public enum BossState
{
    Idle,
    Attack,
    Death,
    NoState

}

public class BossManager : MonoBehaviour, IDamageable
{

    public static BossManager BM;
    
    
    [SerializeField] private Transform pieceOriginPos;
    [SerializeField] private GameObject[] chessPiece;
    [SerializeField] private GameObject missileTarget;
    [SerializeField] private Transform player2;
    [SerializeField] private GameObject missile;
    [SerializeField] private Animator missileAnim;
    [SerializeField] private GameObject queen;
    public TriggerCutscenes t_Cutscene;
    public GameObject UIturnOff;
    public Animator anim;
    public Slider healthUI;
    [SerializeField]
    private Canvas bossUI;
    [SerializeField] private Transform[] tiles;
    

    public bool bossActive = false;
    
    
    [SerializeField]
    private Material orange;
    [SerializeField]
    private Material red;
    
    private GameObject currentPiece;
    private int index;
    private int tileIndex;
    public int attackCount = 0;
    
    
    public BossState _state;
    public BossPhase _phase;
    
    private GameObject currentAttack;
    
    //Variables
    public float spawnTime = 5f;
    [Header("How Fast the pieces will attack after spawning")]
    public float attackTime = 3f;
    
    //Health 
    public float Health { get; set; }
    
    public int _health = 1;

    [SerializeField] private float missileTargetSpeed = 0.7f;
    private float currentMissileTargetSpeed;

    private bool isAttacking = false;
    private bool missileSearching = false;
    private bool missileAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        BM = this;
        
        Health = _health;
        //_state = BossState.Idle;
        _state = BossState.Idle;
        _phase = BossPhase.First;

        index = Random.Range(0, chessPiece.Length);
        currentPiece = chessPiece[index];
        currentMissileTargetSpeed = missileTargetSpeed;
        missileTarget.GetComponent<MeshRenderer>().material = orange;
        
        bossUI.enabled = false;

        //bossActive = true;
    }

    void UI()
    {
        healthUI.value = _health;
    }
    public void Damage()
    {
        anim.SetTrigger("Hurt");
        _health--;
    }

    void Phase1States()
    {
        switch (_state)
        {
            case
                BossState.Idle:
            {
                    
                    StartCoroutine(Idle());
                break;
            }
            case 
                BossState.Attack:
            {
                if (!isAttacking)
                {
                    Attack();
                        anim.SetTrigger("Spawning");
                }
                break;
            }
            case 
                BossState.Death:
            {
                Death();
                break;
            }
        }
    }

    void HealthStates()
    {
        _phase = _health switch
        {
            >= 20 => BossPhase.First,
            >= 15 => BossPhase.Second,
            _ => BossPhase.Third
        };

        if (_health <= 0)
        {
            _state = BossState.Death;
        }
    }

    void Phase2States()
    {
        StartCoroutine(MissileSearch());
    }

    IEnumerator StartNextPhase()
    {
        yield return new WaitForSeconds(3f);
        _phase = BossPhase.Second;
        
        currentMissileTargetSpeed = missileTargetSpeed;
        missileSearching = false;
        missileAttacking = false;
        missileTarget.GetComponent<MeshRenderer>().material = orange;
    }

    IEnumerator Idle()
    {

        yield return new WaitForSeconds(spawnTime);
        _state = BossState.Attack;
        

    }

    IEnumerator MissileSearch()
    {
        missileSearching = true;
        
        missileTarget.SetActive(true);
        missileTarget.transform.position =
            Vector3.Lerp(missileTarget.transform.position,
                new Vector3(player2.transform.position.x, missileTarget.transform.position.y, player2.transform.position.z),
                currentMissileTargetSpeed * Time.deltaTime);

        yield return new WaitForSeconds(10f);
        //missileAnim.Play("Shoot");
        print("MissileAttack");
        currentMissileTargetSpeed = 0;
        //missileSearching = false;
        if (!missileAttacking)
        {
            MissileAttack();
        }
        
    }

    void MissileAttack()
    {
        missileSearching = false;
        missileAttacking = true;
        missileTarget.GetComponent<MeshRenderer>().material = red;
        Instantiate(missile, 
            new Vector3(missileTarget.transform.position.x, 20, missileTarget.transform.position.z), Quaternion.identity);
        
    }
    
    IEnumerator NextWave()
    {
        //missileAnim.Play("State");
        yield return new WaitForSeconds(15f);
        _phase = BossPhase.First;
        attackCount = 0;

    }

    void Attack()
    {
        isAttacking = true;
        
        spawnTime = Random.Range(3, 6);
        StopAllCoroutines();

        switch (_phase)
        {
            //Piece Randomizer

            case BossPhase.First:
                StartCoroutine(TwoRandomPieceSpawner());
                break;
            case BossPhase.Second:
                StartCoroutine(ThreeRandomPieceSpawner());
                break;
            case BossPhase.Third:
                StartCoroutine(FiveRandomPieceSpawner());
                break;
        }
        

    }
    
    IEnumerator FiveRandomPieceSpawner()
    {
        index = Random.Range(0, chessPiece.Length);
        tileIndex = Random.Range(0, tiles.Length);
        int tileIndexTwo = Random.Range(0, tiles.Length);
        while (tileIndexTwo == tileIndex)
        {
            yield return tileIndexTwo = Random.Range(0, tiles.Length);
        }
        int tileIndexThree = Random.Range(0, tiles.Length);
        while (tileIndexThree == tileIndexTwo || tileIndexThree == tileIndex)
        {
            yield return tileIndexThree = Random.Range(0, tiles.Length);
        }
        int tileIndexFour = Random.Range(0, tiles.Length);
        while (tileIndexFour == tileIndexTwo || tileIndexFour == tileIndex || tileIndexFour == tileIndexThree)
        {
            yield return tileIndexFour = Random.Range(0, tiles.Length);
        }
        int tileIndexFive = Random.Range(0, tiles.Length);
        while (tileIndexFive == tileIndexTwo || tileIndexFive == tileIndex || tileIndexFive == tileIndexThree || tileIndexFive == tileIndexFour)
        {
            yield return tileIndexFive = Random.Range(0, tiles.Length);
        }
        
        currentPiece = chessPiece[index];
        
        print(tileIndex + " " + tileIndexTwo +  " " + tileIndexThree +  " " + tileIndexFour + " " + tileIndexFive);
        yield return new WaitForSeconds(attackTime);
        
        //Instantiate piece 2
        SpawnPiece(currentPiece, tiles[tileIndexTwo]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 1
        SpawnPiece(currentPiece, tiles[tileIndex]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 3
        SpawnPiece(currentPiece, tiles[tileIndexThree]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 4 
        SpawnPiece(currentPiece, tiles[tileIndexFour]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 5 
        SpawnPiece(currentPiece, tiles[tileIndexFive]);
        
        Attacking();
    }
    
    
    IEnumerator ThreeRandomPieceSpawner()
    {
        index = Random.Range(0, chessPiece.Length);
        tileIndex = Random.Range(0, tiles.Length);
        int tileIndexTwo = Random.Range(0, tiles.Length);
        while (tileIndexTwo == tileIndex)
        {
            yield return tileIndexTwo = Random.Range(0, tiles.Length);
        }
        int tileIndexThree = Random.Range(0, tiles.Length);
        while (tileIndexThree == tileIndexTwo || tileIndexThree == tileIndex)
        {
            yield return tileIndexThree = Random.Range(0, tiles.Length);
        }
        
        currentPiece = chessPiece[index];
        
        yield return new WaitForSeconds(attackTime);
        
        //Instantiate piece 2
        SpawnPiece(currentPiece, tiles[tileIndexTwo]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 1
        SpawnPiece(currentPiece, tiles[tileIndex]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 3
        SpawnPiece(currentPiece, tiles[tileIndexThree]);
        

        Attacking();
    }
    
    IEnumerator TwoRandomPieceSpawner()
    {
        index = Random.Range(0, chessPiece.Length);
        tileIndex = Random.Range(0, tiles.Length);
        int tileIndexTwo = Random.Range(0, tiles.Length);
        while (tileIndexTwo == tileIndex)
        {
            yield return tileIndexTwo = Random.Range(0, tiles.Length);
        }
        
        currentPiece = chessPiece[index];
        
        yield return new WaitForSeconds(attackTime);
        
        //Instantiate piece 2
        SpawnPiece(currentPiece, tiles[tileIndexTwo]);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 1
        SpawnPiece(currentPiece, tiles[tileIndex]);

        Attacking();
    }
    
    IEnumerator ThreeRookSpawner()
    {
        index = Random.Range(0, chessPiece.Length);
        tileIndex = Random.Range(1, tiles.Length - 1);
        int tileIndexTwo = Random.Range(0, tileIndex - 1);
        int tileIndexThree = Random.Range(tileIndex + 1, tiles.Length);
        currentPiece = chessPiece[0];

        yield return new WaitForSeconds(attackTime);
        
        //Instantiate piece 2
        currentAttack = Instantiate(currentPiece, 
            new Vector3(tiles[tileIndexTwo].transform.position.x, 
                tiles[tileIndexTwo].transform.position.y + 15f,
                tiles[tileIndexTwo].transform.position.z), 
            currentPiece.transform.rotation);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 1
        currentAttack = Instantiate(currentPiece, 
            new Vector3(tiles[tileIndex].transform.position.x, 
                tiles[tileIndex].transform.position.y + 15f,
                tiles[tileIndex].transform.position.z), 
            currentPiece.transform.rotation);
        
        yield return new WaitForSeconds(0.3f);
        //Piece 3
        currentAttack = Instantiate(currentPiece, 
            new Vector3(tiles[tileIndexThree].transform.position.x, 
                tiles[tileIndexThree].transform.position.y + 15f,
                tiles[tileIndexThree].transform.position.z), 
            currentPiece.transform.rotation);
        
        Attacking();
    }

    void SpawnPiece(GameObject piece, Transform pos)
    {
        currentAttack = Instantiate(piece, 
            new Vector3(pos.transform.position.x, 
                pos.transform.position.y + 15f,
                    pos.transform.position.z), 
                        piece.transform.rotation);
    }

    void Attacking()
    {
        attackCount++;
        isAttacking = false;
        _state = BossState.Idle;
        
    }

    void Death()
    {
        anim.SetBool("Death", true);
        healthUI.enabled = false;
        bossUI.enabled = false;
        UIturnOff.SetActive(false);
        t_Cutscene.sendInfo();
        Invoke("returnToMain", 28.0f);



    }

    void BossDamage()
    {
        
    }

    public void returnToMain()
    {
       
        SceneManager.LoadScene("Main menu");
        
    }




    void Update()
    {
        if (bossActive)
        {
                bossUI.enabled = true;
                missileTarget.SetActive(false);
                Phase1States();

        }
        
        if (_health <= 0)
        {
            _state = BossState.Death;
        }
        HealthStates();
        UI();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossActive = true;
        }
        
    }


}
