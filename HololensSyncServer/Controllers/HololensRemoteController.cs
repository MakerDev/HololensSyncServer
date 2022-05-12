using Microsoft.AspNetCore.Mvc;

namespace HololensSyncServer.Controllers
{
    public class RemoteDTO
    {
        public string? RpcName { get; set; } = null;
    }

    [ApiController]
    [Route("api/[controller]")]
    public class HololensRemoteController : ControllerBase
    {
        private readonly ILogger<HololensRemoteController> _logger;
        private readonly IStateManager _stateManager;

        public HololensRemoteController(ILogger<HololensRemoteController> logger, IStateManager stateManager)
        {
            _logger = logger;
            _stateManager = stateManager;
        }

        [HttpGet]
        public ActionResult<RemoteDTO> GetLastAction()
        {
            var remoteDTO = new RemoteDTO();

            if (_stateManager.RpcName != null)
            {
                remoteDTO.RpcName = _stateManager.RpcName;
                _stateManager.RpcName = "None";
            }

            return Ok(remoteDTO);
        }

        [HttpGet("GetCurrentAction")]
        public string GetCurrentAction()
        {
            if (_stateManager.RpcName == null)
            {
                return "None";
            }

            return _stateManager.RpcName;
        }

        [HttpPost(Name = "PostLastAction")]
        public bool PostLastAction([FromQuery] string rpcName)
        {
            bool isOverwriten = false;
            if (_stateManager.RpcName == null)
            {
                isOverwriten = true;
            }

            _stateManager.RpcName = rpcName;

            return isOverwriten;
        }
    }
}
