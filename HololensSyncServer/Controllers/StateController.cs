using Microsoft.AspNetCore.Mvc;

namespace HololensSyncServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private readonly ILogger<StateController> _logger;
        private readonly IStateManager _stateManager;

        public StateController(ILogger<StateController> logger, IStateManager stateManager)
        {
            _logger = logger;
            _stateManager = stateManager;
        }

        [HttpGet]
        public ActionResult<RemoteDTO> GetState()
        {          
            return Ok(_stateManager.State);
        }

        [HttpPost]
        public ActionResult UpdateState(StateDTO state)
        {
            _stateManager.State = state;
            return Ok();
        }
    }
}
