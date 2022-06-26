namespace HololensSyncServer
{
    public class StateManager : IStateManager
    {
        //For backward comp.
        public string RpcName { get; set; } = "";
        public StateDTO State { get; set; } = new StateDTO();
    }
}
