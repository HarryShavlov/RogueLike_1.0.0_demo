using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using RogueLike_1._0._0_demo.data.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.assets
{
    public interface IAssetsInit
    {
        IGameObject create(string name_obj, Position position);
    }
}
