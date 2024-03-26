using RogueLike_1._0._0_demo.data.game_core.collision_manager;
using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using RogueLike_1._0._0_demo.data.game_objects.dynamic_object;
using RogueLike_1._0._0_demo.settings.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.settings.controller_manager
{
    public class ControllerManager(IConfig Config, IGameSceneManager GameScene, ICollisionManager CollisionManager) : IControllerManager
    {
        private readonly IConfig config = Config;
        private readonly IGameSceneManager game_scene = GameScene;
        private readonly ICollisionManager collision_manager = CollisionManager;

        public void process_input(ConsoleKey key)
        {
            if (game_scene.find_by_id(config.id_player) is not DynamicObject player)
                return;

            Direction? direction = key switch
            {
                ConsoleKey.W => Direction.Up,
                ConsoleKey.S => Direction.Down,
                ConsoleKey.A => Direction.Left,
                ConsoleKey.D => Direction.Right,
                _ => null
            };

            if (direction.HasValue)
                player.move(direction.Value, collision_manager.can_move);
        }
    }
}
