namespace HololensSyncServer
{
    public interface IStateManager
    {
        public string RpcName { get; set; }
        public StateDTO State { get; set; }
    }
}