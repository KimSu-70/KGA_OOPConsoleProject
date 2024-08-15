using RPG.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Interfaces
{
    public interface IInteractable
    {
        void Interaction(Player player);
    }
}
