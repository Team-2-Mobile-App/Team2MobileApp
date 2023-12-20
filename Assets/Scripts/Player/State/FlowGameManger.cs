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
    public OnGalleryState OnGalleryState;
    public OnAccountState OnAccountState;
    public OnLoginState OnLoginState;
    #endregion


    private void Awake()
    {
        _museumGuide = FindObjectOfType<MuseumGuide>();
        UIManager = FindObjectOfType<UIManager>();
        InitStateMachine();
    }

    private void OnEnable()
    {
        UIManager.PauseButton.onClick.AddListener(PauseState);
        UIManager.Game.onClick.AddListener(BackToGame);
        UIManager.Gallery.onClick.AddListener(GoToGallery);
        UIManager.Map.onClick.AddListener(GoToMap);
        UIManager.closeButton.onClick.AddListener(UIManager.CloseOperaView);
        UIManager.Account.onClick.AddListener(GoToAccount);
    }


    private void Update()
    {
        StateMachine.CurrentState.OnUpdate(this);
    }

    private void InitStateMachine()
    {
        StateMachine = new StatesMachine<FlowGameManger>(this);
        OnNavigationState = new OnNavigationState("OnNavigationState", StateMachine);
        OnDialogueState = new OnDialogueState("OnDialogueState", StateMachine);
        OnPauseState = new OnPauseState("OnPauseState", StateMachine);
        OnGalleryState = new OnGalleryState("OnGalleryState", StateMachine);
        OnAccountState = new OnAccountState("OnAccountState", StateMachine);
        OnLoginState = new OnLoginState("OnLoginState", StateMachine);
        if (!GameManager.Instance.isLoginActive) StateMachine.RunStateMachine(OnLoginState); 
        else StateMachine.RunStateMachine(OnNavigationState);
    }


    public void PauseState() => StateMachine.ChangeState(OnPauseState);
    public void BackToGame()
    {
        UIManager.PauseButton.gameObject.SetActive(true);
        UIManager.PanelPause.gameObject.SetActive(false);
        StateMachine.ChangeState(OnNavigationState);
    }
    public void GoToGallery() => StateMachine.ChangeState(OnGalleryState);
    public void GoToMap() => StateMachine.ChangeState(OnPauseState);

    public void GoToAccount() => StateMachine.ChangeState(OnAccountState);

    public void GoToLogin() => StateMachine.ChangeState(OnLoginState);


}
