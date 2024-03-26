using RogueLike_1._0._0_demo.data.game_core.collision_manager;
using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using RogueLike_1._0._0_demo.data.game_initializer;
using RogueLike_1._0._0_demo.data.game_render;
using RogueLike_1._0._0_demo.settings.config;
using RogueLike_1._0._0_demo.settings.controller_manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_core.game_loop
{
    public class GameLoop(
                IConfig Config,
                ICollisionManager CollisionManager,
                IGameRender Render,
                IControllerManager controller,
                IGameInit initializer,
                IGameSceneManager game_scene
            ) : IGameLoop
    {
        private readonly IConfig config = Config;
        private readonly ICollisionManager collision_manager = CollisionManager;
        private readonly IGameRender renderer = Render;
        private readonly IControllerManager controller = controller;
        private readonly IGameInit initializer = initializer;

        private readonly IGameSceneManager game_scene = game_scene;

        public void run()
        {
            initializer.init();

            while (!config.game_over)
            {
               
                check_finished();

                renderer.render();

                var key = Console.ReadKey(true).Key;
                controller.process_input(key);
            }
            on_game_over();
        }

        private void check_finished()
        {
            if (collision_manager.check_collision(config.id_player, config.id_finish))
                initializer.init();
        }

        private static void on_game_over() => Console.WriteLine("ГАМОВЕР! ПОСТАВЬТЕ ЗАЧётик ПАЖАВУСТА!");
    }

}
