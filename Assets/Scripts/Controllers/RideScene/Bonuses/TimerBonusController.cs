using Model;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.Bonuses
{
    public class TimerBonusController : BaseBonusController
    {
        [SerializeField] private float bonusTime;
        
        protected override void ApplyBonus()
        {
            gameMediator.RideManager.CurrentState.ExtendTime(bonusTime);
        }
    }
}