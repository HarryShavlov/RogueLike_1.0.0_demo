using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_core.collision_manager
{
    public class CollisionManager(IGameSceneManager GameScene) : ICollisionManager
    {
        private readonly IGameSceneManager game_scene = GameScene;

        public bool can_move(Position position) => game_scene.Game_Objects(obj => obj.position.Equals(position)).All(obj => obj.passable);

        public bool check_collision(Guid object1_id, Guid object2_id)
        {
            return game_scene.find_by_id(object1_id).position == game_scene.find_by_id(object2_id).position;
        }

    }
}
