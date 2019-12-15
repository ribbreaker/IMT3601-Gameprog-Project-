using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.SceneManagement;

public class playerController : entity
{
    public int MAXLEVELS = 12;
    public int mapPosition = 1;
    bool isDamaged;
    float flashTimer;
    public float pushBackSpeed;
    public float pushBackForce;
    private playerStats stats;
    Animator animator;
    public Vector3 checkpoint;
    private GameObject spawnTarget;
    public GameObject transition;
    public Scene respawnScene;
    public string sceneName;
    public bool[] levelsBeaten;
    public bool resurrected;
    public bool goneThroughGoldDoor;
    public bool imDead;
    public bool fadingOut;
    bool gameoverMenuLoaded;


    Renderer rend;
    Color colorStart;


    [SerializeField]
    private AbstractState _currentState;
    [SerializeField]
    private List<AbstractState> _availableStates;

    public void SendAnimationMessage(string eventID){
        var animator = GetComponent<Animator>();
        var animationMessage = new AnimationMessage(animator, eventID);
        _currentState.SendMessage(animationMessage);
    }

    public AbstractState CurrentState {get {return _currentState;}}

    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_TopCheck;

    //Radius overlap circle to determine if grounded
    const float k_GroundedRadius = .2f;
    //Whether or not the player is grounded
    public bool m_Grounded;
    private Rigidbody2D m_Rigidbody2D;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
    public UnityEvent CrushEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool>{}


    
    void Awake()
    {
        //Make it persistent
        DontDestroyOnLoad(this.gameObject);

        animator = GetComponent<Animator>();
        stats = GetComponent<playerStats>();

        rend = GetComponent<Renderer>();
        colorStart = rend.material.color;

        CacheAllStates();
        _currentState = GetComponentInChildren<IdleState>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if(OnLandEvent == null)
            OnLandEvent = new UnityEvent();
        if(CrushEvent == null)
            CrushEvent = new UnityEvent();
    }
    void Start() {
        checkpoint = transform.position;

    }

    private void CacheAllStates(){
        _availableStates = GetComponentsInChildren<AbstractState>(true).ToList();
    }

    #region API
    public TState FindAvailableState<TState>()
        where TState : AbstractState{
        foreach(var availableState in _availableStates){
            if(availableState.GetType() == typeof(TState)){
                return availableState as TState;
            }
        }
        return null;
    }

    public void ChangeState(AbstractState newState){
        if(_currentState == newState)
            return;
        
        _currentState.Exit();
        _currentState = newState;
        newState.Enter();
    }
#endregion API

    // Update is called once per frame
    private void Update()
    {
        //if he's dead do the dead guy stuff
        if (imDead){
            deadState();
        }

        //if he's gone through the door, unlock that shit!
        if (goneThroughGoldDoor){
            unlockIsland5();
            //just so it stops invoking the method.
            goneThroughGoldDoor = false;
        }
        transition = GameObject.FindGameObjectWithTag("Transition");
        //resurect the player by going out of the dead state and respawning.
        if (resurrected){
            Debug.Log("player is resurrected");
            animator.SetBool("dead", false);
            respawn();
        }
        //Keep the player persistent
        DontDestroyOnLoad(this.gameObject);
        //set the first checkpoint to be the spawntarget.
        spawnTarget = GameObject.FindGameObjectWithTag("SpawnTarget");
        if(spawnTarget != null){
            checkpoint = spawnTarget.transform.position;
        }
        if (!animator.GetBool("dead")) {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            //The player is grounded if the circlecast to the groundcheck
            //position hits anything designated as ground

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++) {
                if (colliders[i].gameObject != gameObject) {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
            Collider2D[] topColliders = Physics2D.OverlapCircleAll(m_TopCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < topColliders.Length; i++) {
                if (topColliders[i].gameObject != gameObject) {
                    if (wasGrounded) {
                        CrushEvent.Invoke();
                        // death();
                        // gameObject.SetActive(false);
                    }
                }
            }

            flashTimer += Time.deltaTime;

            Color colorEnd = Color.green;

            if (isDamaged) {
                colorEnd.a = 0;
                //rapidly switch between "colors" when damaged
                if (rend.material.color == colorStart)
                    rend.material.color = colorEnd;
                else if (rend.material.color == colorEnd)
                    rend.material.color = colorStart;
            }
            else {
                rend.material.color = colorStart;
            }

            //resets the invincibility time
            if (flashTimer >= 2) {
                isDamaged = false;
                flashTimer = 0;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {

        if (other.gameObject.CompareTag("Danger") && !isDamaged) {
            stats.takeDamage(99);
        }
        if (other.gameObject.CompareTag("Enemy") && !isDamaged) {
            var enemyDamage = other.gameObject.GetComponent<EnemyController>().DealDamage();
            damageRecoil(other);
            stats.takeDamage(enemyDamage);
        }
    }


    //This function only runs for one frame due to it being connected to OnTriggerStay2D, therefore it will only push the player a little
    //FIX THIS by having a clock. (maybe not even have it at all idk)
    private void damageRecoil(Collider2D other) {
        flashTimer = 0;
        isDamaged = true;
        Vector3 targetPosition;

        //push him back
        if (other.transform.position.x > transform.position.x) {
            targetPosition = new Vector3(transform.position.x - pushBackForce, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, pushBackSpeed);
        }
        else {
            targetPosition = new Vector3(transform.position.x + pushBackForce, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, pushBackSpeed);
        }
    }

    //come back!
    void respawn(){
        //reset HP and lives
        while (stats.GetHP() < stats.GetMaxHP())
        {
            stats.IncreaseHP();
        }
        //sets the orbs to be whatever you had at the previous checkpoint. Then move there. The deadstate handles the rest
        stats.DeadOrbReset();
        GetComponent<SpriteRenderer>().enabled = true;

        //this works because the player is persistent, their data will remain intact unless it's required that they lose something. 
        //The transitioner's ScriptsON resets to whatever it was at the time.
        resurrected = false;
    }
    void unlockIsland5(){
        levelsBeaten[3] = true;
    }

    //the player hath died. What a horrible fate.
    void deadState(){

        if (!gameoverMenuLoaded){
            //Fade away...
            if (fadingOut){
                transition.GetComponent<LevelTransition>().ScriptsON = true;
                //transition back to this level
                transition.GetComponent<LevelTransition>().reload = true;
                transition.GetComponent<LevelTransition>().fading = true;
                transition.GetComponent<LevelTransition>().next = false;
                fadingOut = false;
            }

            //the screen is black
            if (transition.GetComponent<LevelTransition>().loading){
                Debug.Log("It's loading, chief!!");
                //If there's no more lives show the gameover menu
                if (GetComponent<playerStats>().GetLives() <= 0)
                {
                    Debug.Log("No more lives, chief!");

                    //// Dead for good
                    // Loads the menu
                    //Currently does not take player out of deadstate, due to not finding the player in question
                    //Currently does not show up mid-fade, but rather starts post-fade(perhaps actually mid-fade) but it does not freeze said fade in this case
                    SceneManager.LoadSceneAsync("GameoverMenu", LoadSceneMode.Additive);
                    gameoverMenuLoaded = true;
                    //reset HP and lives
                    while (stats.GetLives() < stats.GetMaxLives()){
                        stats.IncreaseLives();
                    }
                }
                else{
                    //else just respawn
                    Debug.Log("There's more lives to spare!");
                    transition.GetComponent<LevelTransition>().loading = false;
                    //resurrect that bitch
                    resurrected = true;
                }
            }
        }
    }
}
