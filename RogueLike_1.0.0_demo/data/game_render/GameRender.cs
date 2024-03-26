using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using RogueLike_1._0._0_demo.settings.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_render
{
    public class GameRender(IGameSceneManager GameScene, IConfig Config) : IGameRender
    {
        private readonly IGameSceneManager game_scene = GameScene;
        private readonly IConfig config = Config;
        private char[,] current_buffer = new char[Config.map_width, Config.map_height];
        private char[,] previous_buffer = new char[Config.map_width, Config.map_height];

        private void initialize_buffer(char[,] buffer)
        {
            for (int y = 0; y < config.map_height; y++)
                for (int x = 0; x < config.map_width; x++)
                    buffer[x, y] = ' ';
        }

        public void render()
        {
            initialize_buffer(current_buffer);

            foreach (var obj in game_scene.Game_Objects(_ => true))
                current_buffer[obj.position.x, obj.position.y] = obj.sprite;

            for (int y = 0; y < config.map_height; y++)
                for (int x = 0; x < config.map_width; x++)
                    if (current_buffer[x, y] != previous_buffer[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(current_buffer[x, y]);
                    }

            Console.SetCursorPosition(0, config.map_height);

            (current_buffer, previous_buffer) = (previous_buffer, current_buffer);

            Console.CursorVisible = false;
        }
    }

}
