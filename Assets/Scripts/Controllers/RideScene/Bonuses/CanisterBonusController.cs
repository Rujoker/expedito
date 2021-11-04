using Model;

namespace SergeyPchelintsev.Expedito.Controllers.Bonuses
{
    public class CanisterBonusController : BaseBonusController
    {
        protected override void ApplyBonus()
        {
           gameMediator.RideManager.CurrentState.RefillFuel();
        }
    }
}