using RogueLike_1._0._0_demo.data.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_core.game_scene_manager
{
    public interface IGameSceneManager
    {
        public IEnumerable<IGameObject> Game_Objects(Func<IGameObject, bool> predicate);

        void add(IGameObject game_object);
        bool remove(Guid id);
        IGameObject? find_by_id(Guid id);
        void clear();
    }
}
