using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum SceneType 
    { Title, 
      Select, 
      Town,
      Hotel,
      Battle, 
      Stat,
      Map,
      GameOver, 

      Size 
    }

    public enum Job { Warrior = 1, Mage, Rogue }
}
