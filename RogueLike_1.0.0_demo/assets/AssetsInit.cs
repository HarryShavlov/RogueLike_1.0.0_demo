using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using RogueLike_1._0._0_demo.data.game_objects;
using RogueLike_1._0._0_demo.data.game_objects.dynamic_object;
using RogueLike_1._0._0_demo.data.game_objects.static_object;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.assets
{
    
    public class AssetsInit : IAssetsInit
    {
        private readonly Dictionary<string, IGameObject> prefabs = [];

        public AssetsInit()
        {
            init_prefabs();
        } 

        private void init_prefabs()
        {
            prefabs["Wall"] = new StaticObject('#', "Wall", new Position(0, 0), false);
            prefabs["Finish"] = new StaticObject('F', "Finish", new Position(0, 0), true);

            prefabs["Player"] = new DynamicObject('P', "Player", new Position(0, 0), true, 100);
            
        }

        public IGameObject create(string name_obj, Position position) => prefabs[name_obj].add_with_new_position(position);
        

    }
}
