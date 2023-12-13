using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    /// <summary>
    /// Non mi piace serve a michele meglio privato
    /// </summary>
    public StatesMachine<FlowGameManger> StateMachine;

    private MuseumGuide _museumGuide;
    public MuseumGuide MuseumGuide { get => _museumGuide; }

   [HideInInspector] public UIManager UIManager;
   

    #region States
    public OnNavigationState OnNavigationState;
    public OnDialogueState OnDialogueState;
    public OnPauseState OnPauseState;
    #endregion

    public bool debugger;
    private void Awake()
    {
        InitStateMachine();
        _museumGuide = FindObjectOfType<MuseumGuide>();
        UIManager = FindObjectOfType<UIManager>();
    }

    private void OnEnable()
    {
        UIManager.PauseButton.onClick.AddListener(PauseState);
        UIManager.Game.onClick.AddListener(BackToGame);
    }


    private void Update()
    {
        if (debugger)
        {
            StateMachine.ChangeState(OnDialogueState);
            debugger = false;
        }
        StateMachine.CurrentState.OnUpdate(this);
    }

    private void InitStateMachine()
    {
        StateMachine = new StatesMachine<FlowGameManger>(this);
        OnNavigationState = new OnNavigationState("OnNavigationState", StateMachine);
        OnDialogueState = new OnDialogueState("OnDialogueState", StateMachine);
        OnPauseState = new OnPauseState("OnPauseState", StateMachine);
        StateMachine.RunStateMachine(OnNavigationState);
    }


    public void PauseState() => StateMachine.ChangeState(OnPauseState);
    public void BackToGame() => StateMachine.ChangeState(OnNavigationState);


}
